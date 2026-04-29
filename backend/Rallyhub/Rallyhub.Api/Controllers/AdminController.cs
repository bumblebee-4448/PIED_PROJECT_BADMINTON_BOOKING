using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Admin;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

[ApiController]
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
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    
}