using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Admin;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController: ControllerBase
{
    private readonly IService _adminService;
    public AdminController(IService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("GetAllPendingCourts")]
    public async Task<IActionResult> GetAllPendingCourts([FromQuery] Request.GetPendingCourtsRequest request)
    {
        var result = await _adminService.GetPendingCourts(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Lấy tất cả các sân ở trạng thái Pending thành công" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("RejectPendingCourt/{courtId}")]
    public async Task<IActionResult> RejectPendingCourt(Guid courtId,  [FromBody] Request.RejectPendingCourtsRequest request)
    {
         await _adminService.RejectPendingCourt(courtId, request);
        return Ok(ApiResponseFactory.SuccessResponse( "","Từ chối thành công" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("ApprovePendingCourt/{courtId}")]
    public async Task<IActionResult> ApprovePendingCourt(Guid courtId)
    {
      await _adminService.ApprovePendingCourt(courtId);
        return Ok(ApiResponseFactory.SuccessResponse( "","Duyệt sân thành công" 
            , HttpContext.TraceIdentifier));
    }
    
}