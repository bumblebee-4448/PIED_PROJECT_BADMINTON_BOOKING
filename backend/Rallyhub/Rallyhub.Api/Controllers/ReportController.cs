using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Report;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ReportController: ControllerBase
{
    private readonly Service.Report.IService _reportService;

    public ReportController(IService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost("CreateReportBookings")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CreateReportBookings(Request.CreateReportBookingsRequest request)
    {
        await _reportService.CreateReportBookings(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));
    }
    [HttpGet("GetReportBookings")]
    [Authorize]
    public async Task<IActionResult> GetReportBookings([FromQuery]Request.GetReportBookingsRequest request)
    {
        var result = await _reportService.GetReportBookings(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"Create success", HttpContext.TraceIdentifier));
    }
    [HttpPatch("ConfirmReport")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> ConfirmReport(Request.ConfirmReportRequest request)
    {
        await _reportService.ConfirmReport(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));
    }
}