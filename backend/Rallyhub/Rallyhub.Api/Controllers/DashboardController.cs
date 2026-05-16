using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Dashboard;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class DashboardController: ControllerBase
{
    private readonly Service.Dashboard.IService _dashboardService;

    public DashboardController(IService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("DashboardAdmin")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> DashboardAdmin([FromQuery] string period = "Day")
    {
        var result = await _dashboardService.DashboardAdmin(period);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "Dashboard Admin", HttpContext.TraceIdentifier));
    }
    // [HttpGet("DashboardOwner")]
    // [Authorize(Policy = JwtExtensions.OwnerPolicy)]
    // public async Task<IActionResult> DashboardOwner()
    // {
    //     var result = await _dashboardService.DashboardOwner();
    //     return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "Dashboard Admin", HttpContext.TraceIdentifier));
    // }
}