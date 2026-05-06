namespace Rallyhub.Service.Court;

public interface IService
{
    public Task<Base.Response.PageResult<Response.SearchCourtResponse>>  SearchByFilter(Request.SearchByFilterRequest request);
    public Task<Response.SearchCourtByIdResponse> GetCourtsDetailById(Guid courtId);
    public Task<Response.ListSubCourtResponse> GetSubCourtById(Guid courtId);
    public Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request);
}