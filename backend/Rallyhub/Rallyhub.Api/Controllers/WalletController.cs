using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Models;
using Rallyhub.Service.Wallet;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WalletController : ControllerBase
{
    private readonly IService _walletService;
    public WalletController(IService walletService)
    {
        _walletService = walletService;
    }

    [HttpPatch("addInforWallet")]
    public async Task<IActionResult> AddInforWallet([FromBody] Request.AddInforWalletRequest request)
    {
        var result = await _walletService.AddInforWallet(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success add infor wallet", HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetInforWallet")]
    public async Task<IActionResult> GetInforWallet()
    {
        var result = await _walletService.GetInforWallet();
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success remove bank wallet", HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("RemoveBankWallet")]
    public async Task<IActionResult> RemoveBankWallet()
    {
        var result = await _walletService.RemoveBankWallet();
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success remove bank wallet", HttpContext.TraceIdentifier));
    }
    
    
}