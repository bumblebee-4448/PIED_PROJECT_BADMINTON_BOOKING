using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Customer;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;


[ApiController]
[Authorize(Policy = JwtExtensions.CustomerPolicy)]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IService _customerService;

    public CustomerController(IService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("OwnerRequest")]
    public async Task<IActionResult> OwnerRequest([FromForm]Request.OwnerRequestRequest model)
    {

        var result = await _customerService.OwnerRequest(model);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }

    [HttpGet("GetOwnerRequest")]
    public async Task<IActionResult> GetOwnerRequest([FromQuery] Service.Base.Request.PagingRequest request)
    {

        var result = await _customerService.GetOwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }

    // [HttpPost("CheckCancelBooking")]
    // public async Task<IActionResult> CheckCancelBooking(Request.CancelBooking request)
    // {
    //     var result = await _customerService.CheckCancelBooking(request);
    //     return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    // }

    // [HttpPatch("CancelBooking")]
    // public async Task<IActionResult> CheckCancel(Request.CancelBooking request)
    // {
    //     await _customerService.CancelBooking(request);
    //     return Ok(ApiResponseFactory.SuccessResponse("Success you!", HttpContext.TraceIdentifier));
    // }
    
   

    [HttpGet("GetAllLikeList")]
    public async Task<IActionResult> GetAllLikeList([FromQuery] Service.Base.Request.PagingRequest request)
    {
        var result = await _customerService.GetAllLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!",  HttpContext.TraceIdentifier));
    }

    [HttpPost("AddCourtLikeList")]
    public async Task<IActionResult> AddCourtLikeList([FromBody]Request.AddCourtLikeListRequest request)
    {
        await _customerService.AddCourtLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse("Success you!", HttpContext.TraceIdentifier));
    }

    [HttpDelete("DeleteCourtLikeList")]
    public async Task<IActionResult> DeleteCourtLikeList(Request.DeteleCourtLikeListRequest request)
    {
        await _customerService.DeleteCourtLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse("Success you!", HttpContext.TraceIdentifier));
    }

    [HttpGet("GetAllBooking")]
    public async Task<IActionResult> GetAllBooking([FromQuery] Service.Base.Request.PagingRequest request)
    {
        var result = await _customerService.GetAllBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    
}