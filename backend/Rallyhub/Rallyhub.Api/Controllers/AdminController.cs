using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Admin;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;

[Authorize(Policy = JwtExtensions.AdminPolicy)]
[Route("[controller]")]
public class AdminController: ControllerBase
{
    private readonly IService _adminService;

    public AdminController(IService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("FilterUser")]
    public async Task<IActionResult> FilterUser ([FromQuery]Request.FilterUserRequest request)
    {
        var result = await _adminService.FilterUser(request);
        return Ok(ApiResponseFactory.SuccessResponse
            (result, "Success you!", HttpContext.TraceIdentifier));
    }

    [HttpGet("UserDetailById")]
    public async Task<IActionResult> UserDetail([FromQuery]Request.UserDetailRequest  request)
    {
        var result = await _adminService.UserDetail(request);
        return Ok(ApiResponseFactory.SuccessResponse
            (result, "Success you!",  HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetOwnerRequest")]
    public async Task<IActionResult> AdminGetOwnerRequest([FromQuery]Service.Base.Request.Pagination request)
    {
        var result = await _adminService.AdminGetOwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpPost("AcceptCreateOwner")]
    public async Task<IActionResult> AdminAcceptOwnerRequest([FromQuery]Guid ownerRequestId)
    {
        var result = await _adminService.AdminApprovedOwnerRequest(ownerRequestId);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpPatch("RejectCreateOwner")]
    public async Task<IActionResult> AdminRejectOwnerRequest([FromQuery]Guid ownerRequestId, [FromQuery]string? rejectReason)
    {
        var result = await _adminService.AdminRejectOwnerRequest(ownerRequestId, rejectReason);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    [HttpDelete("DeleteCourt/{id}")]
    public async Task<IActionResult> DeleteCourt(Guid id)
    {
        await _adminService.DeleteCourt(id);
        return Ok(ApiResponseFactory.SuccessResponse
            ("Success you!",HttpContext.TraceIdentifier));
    }
    [HttpPatch("BanAndUnbanUser")]
    public async Task<IActionResult> BanAndUnbanUser([FromBody]Request.BanAndUnbanUserRequest request)
    {
        await _adminService.BanAndUnbanUser(request);
        return Ok(ApiResponseFactory.SuccessResponse
            ("Success you!",HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetAllPendingCourts")]  
    public async Task<IActionResult> AdminGetAllPendingCourts([FromQuery]Service.Base.Request.Pagination request )  
    {  
        var result = await _adminService.AdminGetPendingCourts(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success you!", HttpContext.TraceIdentifier));  
    }  
  
    [HttpPatch("RejectPendingCourt/{courtId}")]  
    public async Task<IActionResult> AdminRejectPendingCourt([FromRoute]Guid courtId, [FromQuery]string? reasonReject)  
    {  
        var result = await _adminService.AdminRejectPendingCourt(courtId, reasonReject);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success you!", HttpContext.TraceIdentifier));  
    }  
  
    [HttpPatch("ApprovePendingCourt/{courtId}")]  
    public async Task<IActionResult> AdminApprovePendingCourt([FromRoute]Guid courtId)  
    {  
        var result = await _adminService.AdminApprovePendingCourt(courtId);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Success you!"
            , HttpContext.TraceIdentifier));  
    }
    
    [HttpGet("GetWallet")]
    public async Task<IActionResult> GetWallet([FromQuery]Request.GetWalletRequest request)
    {
        var result = await _adminService.GetWallet(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    [HttpGet("GetBookingDetailStatusRefundPending")]
    public async Task<IActionResult> GetBookingDetailStatusRefundPending()
    {
        var result = await _adminService.GetBookingDetailStatusRefundPending();
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }

    [HttpPost("AddBalanceToUser")]
    public async Task<IActionResult> AddBalanceToUser([FromBody] Request.AddBalanceRequest request)
    {
        var result = await _adminService.AddBalanceToUser(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
}