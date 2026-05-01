namespace Rallyhub.Service.Customer;

public interface IService
{
    public Task<string> OwnerRequest(Request.OwnerRequestRequest request);
    public Task<Base.Response.PageResult<Response.GetOwnerRequestResponse>> GetOwnerRequest(Request.GetOwnerRequest request);
    public Task<bool> CheckCancelBooking(Request.CancelBooking request);
    public Task CancelBooking(Request.CancelBooking request);
}