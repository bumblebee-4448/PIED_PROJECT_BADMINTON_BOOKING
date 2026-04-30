using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Customer;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IService _customerService;

    public CustomerController(IService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("OwnerRequest")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> OwnerRequest(Request.OwnerRequestRequest request)
    {
        
        var result = await _customerService.OwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetOwnerRequest")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> GetOwnerRequest([FromQuery]Request.GetOwnerRequest request)
    {
        
        var result = await _customerService.GetOwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
}