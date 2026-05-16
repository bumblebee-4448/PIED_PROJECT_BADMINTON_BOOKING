using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Notification;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IService _Note;
    public NotificationController(IService note)
    {
        _Note = note;
    }
    
    [HttpGet("GetNotification")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerPolicy)]
    public async Task<IActionResult> GetNotification([FromQuery]Service.Base.Request.PagingRequest request)
    {
        var result = await _Note.GetNotification(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "get notification success", HttpContext.TraceIdentifier));
    }

    [HttpGet("AdminGetNotification")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> AdminGetNotification([FromQuery]Service.Base.Request.PagingRequest request)
    {
        var result = await _Note.AdminGetNotification(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "get admin notification success", HttpContext.TraceIdentifier));
    }

    [HttpPut("ReadNotification/{id}")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerOrAdminPolicy)]
    public async Task<IActionResult> ReadNotification(Guid id)
    {
        var result = await _Note.ReadNotification(id);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "read notification success", HttpContext.TraceIdentifier));
    }

    [HttpGet("GetUnreadCount")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerOrAdminPolicy)]
    public async Task<IActionResult> GetUnreadCount()
    {
        var result = await _Note.GetUnreadCount();
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "get unread count success", HttpContext.TraceIdentifier));
    }

    [HttpDelete("DeleteNotification/{id}")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerOrAdminPolicy)]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        var result = await _Note.DeleteNotification(id);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(null, result, HttpContext.TraceIdentifier));
    }
    
    [HttpDelete("DeleteAllRead")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerOrAdminPolicy)]
    public async Task<IActionResult> DeleteAllRead()
    {
        var result = await _Note.DeleteAllRead();
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(null, result, HttpContext.TraceIdentifier));
    }
    [HttpPut("MarkAllAsRead")]
    [Authorize(Policy = JwtExtensions.CustomerOrOwnerOrAdminPolicy)]
    public async Task<IActionResult> MarkAllAsRead()
    {
        var result = await _Note.MarkAllAsRead();
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse(result, "mark all as read success", HttpContext.TraceIdentifier));
    }
}