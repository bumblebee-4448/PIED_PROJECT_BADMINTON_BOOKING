namespace Rallyhub.Service.Court;

public interface IService
{
    public Task<Base.Response.PageResult<Response.SearchCourtResponse>>  SearchByFilter(Request.SearchByFilterRequest request);
    public Task<Response.SearchCourtResponse> GetCourtsById(Guid courtId);
}