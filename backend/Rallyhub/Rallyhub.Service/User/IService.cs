namespace Rallyhub.Service.User;

public interface IService
{
    public Task<string> OwnerRequest(Request.OwnerRequestRequest request);
}