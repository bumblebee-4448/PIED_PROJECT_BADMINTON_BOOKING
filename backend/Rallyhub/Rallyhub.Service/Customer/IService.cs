namespace Rallyhub.Service.Customer;

public interface IService
{
    public Task<string> OwnerRequest(Request.OwnerRequestRequest request);
    public Task<Base.Response.PageResult<Response.GetOwnerRequestResponse>> GetOwnerRequest(Request.GetOwnerRequest request);
    public Task<bool> CheckCancelBooking(Request.CancelBooking request);
    public Task CancelBooking(Request.CancelBooking request);
    public Task<Base.Response.PageResult<Response.LikeListResponse>> GetAllLikeList(int pageIndex, int pageSize);
    public Task AddCourtLikeList(Request.AddCourtLikeListRequest request);
    public Task DeleteCourtLikeList(Request.DeteleCourtLikeListRequest request);
    public Task<Base.Response.PageResult<Response.BookingResponse>> GetAllBooking (int pageIndex, int pageSize);
}