using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Models;
using MapService = Rallyhub.Service.MapService;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController : ControllerBase
{
    private readonly MapService.IService _mapService;

    public MapController(MapService.IService mapService)
    {
        _mapService = mapService;
    }

    [HttpGet("boxing-box")]
    public async Task<IActionResult> SearchByBoundingBox(
        [FromQuery] MapService.BoundingBoxRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mapService.SearchByBoundingBox(request, cancellationToken);
        return Ok(ApiResponseFactory.SuccessResponse(result,"Success",HttpContext.TraceIdentifier));  
    }

    [HttpGet("radius")]
    public async Task<IActionResult> SearchByRadius(
        [FromQuery] MapService.RadiusRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _mapService.SearchByRadius(request, cancellationToken);
        return Ok(ApiResponseFactory.SuccessResponse(result,"Success",HttpContext.TraceIdentifier));
    }
}