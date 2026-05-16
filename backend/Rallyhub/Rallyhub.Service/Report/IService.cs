namespace Rallyhub.Service.Report;

public interface IService
{
    public Task<string> CreateReportBookings(Request.CreateReportBookingsRequest request);
    public Task<Base.Response.PageResult<Response.GetReportBookingsRequest>> GetReportBookings(Request.GetReportBookingsRequest request);
    public Task<string> ConfirmReport(Request.ConfirmReportRequest request);
}