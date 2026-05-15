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

    public async Task CreateReportBookings(Request.CreateReportBookingsRequest request)
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
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetReportBookingsRequest>> GetReportBookings(Request.GetReportBookingsRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("User not found");
        }
        var userId = Guid.Parse(getUserId);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var report = _dbContext.Reports.Where(x => x.IsDeleted == false);
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            report = report.Where(x => x.Status == request.Status);
        }
        if (user!.Role == "Customer")
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.UserId == userId);
            if (customer == null)
            {
                throw new Exception("user not found");
            }
            report = report.Where(x => x.CustomerId == customer.Id);
        }
        
        var sortTime = report.OrderByDescending(x => x.CreatedAt);
        var totalItems = await report.CountAsync();
        var pageQuery = sortTime.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetReportBookingsRequest()
        {
            Reason =  x.Reason,
            CustomerId = x.CustomerId,
            CourtId =  x.CourtId,
            BookingId =  x.BookingId,
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

    public async Task ConfirmReport(Request.ConfirmReportRequest request)
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
            Title = "rallyhub đã phản hồi 1 report của bạn",
            Content = "Hệ thống đã xác nhận báo cáo đặt sân của bạn và đang xử lý",
            Type = Notification.Request.TypeNotification.ReportCreated,
            ReportId =  request.ReportId,
        });
        report.Status = "Completed";
        _dbContext.Reports.Update(report);
        await _dbContext.SaveChangesAsync();
    }
}