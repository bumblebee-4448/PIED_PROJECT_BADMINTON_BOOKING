using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;
using Rallyhub.Service.MailService;

namespace Rallyhub.Service.SystemReport;

public class Service: IService
{
    private readonly AppDbContext _dbContext;  
    private readonly IHttpContextAccessor _httpContext;  
    private readonly Notification.IService _notification;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContext, Notification.IService notification)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
        _notification = notification;
    }

    public async Task CreateSystemReport(Request.CreateSystemReportRequest request)
    {
        var getUserId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("user not found");
        }
        var userId = Guid.Parse(getUserId);
        var result = new Repository.Entity.SystemReport()
        {
            Title = request.Title,
            Reason = request.Reason,
            UserId = userId,
            CreatedAt = DateTimeOffset.UtcNow
        };
        _dbContext.SystemReports.Add(result);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetSystemReportResponse>> GetSystemReport(Request.GetSystemReportRequest request)
    {
        var getUserId = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("user not found");
        }
        var userId = Guid.Parse(getUserId);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("user not found");
        }
        var systemReportList = _dbContext.SystemReports
                                                            .Where(x => x.Status == request.Status && x.IsDeleted == false);
        if (user.Role != "Admin")
        {
            systemReportList = systemReportList.Where(x => x.UserId == userId);
        }
        var sortTime = systemReportList.OrderByDescending(x => x.CreatedAt);
        var totalItem = await sortTime.CountAsync();
        var pageQuery = sortTime.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetSystemReportResponse()
        {
            Id = x.Id,
            Title =  x.Title,
            Reason = x.Reason,
            Status = x.Status,
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetSystemReportResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = totalItem
        };
        return result;
    }

    public async Task SubmitReportReply(Request.SubmitReportReplyRequest request)
    {
        var report = await _dbContext.SystemReports.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (report == null)
        {
            throw new Exception("report not found");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == report.UserId);
        if (user == null)
        {
            throw new Exception("user not found");
        }
        _notification.CreateNotification(new Notification.Request.CreateNotificationRequest()
        {
            UserId = user.Id,
            Title = report.Title,
            Content =  "Hệ thống đã xác nhận báo cáo của bạn",
            Type = Notification.Request.TypeNotification.SystemReportCreated,
            SystemReportId =  report.Id,
        });
        report.Status = "Confirmed";
        report.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.SystemReports.Update(report);
        await _dbContext.SaveChangesAsync();
    }
}