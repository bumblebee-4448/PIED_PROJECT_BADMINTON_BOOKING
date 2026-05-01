using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Models;
using Rallyhub.Service.Owner;

namespace Rallyhub.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IService _ownerService;

    public OwnerController(IService ownerService)
    {
        _ownerService = ownerService;
    }
    
    [HttpPost("CreateCourt")]  
    public async Task<IActionResult> CreateCourt(Request.CreateCourtRequest request)  
    {  
        var result = await _ownerService.CreateCourt(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Tạo sân thành công, đang chờ Admin duyệt"   
            , HttpContext.TraceIdentifier));  
    }  
  
    [HttpGet("GetMyCourts")]  
    public async Task<IActionResult> GetAllCourts([FromQuery] Request.GetMyCourtsRequest request)  
    {  
        var result = await _ownerService.GetAllCourts(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Danh sách tất cả các sân"   
            , HttpContext.TraceIdentifier));  
    }
    
    [HttpPost("CreateSubCourt")]  
    public async Task<IActionResult> CreateSubCourt(Request.CreateSubCourtRequest request)  
    {  
        var result = await _ownerService.CreateSubCourt(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Tạo sân con thành công"   
            , HttpContext.TraceIdentifier));  
    } 
    
    [HttpPost("CreateConfigSlot")]  
    public async Task<IActionResult> CreateConfigSlot(Request.CreateConfigSlotRequest request)  
    {  
        var result = await _ownerService.CreateConfigSlot(request); 
        return Ok(ApiResponseFactory.SuccessResponse( result,"Setup slot thành công"   
            , HttpContext.TraceIdentifier));  
    } 

}