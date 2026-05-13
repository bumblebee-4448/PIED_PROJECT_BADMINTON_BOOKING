using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Feadback;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class FeedbackController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Feadback.IService _feadbackService;

    public FeedbackController(AppDbContext dbContext, IService feadbackService)
    {
        _dbContext = dbContext;
        _feadbackService = feadbackService;
    }

    [HttpPost("")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CreateFeadback(Request.CreateFeedbackRequest request)
    {
        await _feadbackService.CreateFeedback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("feadback success", HttpContext.TraceIdentifier));
    }
    [HttpGet("")]
    // [Authorize(Policy = JwtExtensions.OwnerPolicy)]
    public async Task<IActionResult> GetFeadback([FromQuery]Request.GetFeedbackRequest request)
    {
        var result = await _feadbackService.GetFeedback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "feadback success", HttpContext.TraceIdentifier));
    }

    [HttpPatch("")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> UpdateFeadback(Request.UpdateFeedbackRequest request)
    {
        await _feadbackService.UpdateFeeback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("update feadback success", HttpContext.TraceIdentifier));
    }
    [HttpDelete("")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> DeleteFeadback(Request.DeteteFeedbackRequest request)
    {
        await _feadbackService.DeteteFeedback(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("delete feadback success", HttpContext.TraceIdentifier));
    }
}