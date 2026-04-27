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
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCourt([FromBody] Request.CreateCourtRequest request)
    {
        var result = await _courtService.CreateCourt(request);
        return Ok(ApiResponseFactory.SuccessResponse("", result, HttpContext.TraceIdentifier));
    }
}