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
    public async Task<IActionResult> GetOwnerRequest([FromQuery] Request.GetOwnerRequest request)
    {

        var result = await _customerService.GetOwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }

    [HttpPost("CheckCancelBooking")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CheckCancelBooking(Request.CancelBooking request)
    {
        var result = await _customerService.CheckCancelBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Check Success", HttpContext.TraceIdentifier));
    }

    [HttpPatch("CancelBooking")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> CheckCancel(Request.CancelBooking request)
    {
        await _customerService.CancelBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse("Cancel booking Success", HttpContext.TraceIdentifier));
    }

    [HttpGet("GetAllLikeList")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> GetAllLikeList([FromQuery] Request.LikeListDetailRequest request)
    {
        var result = await _customerService.GetAllLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Danh sách yêu thích",  HttpContext.TraceIdentifier));
    }

    [HttpPost("AddCourtLikeList")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> AddCourtLikeList(Request.AddCourtLikeListRequest request)
    {
        await _customerService.AddCourtLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse("Add Success", HttpContext.TraceIdentifier));
    }

    [HttpDelete("DeleteCourtLikeList")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> DeleteCourtLikeList(Request.DeteleCourtLikeListRequest request)
    {
        await _customerService.DeleteCourtLikeList(request);
        return Ok(ApiResponseFactory.SuccessResponse("Delete Success", HttpContext.TraceIdentifier));
    }

    [HttpGet("GetAllBooking")]
    [Authorize(Policy = JwtExtensions.CustomerPolicy)]
    public async Task<IActionResult> GetAllBooking([FromQuery] Request.GetAllBookingRequest request)
    {
        var result = await _customerService.GetAllBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "List Booking", HttpContext.TraceIdentifier));
    }
}