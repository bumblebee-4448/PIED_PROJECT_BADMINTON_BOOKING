using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Booking;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;
//
[ApiController]
[Route("[controller]")]
[Authorize]
public class BookingController: ControllerBase
{
    private readonly IService _bookingService;

    public BookingController(IService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("CreateBooking")]
    public async Task<IActionResult> CreateBooking([FromBody] Request.CreateBookingRequest request)
    {
        var result = await _bookingService.CreateBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    [HttpPost("GetBookingDetail")]
    public async Task<IActionResult> GetBookingDetail(Guid bookingDetailsId)
    {
        var result = await _bookingService.GetBookingDetail(bookingDetailsId);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpPost("CreateBookingByWallet")]
    public async Task<IActionResult> CreateBookingByWallet([FromBody] Request.CreateBookingRequest request)
    {
        var result = await _bookingService.CreateBookingByWallet(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("BookingRefund")]
    public async Task<IActionResult> BookingRefund(Guid bookingId)
    {
        var result = await _bookingService.BookingRefund(bookingId);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("CancelBooking")]
    public async Task<IActionResult> CancelBooking(Guid bookingId)
    {
        var result = await _bookingService.CanCelBooking(bookingId);
        return Ok(ApiResponseFactory.SuccessResponse(result,"Success you!", HttpContext.TraceIdentifier));
    }
    [HttpGet("GetBooking")]
    public async Task<IActionResult> GetBooking([FromQuery] Service.Base.Request.PagingDay2 pagingDay2)
    {
        var result = await _bookingService.GetBooking(pagingDay2);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
}