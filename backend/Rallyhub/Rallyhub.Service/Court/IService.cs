namespace Rallyhub.Service.Court;

public interface IService
{
    public Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request);
    public Task<Base.Response.PageResult<Response.SearchCourtResponse>>  SearchByFilter(Request.SearchByFilterRequest request);
}