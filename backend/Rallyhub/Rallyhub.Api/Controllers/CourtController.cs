using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Court;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

//[ApiController]
//[Authorize(Policy = JwtExtensions.CustomerPolicy)]
[Route("[controller]")]
public class CourtController: ControllerBase
{
    private readonly IService _courtService;

    public CourtController(IService courtService)
    {
        _courtService = courtService;
    }

    [HttpGet("GetByFilters")]
    public async Task<IActionResult> GetCourtsByFilter([FromQuery] Request.SearchByFilterRequest request)
    {
        var result = await _courtService.SearchByFilter(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetCourtDetailsById{courtId}")]
    public async Task<IActionResult> GetCourtsById([FromRoute] Guid courtId)
    {
        var result = await _courtService.GetCourtsDetailById(courtId);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetSubCourt{courtId}")]
    public async Task<IActionResult> GetSubCourt([FromRoute] Guid courtId)
    {
        var result = await _courtService.GetSubCourtById(courtId);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
}