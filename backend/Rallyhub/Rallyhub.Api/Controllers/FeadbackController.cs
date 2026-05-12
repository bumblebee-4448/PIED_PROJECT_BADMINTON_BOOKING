using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Feadback;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FeadbackController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Feadback.IService _feadbackService;

    public FeadbackController(AppDbContext dbContext, IService feadbackService)
    {
        _dbContext = dbContext;
        _feadbackService = feadbackService;
    }

    [HttpPost("Feadback")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CreateFeadback(Request.CreateFeadbackRequest request)
    {
        await _feadbackService.CreateFeadback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("feadback success", HttpContext.TraceIdentifier));
    }
    [HttpGet("Feadback")]
    // [Authorize(Policy = JwtExtensions.OwnerPolicy)]
    public async Task<IActionResult> GetFeadback([FromQuery]Request.GetFeadbackRequest request)
    {
        var result = await _feadbackService.GetFeadback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "feadback success", HttpContext.TraceIdentifier));
    }
}