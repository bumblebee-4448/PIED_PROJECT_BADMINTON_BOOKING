using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Report;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Notification.IService _notification;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, Notification.IService notification)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _notification = notification;
    }

    public async Task<string> CreateReportBookings(Request.CreateReportBookingsRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("User not found");
        }
        var userId = Guid.Parse(getUserId);
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == userId);
        if (customer == null)
        {
            throw new Exception("Customer not found 1");
        }

        var existBooking = _dbContext.Bookings
            // .Include(x => x.BookingDetails)
            //     .ThenInclude(x => x.SubCourt)
            //         .ThenInclude(x => x.Court)
            .Where(x =>
                x.Status == "Completed" &&
                x.Id == request.BookingId &&
                x.CustomerId == customer.Id);
        if (!existBooking.Any())
        {
            throw new Exception("Đơn đặt sân không đủ điều kiện báo cáo");
        }        
        var bookingDetail = await _dbContext.BookingDetails.FirstOrDefaultAsync(x => x.BookingId == request.BookingId);
        if (bookingDetail == null)
        {
            throw new Exception("Booking not found");
        }
        var subCourt = await _dbContext.SubCourts.FirstOrDefaultAsync(x => x.Id == bookingDetail.SubCourtId);
        if (subCourt == null)
        {
            throw new Exception("Court not found");
        }
        var report = new Repository.Entity.Report()
        {
            Reason = request.Reason,
            CustomerId = customer.Id,
            CourtId = subCourt.CourtId,
            BookingId = request.BookingId,
            CreatedAt = DateTimeOffset.UtcNow
        };
        await _dbContext.Reports.AddAsync(report);
        
        _notification.CreateNotification(new Notification.Request.CreateNotificationRequest
        {
            UserId = userId, // Assigning to user ID but it's an Admin type
            Title = "Khiếu nại đặt sân mới",
            Content = $"Khách hàng vừa gửi một khiếu nại cho sân ID: {report.CourtId}.",
            Type = Notification.Request.TypeNotification.ReportCreated,
            ReportId = report.Id
        });

        await _dbContext.SaveChangesAsync();
        return "Báo cáo đơn đặt sân thành công";
    }

    public async Task<Base.Response.PageResult<Response.GetReportBookingsRequest>> GetReportBookings(Request.GetReportBookingsRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("User not found");
        }
        var userId = Guid.Parse(getUserId);
        var user = await _dbContext.Users
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == userId);
        var report = _dbContext.Reports
            .Where(x => x.IsDeleted == false);

        if (user!.Role != "Admin")
        {
            report = report
                .Where(x => x.CustomerId == user.Customer!.Id)
                .OrderBy(x =>
                    x.Status == "Confirmed" ? 1 :
                    x.Status == "Pending" ? 2 : 3)
                .ThenByDescending(x => x.CreatedAt);
        }
        else
        {
            report = report
                .OrderBy(x =>
                    x.Status == "Pending" ? 1 :
                    x.Status == "Confirmed" ? 2 : 3)
                .ThenByDescending(x => x.CreatedAt);
        }
        
        var totalItems = await report.CountAsync();
        var pageQuery = report.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetReportBookingsRequest()
        {
            ReportBookingId =  x.Id,
            Reason =  x.Reason,
            CustomerId = x.CustomerId,
            CourtId =  x.CourtId,
            BookingId =  x.BookingId,
            Status = x.Status
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetReportBookingsRequest>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = totalItems
        };
        return result;
    }

    public async Task<string> ConfirmReport(Request.ConfirmReportRequest request)
    {
        var report = await _dbContext.Reports.FirstOrDefaultAsync(x => x.Id == request.ReportId);
        if (report == null)
        {
            throw new Exception("Report not found");
        }

        var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == report.CustomerId);
        if (customer == null)
        {
            throw new Exception("user not found");
        }
        _notification.CreateNotification(new Notification.Request.CreateNotificationRequest()
        {
            UserId = customer.UserId,
            Title = "Khiếu nại của bạn đã được phản hồi",
            Content = "Hệ thống đã xác nhận báo cáo đặt sân của bạn và đang tiến hành xử lý.",
            Type = Notification.Request.TypeNotification.ReportResponded,
            ReportId =  request.ReportId,
        });
        report.Status = "Completed";
        report.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.Reports.Update(report);
        await _dbContext.SaveChangesAsync();
        return "Phản hồi thành công";
    }
}