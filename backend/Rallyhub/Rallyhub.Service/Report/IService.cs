namespace Rallyhub.Service.Report;

public interface IService
{
    public Task CreateReportBookings(Request.CreateReportBookingsRequest request);
    public Task<Base.Response.PageResult<Response.GetReportBookingsRequest>> GetReportBookings(Request.GetReportBookingsRequest request);
    public Task ConfirmReport(Request.ConfirmReportRequest request);
}