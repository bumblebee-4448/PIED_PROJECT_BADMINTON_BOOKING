using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Campaign;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CampaignController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Campaign.IService _campaignService;

    public CampaignController(AppDbContext dbContext, IService campaignService)
    {
        _dbContext = dbContext;
        _campaignService = campaignService;
    }

    [HttpPost("")]
    [Authorize(Policy = JwtExtensions.OwnerOrAdminPolicy)]
    public async Task<IActionResult> CreateCampaign(Request.CreateCampaignRequest request)
    {
        await _campaignService.CreateCampaign(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));
    }
    [HttpPost("CampaignCourt")]
    [Authorize(Policy = JwtExtensions.OwnerPolicy)]
    public async Task<IActionResult> CreateCampaignCourt(Request.CreateCampaignCourtRequest request)
    {
        await _campaignService.CreateCampaignCourt(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Create success", HttpContext.TraceIdentifier));
    }
    [HttpPut("")]
    [Authorize(Policy = JwtExtensions.OwnerOrAdminPolicy)]
    public async Task<IActionResult> UpdateCampaign(Request.UpdateCampaignRequest request)
    {
        await _campaignService.UpdateCampaign(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse("Update success", HttpContext.TraceIdentifier));
    }

    [HttpGet("Admin/Campaign")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> GetCampaign([FromQuery] Service.Base.Request.PagingRequest request)
    {
        var result = await _campaignService.GetAllCampaign(request);
        return  Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"List Campagin", HttpContext.TraceIdentifier));
    }
    [HttpGet("Owner/CampaignCourt")]
    [Authorize(Policy = JwtExtensions.OwnerPolicy)]
    public async Task<IActionResult> GetAllCampaignCourt([FromQuery] Service.Base.Request.PagingRequest request)
    {
        var result = await _campaignService.GetAllCampaignCourt(request);
        return  Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"List Campagin", HttpContext.TraceIdentifier));
    }
    [HttpGet("Customer/Campaign")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CampaignByCourt([FromQuery] Request.GetCampaignByCourtRequest request)
    {
        var result = await _campaignService.CampaignByCourt(request);
        return  Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"List Campagin", HttpContext.TraceIdentifier));
    }
    [HttpGet("CampaignDetail")]
    [Authorize(Policy = JwtExtensions.OwnerOrAdminPolicy)]
    public async Task<IActionResult> GetCampaignDetail([FromQuery] Request.CampaignDetailRequest request)
    {
        var result = await _campaignService.CampaignDetail(request);
        return  Ok(Service.Models.ApiResponseFactory.SuccessResponse(result,"Campagin Detail", HttpContext.TraceIdentifier));
    }
    [HttpDelete("")]
    [Authorize(Policy = JwtExtensions.OwnerOrAdminPolicy)]
    public async Task<IActionResult> DeleteCampaign(Request.DeleteCampaignRequest request)
    {
       await _campaignService.DeleteCampaign(request);
        return  Ok(Service.Models.ApiResponseFactory.SuccessResponse("Delete Campagin success", HttpContext.TraceIdentifier));
    }
}