using Microsoft.AspNetCore.Mvc;
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

    // [HttpPost("WithdrawalRequest")]
    // public Task<IActionResult> CreateWithdrawalRequest()
    // {
    //     return Ok()
    // }
}