using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Booking;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController: ControllerBase
{
    private readonly IService _bookingService;

    public BookingController(IService bookingService)
    {
        _bookingService = bookingService;
    }
    
    [HttpGet("GetAvailableSlots")]
    public async Task<IActionResult> GetAvailableSlots([FromQuery] Request.GetAvailableSlotsRequest request)
    {
        var result = await _bookingService.GetAvailableSlots(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
    [HttpPost("BookingSlots")]
    public async Task<IActionResult> BookingSlot([FromBody] Request.HoldBookingRequest request)
    {
        var result = await _bookingService.HoodBooking(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success" 
            , HttpContext.TraceIdentifier));
    }
}