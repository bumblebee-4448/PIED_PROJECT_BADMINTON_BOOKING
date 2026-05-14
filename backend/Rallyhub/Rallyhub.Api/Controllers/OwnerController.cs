using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Models;
using Rallyhub.Service.Owner;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Authorize(Policy = JwtExtensions.OwnerPolicy)]
[Route("[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IService _ownerService;

    public OwnerController(IService ownerService)
    {
        _ownerService = ownerService;
    }
    
    [HttpPost("OwnerCreateCourt")]  
    public async Task<IActionResult> CreateCourt([FromForm]Request.CreateCourtRequest request)  
    {  
        var result = await _ownerService.CreateCourt(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Waiting for Admin accept"   
            , HttpContext.TraceIdentifier));  
    }  
    
    [HttpDelete("RemoveCourt{courtId}")]
    public async Task<IActionResult> RemoveCourt(Guid courtId)
    {
        await _ownerService.RemoveCourt(courtId);

        return Ok(ApiResponseFactory.SuccessResponse(
            true,
            "Xóa sân thành công",
            HttpContext.TraceIdentifier
        ));
    }
    [HttpGet("OwnerGetAllCourts")]  
    public async Task<IActionResult> GetAllCourts([FromQuery]Request.GetAllMyCourtsRequest request)  
    {  
        var result = await _ownerService.GetAllMyCourts(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }   
    
    [HttpPut("UpdateCourtInfo")]  
    public async Task<IActionResult> UpdateCourtInfoRequest(Request.UpdateCourtInfoRequest request)  
    {  
        var result = await _ownerService.UpdateCourtInfo(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    
    [HttpPost("OwnerCreateSubCourt")]  
    public async Task<IActionResult> CreateSubCourt([FromBody]Request.CreateSubCourtRequest request)  
    {  
        var result = await _ownerService.CreateSubCourt(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    } 
    [HttpDelete("RemoveSubCourt{subCourtId}")]
    public async Task<IActionResult> RemoveSubCourt(Guid subCourtId)
    {
        await _ownerService.RemoveSubCourt(subCourtId);

        return Ok(ApiResponseFactory.SuccessResponse(
            true,
            "Xóa sân thành công",
            HttpContext.TraceIdentifier
        ));
    }
    
    
    [HttpGet("OwnerGetMySubCourts")] 
    public async Task<IActionResult> GetMySubCourts([FromQuery] Request.GetMySubCourtsRequest request)  
    {  
        var result = await _ownerService.GetMySubCourts(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    } 
    [HttpPut("UpdateSubCourtInfo")]  
    public async Task<IActionResult> UpdateSubCourtInfo(Request.UpdateSubCourtInfoRequest request)  
    {  
        var result = await _ownerService.UpdateSubCourtInfo(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    [HttpGet("OwnerGetConfigSlot")]  
    public async Task<IActionResult> GetConfigSlotBySubCourtId(Guid subCourtId)  
    {  
        var result = await _ownerService.GetConfigSlotBySubCourtId(subCourtId); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    [HttpPut("UpdateConfigSlotPrice")]  
    public async Task<IActionResult> UpdateConfigSlotPrice(Request.UpdateConfigSlotPriceRequest request)  
    {  
        var result = await _ownerService.UpdateConfigSlotPrice(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
        
    [HttpPost("CreateOverrideSlot")]  
    public async Task<IActionResult> CreateOverrideSlot([FromBody]Request.CreateOverrideSlotRequest request)  
    {  
        var result = await _ownerService.CreateOverrideSlot(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }

    [HttpGet("GetOverrideSlotBySubCourtId")]  
    public async Task<IActionResult> GetOverrideSlotBySubCourtId(Guid subCourtId)  
    {  
        var result = await _ownerService.GetOverrideSlotBySubCourtId(subCourtId); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    [HttpDelete("RemoveOverrideSlot{overrideSlotId}")]
    public async Task<IActionResult> RemoveOverrideSlot(Guid overrideSlotId)
    {
        await _ownerService.RemoveOverrideSlot(overrideSlotId);

        return Ok(ApiResponseFactory.SuccessResponse(
            true,
            "Slot gộp đã được xóa",
            HttpContext.TraceIdentifier
        ));
    }
    [HttpPost("CreateExceptionSlot")]  
    public async Task<IActionResult> CreateExceptionSlot([FromBody]Request.CreateExceptionSlotRequest request)  
    {  
        var result = await _ownerService.CreateExceptionSlot(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    [HttpGet("GetExceptionSlotBySubCourtId")]  
    public async Task<IActionResult> GetExceptionSlotResponse(Guid subCourtId)  
    {  
        var result = await _ownerService.GetExceptionSlotBySubCourtId(subCourtId); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    [HttpDelete("UnlockException{exceptionId}")]
    public async Task<IActionResult> UnlockException(Guid exceptionId)
    {
        await _ownerService.UnlockException(exceptionId);

        return Ok(ApiResponseFactory.SuccessResponse(
            true,
            "Mở khóa thành công",
            HttpContext.TraceIdentifier
        ));
    }
    [HttpGet("GetSetupSlotsBySubCourtId")]  
    public async Task<IActionResult> GetSetupSlots(Guid subCourtId, DateOnly date)  
    {  
        var result = await _ownerService.GetSetupSlots(subCourtId, date); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }
    
    [HttpGet("GetAvailableSlots")]  
    public async Task<IActionResult> GetAvailableSlots([FromQuery]Request.GetAvailableSlotsRequest request)  
    {  
        var result = await _ownerService.GetAvailableSlots(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success"   
            , HttpContext.TraceIdentifier));  
    }


}