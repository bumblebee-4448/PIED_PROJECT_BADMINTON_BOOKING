namespace Rallyhub.Service.NotificationService;

public interface IService
{
    public Task<bool> CreateNotification(Request.CreateNotificationRequest request);
    public Task<bool> ReadNotification(Guid notificationId);
    // public Task<Base.Response.PageResult<Response.GetNotificationResponse>> GetNotification(Base.Request.PagingRequest request);

}