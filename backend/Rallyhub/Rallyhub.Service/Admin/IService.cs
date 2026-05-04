using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.Admin;

public interface IService
{
    /*
     UserMethod
     */
    public Task<Base.Response.PageResult<Response.UserDto>>
        FilterUser(Request.FilterUserRequest request);
    public Task<Response.UserDto> UserDetail(Request.UserDetailRequest request);
    public Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request);
    public Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId);
    public Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason);
    public Task BanAndUnbanUser(Request.BanAndUnbanUserRequest request);
    public Task<Base.Response.PageResult<Response.GetPendingCourtsResponse>> GetPendingCourts  
        (Request.GetPendingCourtsRequest request);  
  
    public Task ApprovePendingCourt(Guid courtId);  
    public Task RejectPendingCourt(Guid courtId, Request.RejectPendingCourtsRequest request);

    public Task<Response.RefundResponse> Refund(Request.RefundRequest request);
    public Task<List<Response.GetBookingDetailStatusRefundPendingResponse>> GetBookingDetailStatusRefundPending();

    public Task<Response.GetWalletResponse> GetWallet(Request.GetWalletRequest request);
    /*
     CourtMethod
     */
    public Task DeleteCourt(Guid id);
}