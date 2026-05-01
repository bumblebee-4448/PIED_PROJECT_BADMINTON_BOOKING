namespace Rallyhub.Service.Owner;

public interface IService
{
    //Owner: tạo sân
    public Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request);  
    //Owner: lấy thông tin các sân (đang tạo và đã được duyệt)
    public Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllCourts(Request.GetMyCourtsRequest request);
    
    //Owner: Tạo subcourt
    public Task<Response.SubCourtResponse> CreateSubCourt(Request.CreateSubCourtRequest request);
    public Task<Response.CreateConfigSlotResponse> CreateConfigSlot(Request.CreateConfigSlotRequest request);
    public Task<List<Response.ConfigSlotResponse>> GetConfigSlotBySubCourtId(Guid subCourtId);
    public Task<Response.CreateOverrideResponse> CreateOverrideSlot(Request.CreateOverrideSlotRequest request);
}