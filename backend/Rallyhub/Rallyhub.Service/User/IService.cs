namespace Rallyhub.Service.User;

public interface IService
{
    public Task UpdateProfile(Request.UpdateProfile request);
}