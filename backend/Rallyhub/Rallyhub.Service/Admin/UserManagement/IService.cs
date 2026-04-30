namespace Rallyhub.Service.Admin.UserManagement;

public interface IService
{
    public Task<Base.Response.PageResult<Response.UserDto>>
        GetUsers(string? search, int pageIndex, int pageSize, Guid? id, Enum.Enum.Role? role, Enum.Enum.StatusUsers? status);
    public Task<Response.UserDto> GetUserById(Guid id);
    
}