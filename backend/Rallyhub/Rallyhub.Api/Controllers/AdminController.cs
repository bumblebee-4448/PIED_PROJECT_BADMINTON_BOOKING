using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Admin;
using Rallyhub.Service.Models;
using Enum = Rallyhub.Service.Enum.Enum;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AdminController: ControllerBase
{
    private readonly IService _adminService;

    public AdminController(IService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("getAllUser")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> FilterUser
        (string? search, Guid? id, Enum.Role? role, Enum.StatusUsers? status, int pageIndex = 1, int pageSize = 10)
    {
        var result = await _adminService.FilterUser(search, id, role, status, pageIndex, pageSize);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            (result, "Danh sách user", HttpContext.TraceIdentifier));
    }

    [HttpGet("getUserDetailById/{id}")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> UserDetail(Guid id)
    {
        var result = await _adminService.UserDetail(id);
        return Ok(ApiResponseFactory.SuccessResponse
            (result, $"Thông tin chi tiết của user {id}",  HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetOwnerRequest")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> AdminGetOwnerRequest([FromQuery]Service.Base.Request.Pagination request)
    {
        var result = await _adminService.AdminGetOwnerRequest(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpGet("AcceptCreateOwner")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> AdminAcceptOwnerRequest(Guid ownerRequestId)
    {
        
        var result = await _adminService.AdminAcceptOwnerRequest(ownerRequestId);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    
    [HttpGet("RejectCreateOwner")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason)
    {
        
        var result = await _adminService.AdminRejectOwnerRequest(ownerRequestId, rejectReason);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Success you!", HttpContext.TraceIdentifier));
    }
    [HttpDelete("DeleteCourt/{id}")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> DeleteCourt(Guid id)
    {
        await _adminService.DeleteCourt(id);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            ($"Xóa sân thành công",HttpContext.TraceIdentifier));
    }
    [HttpPatch("UpdateStatusUser")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> UpdateStatusUser(Service.Admin.Request.UpdateStatusUserResponse request)
    {
        await _adminService.UpdateStatusUser(request);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            ($"Update status thành công",HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetAllPendingCourts")]  
    public async Task<IActionResult> GetAllPendingCourts([FromQuery] Request.GetPendingCourtsRequest request)  
    {  
        var result = await _adminService.GetPendingCourts(request);  
        return Ok(ApiResponseFactory.SuccessResponse( result,"Lấy tất cả các sân ở trạng thái Pending thành công"   
            , HttpContext.TraceIdentifier));  
    }  
  
    [HttpPatch("RejectPendingCourt/{courtId}")]  
    public async Task<IActionResult> RejectPendingCourt(Guid courtId,  [FromBody] Request.RejectPendingCourtsRequest request)  
    {  
        await _adminService.RejectPendingCourt(courtId, request);  
        return Ok(ApiResponseFactory.SuccessResponse( "","Từ chối thành công"   
            , HttpContext.TraceIdentifier));  
    }  
  
    [HttpPatch("ApprovePendingCourt/{courtId}")]  
    public async Task<IActionResult> ApprovePendingCourt(Guid courtId)  
    {  
        await _adminService.ApprovePendingCourt(courtId);  
        return Ok(ApiResponseFactory.SuccessResponse( "","Duyệt sân thành công"   
            , HttpContext.TraceIdentifier));  
    }

    [HttpPatch("Refund")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> Refund(Request.RefundRequest request)
    {
        var result = await _adminService.Refund(request);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Refund Success", HttpContext.TraceIdentifier));
    }
    [HttpGet("GetWallet")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> GetWallet(string email)
    {
        var result = await _adminService.GetWallet(email);
        return Ok(ApiResponseFactory.SuccessResponse(result, "Thông tin ví của user", HttpContext.TraceIdentifier));
    }
}