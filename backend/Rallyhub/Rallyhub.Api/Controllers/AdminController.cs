using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Repository;
using Rallyhub.Service.Admin;
using Rallyhub.Service.Models;

namespace Rallyhub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AdminController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IService _adminService;

    public AdminController(AppDbContext dbContext, IService adminService)
    {
        _dbContext = dbContext;
        _adminService = adminService;
    }

    [HttpGet("getAllUser")]
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    public async Task<IActionResult> FilterUser(string? search, int pageIndex, int pageSize, Guid? id, Service.Enum.Enum.Role? role, Service.Enum.Enum.StatusUsers? status)
    {
        var result = await _adminService.FilterUser(search, pageIndex, pageSize, id, role, status);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            (result, "Danh sách user", HttpContext.TraceIdentifier));
    }

    [HttpGet("getUserById/{id}")]
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
}