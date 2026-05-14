using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Models;
using Rallyhub.Service.Withdrawal;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WithdrawalController : ControllerBase
{
    private readonly IService _withdrawalService;

    public WithdrawalController(IService withdrawalService)
    {
        _withdrawalService = withdrawalService;
    }
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpPost("WithdrawalRequest")]
    public async Task<IActionResult> CreateWithdrawalRequest([FromBody]Request.CreateWithdrawalRequest request)
    {
        var result = await _withdrawalService.CreateWithdrawalRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success invite withdrawal", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpGet("AdminGetWithdrawalRequest")]
    public async Task<IActionResult> AdminGetWithdrawalRequest([FromQuery] Guid? userId, [FromQuery]
        Service.Base.Request.PagingDay pagination)
    {
        var result = await _withdrawalService.AdminGetWithdrawalRequest(userId, pagination);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success get all withdrawal", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpPost("AdminApprovedWithdrawalRequest")]
    public async Task<IActionResult> AdminApprovedWithdrawalRequest([FromBody]Guid withdrawalRequestId)
    {
        var result = await _withdrawalService.AdminApprovedWithdrawalRequest(withdrawalRequestId);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success approved withdrawal", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpPost("AdminRejectWithdrawalRequest")]
    public async Task<IActionResult> AdminRejectWithdrawalRequest([FromBody]Request.RejectWithdrawalRequest request)
    {
        var result = await _withdrawalService.AdminRejectWithdrawalRequest(request.WithdrawalRequestId, request.Reason, request.Note);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success reject withdrawal", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpGet("GetWithdrawalRequest")]
    public async Task<IActionResult> GetWithdrawalRequest([FromQuery]Service.Base.Request.PagingDay pagination)
    {
        var result = await _withdrawalService.GetWithdrawalRequest(pagination);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success get withdrawal", HttpContext.TraceIdentifier));
    }

}