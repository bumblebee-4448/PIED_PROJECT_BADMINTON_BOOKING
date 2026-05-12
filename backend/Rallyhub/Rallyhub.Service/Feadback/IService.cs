namespace Rallyhub.Service.Feadback;

public interface IService
{
    public Task CreateFeadback(Request.CreateFeadbackRequest request);
    public Task<Base.Response.PageResult<Response.GetFeadbackResponse>> GetFeadback(Request.GetFeadbackRequest request);
}