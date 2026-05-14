namespace Rallyhub.Service.Owner;

public interface IService
{
    public Task<Response.CreateCourtResponse> CreateCourt(Request.CreateCourtRequest request); 
    public Task<string> RemoveCourt(Guid courtId);
    public Task<Base.Response.PageResult<Response.GetMyCourtsResponse>> GetAllMyCourts(Request.GetAllMyCourtsRequest request);
    public Task<Response.UpdateCourtInfoResponse> UpdateCourtInfo(Request.UpdateCourtInfoRequest request);
    public Task<Response.CreateSubCourtResponse> CreateSubCourt(Request.CreateSubCourtRequest request);
    public Task<string> RemoveSubCourt(Guid subCourtId);
    public Task<Base.Response.PageResult<Response.GetMySubCourtsResponse>> GetMySubCourts(Request.GetMySubCourtsRequest request);
    public Task<Response.UpdateSubCourtInfoResponse> UpdateSubCourtInfo(Request.UpdateSubCourtInfoRequest request);
    //public Task<Response.CreateConfigSlotResponse> CreateConfigSlot(Request.CreateConfigSlotRequest request);
    public Task<List<Response.GetConfigSlotResponse>> GetConfigSlotBySubCourtId(Guid subCourtId);
    public Task<string> UpdateConfigSlotPrice(Request.UpdateConfigSlotPriceRequest request);
    public Task<Response.CreateOverrideSlotResponse> CreateOverrideSlot(Request.CreateOverrideSlotRequest request);
    public Task<List<Response.GetOverrideSlotResponse>> GetOverrideSlotBySubCourtId(Guid subCourtId);
    public Task<string> RemoveOverrideSlot(Guid overrideSlotId);
    public Task<Response.CreateExceptionSlotResponse> CreateExceptionSlot(Request.CreateExceptionSlotRequest request);
    public Task<List<Response.GetExceptionSlotResponse>> GetExceptionSlotBySubCourtId(Guid subCourtId);
    public Task<string> UnlockException(Guid exceptionSlotId);
    public Task<Response.GetSetupSlotResponse> GetSetupSlots(Guid subCourtId, DateOnly date);
    public Task<List<Response.SlotResponse>> GetAvailableSlots(Request.GetAvailableSlotsRequest request);
}