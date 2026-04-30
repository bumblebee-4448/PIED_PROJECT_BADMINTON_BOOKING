namespace Rallyhub.Service.User;

public interface IService
{
    public Task<string> OwnerRequest(Request.OwnerRequestRequest request);
    public Task<Base.Response.PageResult<Response.OwnerRequestResponse>> GetOwnerRequest(Request.GetOwnerRequest request);
}