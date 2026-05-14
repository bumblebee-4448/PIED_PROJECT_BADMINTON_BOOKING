using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
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
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpPatch("AddInforWallet")]
    public async Task<IActionResult> AddInforWallet([FromBody] Request.AddInforWalletRequest request)
    {
        var result = await _walletService.AddInforWallet(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success add infor wallet", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpGet("GetInforWallet")]
    public async Task<IActionResult> GetInforWallet()
    {
        var result = await _walletService.GetInforWallet();
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success get infor wallet", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpPatch("RemoveBankWallet")]
    public async Task<IActionResult> RemoveBankWallet()
    {
        var result = await _walletService.RemoveBankWallet();
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success remove bank wallet", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpPatch("AddBalanceToWalletFromPayment")]
    public async Task<IActionResult> AddBalanceToWalletFromPayment([FromBody]decimal requestAmount)
    {
        var result = await _walletService.AddBalanceToWalletFromPayment(requestAmount);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success add money", HttpContext.TraceIdentifier));
    }
    
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpPatch("AdminUpBalanceForUser")]
    public async Task<IActionResult> AdminUpBalanceForUser([FromBody] Guid userId, decimal amount, string? description)
    {
        var result = await _walletService.AdminUpBalanceForUser(userId, amount, description);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success AdminDeduct wallet", HttpContext.TraceIdentifier));
    }

    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    [HttpGet("CheckDepositStatus/{transactionId}")]
    public async Task<IActionResult> CheckDepositStatus(Guid transactionId)
    {
        var result = await _walletService.CheckDepositStatus(transactionId);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success check status", HttpContext.TraceIdentifier));
    }
}