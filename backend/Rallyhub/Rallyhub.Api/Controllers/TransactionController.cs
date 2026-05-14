using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Models;
using Rallyhub.Service.Transaction;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly IService _transactionService;
    public TransactionController(IService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpGet("GetTransaction")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    public async Task<IActionResult> GetTransaction([FromQuery] Service.Base.Request.PagingDay paginDay)
    {
        var result = await _transactionService.GetTransaction(paginDay);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success", HttpContext.TraceIdentifier));
    }
    
    [HttpGet("AdminGetTransaction")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> AdminGetTransaction([FromQuery] Guid? userId, [FromQuery] Service.Base.Request.PagingDay paginDay)
    {
        var result = await _transactionService.AdminGetTransaction(userId, paginDay);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success", HttpContext.TraceIdentifier));
    }
}