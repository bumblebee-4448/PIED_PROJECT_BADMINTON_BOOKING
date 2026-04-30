namespace Rallyhub.Service.Admin;

public interface IService
{
    /*
     UserMethod
     */
    public Task<Base.Response.PageResult<Response.UserDto>>
        GetUsers(string? search, int pageIndex, int pageSize, Guid? id, Enum.Enum.Role? role, Enum.Enum.StatusUsers? status);
    public Task<Response.UserDto> GetUserById(Guid id);
    public Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request);
    public Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId);
    public Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason);
    public Task UpdateStatusUser(Request.UpdateStatusUserResponse request);
    /*
     CourtMethod
     */
    public Task DeleteCourt(Guid id);
}