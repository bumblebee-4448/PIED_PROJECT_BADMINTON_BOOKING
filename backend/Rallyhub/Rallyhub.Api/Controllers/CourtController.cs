using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Court;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class CourtController: ControllerBase
{
    private readonly IService _courtService;

    public CourtController(IService courtService)
    {
        _courtService = courtService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCourtsByFilter([FromQuery] Request.SearchByFilterRequest request)
    {
        var result = await _courtService.SearchByFilter(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
}