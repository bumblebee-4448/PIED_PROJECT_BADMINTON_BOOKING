namespace Rallyhub.Service.Owner;

public interface IService
{
    //Owner: tạo sân
    public Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request);  
    //Owner: lấy thông tin các sân (đang tạo và đã được duyệt)
    public Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllCourts(Request.GetMyCourtsRequest request);
    
    //Owner: Tạo subcourt
    public Task<Response.CreateSubCourtResponse> CreateSubCourt(Request.CreateSubCourtRequest request);
    public Task<Base.Response.PageResult<Response.GetMySubCourtsResponse>> GetMySubCourts(Request.GetMySubCourtsRequest request);
    public Task<Response.CreateConfigSlotResponse> CreateConfigSlot(Request.CreateConfigSlotRequest request);
    public Task<List<Response.GetConfigSlotResponse>> GetConfigSlotBySubCourtId(Guid subCourtId);
    public Task<Response.CreateOverrideSlotResponse> CreateOverrideSlot(Request.CreateOverrideSlotRequest request);
    public Task<List<Response.GetOverrideSlotResponse>> GetOverrideSlotBySubCourtId(Guid subCourtId);
    public Task<Response.CreateExceptionSlotResponse> CreateExceptionSlot(Request.CreateExceptionSlotRequest request);
    public Task<List<Response.GetExceptionSlotResponse>> GetExceptionSlotBySubCourtId(Guid subCourtId);
    public Task<Response.GetSetupSlotResponse> GetSetupSlots(Guid subCourtId);
    public Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request);
}