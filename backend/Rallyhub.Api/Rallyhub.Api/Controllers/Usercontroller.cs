using Microsoft.AspNetCore.Mvc;
using Rallyhub.Repository.Entity;
using Rallyhub.Service.Models;
using Rallyhub.Service.User;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Usercontroller : ControllerBase
{
    private readonly IService _userService;
    private readonly Service.IdentityService.IService _identityService;
    public Usercontroller(IService userService,  Service.IdentityService.IService identityService)
    {
        _userService = userService;
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterTask(Request.RegisterRequest request)
    {
        string message = await _identityService.RegisterTask(request);
        return Ok(ApiResponseFactory.SuccessResponse(message, "Nhập otp", HttpContext.TraceIdentifier));
    }
    
    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] Service.IdentityService.Request.VerifyOtpRequest request)
    {
        await _identityService.VerifyOtp(request.Email, request.OtpCode);
        return Ok(new { Success = true, Message = "Đăng ký thành công! Bạn có thể đăng nhập." });
    }
}