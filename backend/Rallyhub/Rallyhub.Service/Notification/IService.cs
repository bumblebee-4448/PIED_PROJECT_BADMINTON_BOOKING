namespace Rallyhub.Service.Notification;

public interface IService
{
    public void CreateNotification(Request.CreateNotificationRequest request);
    public Task<bool> ReadNotification(Guid notificationId);
    public Task<int> GetUnreadCount();
    public Task<bool> MarkAllAsRead();
    public Task<Base.Response.PageResult<Response.GetNotificationResponse>> GetNotification(
        Base.Request.PagingRequest request);
    public Task<Base.Response.PageResult<Response.GetNotificationResponse>> AdminGetNotification(
        Base.Request.PagingRequest request);
}