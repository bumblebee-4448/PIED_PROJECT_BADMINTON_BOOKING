namespace Rallyhub.Service.Court;

public interface IService
{
    public Task<string> CreateCourt(Request.CreateCourtRequest request);

}