using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Models;
using Rallyhub.Service.SystemReport;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class SystemReportController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.SystemReport.IService _systemReportService;
    public SystemReportController(AppDbContext dbContext, IService systemReportService)
    {
        _dbContext = dbContext;
        _systemReportService = systemReportService;
    }

    [HttpPost("")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    public async Task<IActionResult> CreateSystemReport(Request.CreateSystemReportRequest request)
    {
        await _systemReportService.CreateSystemReport(request);
        return Ok(ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));
    }
    [HttpGet("")]
    [Authorize]
    public async Task<IActionResult> GetSystemReport ([FromQuery]Request.GetSystemReportRequest request)
    {
        var result = await _systemReportService.GetSystemReport(request);
        return Ok(ApiResponseFactory.SuccessResponse
            (result, "Success you!", HttpContext.TraceIdentifier));
    }
    [HttpPatch("")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> SubmitReportReply(Request.SubmitReportReplyRequest request)
    {
        await _systemReportService.SubmitReportReply(request);
        return Ok(ApiResponseFactory.SuccessResponse("success", HttpContext.TraceIdentifier));
    }
}