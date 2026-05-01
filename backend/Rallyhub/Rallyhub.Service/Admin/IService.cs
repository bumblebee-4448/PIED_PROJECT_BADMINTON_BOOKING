namespace Rallyhub.Service.Admin;

public interface IService
{
    /*
     UserMethod
     */
    public Task<Base.Response.PageResult<Response.UserDto>>
        FilterUser(string? search, int pageIndex, int pageSize, Guid? id, Enum.Enum.Role? role, Enum.Enum.StatusUsers? status);
    public Task<Response.UserDto> UserDetail(Guid id);
    public Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request);
    public Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId);
    public Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason);
    public Task UpdateStatusUser(Request.UpdateStatusUserResponse request);
    public Task<Base.Response.PageResult<Response.GetPendingCourtsResponse>> GetPendingCourts  
        (Request.GetPendingCourtsRequest request);  
  
    public Task ApprovePendingCourt(Guid courtId);  
    public Task RejectPendingCourt(Guid courtId, Request.RejectPendingCourtsRequest request);
    /*
     CourtMethod
     */
    public Task DeleteCourt(Guid id);
}