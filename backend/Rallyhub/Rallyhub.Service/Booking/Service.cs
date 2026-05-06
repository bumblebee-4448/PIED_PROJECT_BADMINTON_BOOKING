using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using StatusCourt = Rallyhub.Service.Enum.Enum.StatusCreateCourt;
namespace Rallyhub.Service.Booking;

public class Service: IService
{
    
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContext;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
    }
    
     public async Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request)
    {
        var subCourt = await _dbContext.SubCourts
            .Include(x => x.Court)
            .FirstOrDefaultAsync(x => 
                x.Id == request.SubCourtId && 
                x.Court.Status == nameof(StatusCourt.Active));
        if (subCourt == null)
        {
            throw new Exception($"sub court with id {request.SubCourtId} not found");
        }
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (request.Date < today)
        {
            throw new Exception("Không thể xem slot trong quá khứ");
        }
        var configSlots = await _dbContext.ConfigSlots
            .Where(x => x.SubCourtDetailId == request.SubCourtId)
            .OrderBy(x => x.StartTime)
            .ToListAsync();
        var overrides = await _dbContext.OverideSlots
            .Where(x => 
                x.SubCourtDetailId == request.SubCourtId &&
                ( 
                    (!x.IsRecurring && x.Date == request.Date) || 
                    (x.IsRecurring && x.DayOfWeek == request.Date.DayOfWeek)
                            
                )).ToListAsync();
        var exceptions = await  _dbContext.Exceptions
            .Where(x => 
                x.SubCourtDetailId == request.SubCourtId &&
                x.Date == request.Date)
            .ToListAsync(); 
        var result = configSlots.Select(x => new Response.SlotResponse
        {
            StartTime =  x.StartTime,
            EndTime =  x.EndTime,
            Price = x.Price,
            IsAvailable = true
        }).ToList();
        //Apply override 
        foreach (var ov in overrides)
        {
            //remove slot bi override
            result.RemoveAll(x => 
                x.StartTime >= ov.StartTime && 
                x.EndTime <= ov.EndTime);
            //add slot moi
            result.Add(new Response.SlotResponse
            {
                StartTime = ov.StartTime,
                EndTime = ov.EndTime,
                Price = ov.Price,
                IsAvailable = true
            });
        }
        //Apply exception 
        foreach (var ex in exceptions)
        {
            result.RemoveAll(x =>
                x.StartTime < ex.EndTime &&
                x.EndTime > ex.StartTime);
        }
        var bookedSlots = await _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == request.Date.ToDateTime(TimeOnly.MinValue).Date && 
                (x.Status == "Pending" || x.Status == "Banked"))
            .ToListAsync();
        
        foreach (var slot in result)
        {
            slot.IsAvailable = !bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
        }
        return result.OrderBy(x => x.StartTime).ToList();
    }
     
    public async Task<Response.HoldBookingResponse> HoodBooking(Request.HoldBookingRequest request)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của customer");
        }
        var customerId = Guid.Parse(customerIdClaim);

        var availableSlots = await GetAvailableSlots(new Request.GetAvailableSlotsRequest
        {
            SubCourtId = request.SubCourtId,
            Date = request.Date
        });

        foreach (var slot in request.Slots)
        {
            var systemSlot = availableSlots.FirstOrDefault(x =>
                x.StartTime == slot.StartTime
                && x.EndTime == slot.EndTime);

            if (systemSlot == null)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} không tồn tại");
            }

            if (!systemSlot.IsAvailable)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị đặt");
            }
        }
        
        var dateTime = new DateTimeOffset(request.Date.ToDateTime(TimeOnly.MinValue), TimeSpan.Zero);
        var bookedSlots = await  _dbContext.BookingDetails
            .Where(x =>
                x.SubCourtId == request.SubCourtId &&
                x.Date.Date == dateTime.Date &&
                (x.Status == "Pending" || x.Status == "Banked")).ToListAsync();
        foreach (var slot in request.Slots)
        {
            var conflict = bookedSlots.Any(b =>
                b.StartTime < slot.EndTime &&
                b.EndTime > slot.StartTime);
            if (conflict)
            {
                throw new Exception($"Slot {slot.StartTime}-{slot.EndTime} đã bị người khác đặt");
            }
        }
        
        var totalPrice = request.Slots.Sum(slot =>
            availableSlots.First(x => 
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price);

        var booking = new Repository.Entity.Booking
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TotalPrice = totalPrice,
            FinalPrice = totalPrice,
            Status = "Pending",
            ExpiresAt = DateTimeOffset.UtcNow.AddMinutes(5),
            CampaignId = null
        };
        
        var bookingDetails = request.Slots.Select(slot => new Repository.Entity.BookingDetail
        {
            Id = Guid.NewGuid(),
            SubCourtId = request.SubCourtId,
            BookingId = booking.Id,
            Date = dateTime,
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            Price = availableSlots.First(x =>
                x.StartTime == slot.StartTime &&
                x.EndTime == slot.EndTime).Price,
            Status = "Pending",
        }).ToList();
        
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.BookingDetails.AddRangeAsync(bookingDetails);
        await _dbContext.SaveChangesAsync();

        return new Response.HoldBookingResponse
        {
            BookingId = booking.Id,
            TotalPrice = booking.TotalPrice,
            ExpiredAt = booking.ExpiresAt,
        };
    }

    public async Task<Response.GetBookingResponse> GetBookingById(Guid bookingId)
    {
        var customerIdClaim = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CustomerId")?.Value;
        if (customerIdClaim == null)
        {
            throw new Exception("Không tìm thấy thông tin của customer");
        }
        var  customerId = Guid.Parse(customerIdClaim);
        
        var booking = await _dbContext.Bookings
            .Include(x => x.BookingDetails)
            .FirstOrDefaultAsync(x => x.Id == bookingId);
        if (booking == null)
        {
            throw new Exception($"Booking {bookingId} không tồn tại");
        }

        if (booking.CustomerId != customerId)
        {
            throw new Exception("Bạn không có quyền xem booking này");
        }

        if (booking.Status == "Cancel")
        {
            throw new Exception("Booking này đã hết hạn hoặc bị hủy");
        }
        if (booking.Status == "Banked")
        {
            throw new Exception("Booking này đã được thanh toán");
        }

        string description = $"RALLYHUB-{booking.Id}";
        string qrCodeUrl = $"https://qr.sepay.vn/img?" +
                           $"acc=0963518963&" +
                           $"bank=MBBank&" +
                           $"amount={(int)booking.FinalPrice}&" +
                           $"des={description}&" +
                           $"template=qronly";
        return new Response.GetBookingResponse
        {
            BookingId = booking.Id,
            TotalPrice = booking.TotalPrice,
            ExpiredAt = booking.ExpiresAt,
            Status = booking.Status,
            Slots = booking.BookingDetails.Select(x => new Response.BookingDetailItem
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price
            }).ToList(),
            QrCodeUrl = qrCodeUrl
        };
    }
}