namespace Rallyhub.Service.Owner;

public interface IService
{
    public Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request);
    public Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllCourts(Request.GetMyCourtsRequest request);
}