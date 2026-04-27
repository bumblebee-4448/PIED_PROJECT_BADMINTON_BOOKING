namespace Rallyhub.Service.Admin;

public interface IService
{
    public Task<Base.Response.PageResult<Response.UserDto>>
        GetUsers(string? searchTmp,
            int pageIndex,
            int pageSize,
            Guid? id,
            Enum.Enum.Role? role,
            Enum.Enum.StatusUsers? status);

    public Task<Response.UserDto> GetUserById(Guid id);
}