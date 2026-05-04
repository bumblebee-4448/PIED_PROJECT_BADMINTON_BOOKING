using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.Admin;

public interface IService
{
    /*
     UserMethod
     */
    public Task<Base.Response.PageResult<Response.UserDto>>
        FilterUser(string? search, Guid? id, Enum.Enum.Role? role, Enum.Enum.StatusUsers? status, int pageIndex, int pageSize);
    public Task<Response.UserDto> UserDetail(Guid id);
    public Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request);
    public Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId);
    public Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason);
    public Task UpdateStatusUser(Request.UpdateStatusUserResponse request);
    public Task<Base.Response.PageResult<Response.GetPendingCourtsResponse>> GetPendingCourts  
        (Request.GetPendingCourtsRequest request);  
  
    public Task ApprovePendingCourt(Guid courtId);  
    public Task RejectPendingCourt(Guid courtId, Request.RejectPendingCourtsRequest request);

    public Task<Response.RefundResponse> Refund(Request.RefundRequest request);

    public Task<Response.GetWalletResponse> GetWallet(string email);
    /*
     CourtMethod
     */
    public Task DeleteCourt(Guid id);
}