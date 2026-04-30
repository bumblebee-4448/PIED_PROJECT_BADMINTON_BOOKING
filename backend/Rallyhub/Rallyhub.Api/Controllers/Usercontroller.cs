using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
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

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterTask(Request.RegisterRequest request)
    {
        string result = await _identityService.RegisterTask(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success, check mail to verify otp", HttpContext.TraceIdentifier));
    }
    
    [HttpPost("Verify-otp")]
    public async Task<IActionResult> VerifyOtp(Service.IdentityService.Request.VerifyOtpRequest request)
    {
        var result = await _identityService.VerifyOtp(request.Email, request.OtpCode);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success register", HttpContext.TraceIdentifier));
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(Service.IdentityService.Request.LoginRequest request)
    {
        var result = await _identityService.Login(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Welcome", HttpContext.TraceIdentifier));
    }
    
    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var authHeader = Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            return BadRequest(new { Message = "Không tìm thấy Token để đăng xuất." });
        }
        var token = authHeader.Substring("Bearer ".Length).Trim();

        string result = await _identityService.Logout(token);

        return Ok(ApiResponseFactory.SuccessResponse(result, "Thank you!", HttpContext.TraceIdentifier));
    }
}