using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Repository;
using Rallyhub.Service.Admin;

namespace Rallyhub.Api.Controllers;
//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AdminController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Admin.IService _adminService;

    public AdminController(AppDbContext dbContext, IService adminService)
    {
        _dbContext = dbContext;
        _adminService = adminService;
    }

    [HttpGet("")]
    public async Task<IActionResult> getUser(string? searchTmp,
        int pageIndex,
        int pageSize,
        Guid? id,
        Service.Enum.Enum.Role? role,
        Service.Enum.Enum.StatusUsers? status)
    {
        var result = await _adminService.GetUsers
                                        (searchTmp, pageIndex, pageSize, id, role, status);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            (result, "Danh sách user", HttpContext.TraceIdentifier));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _adminService.GetUserById(id);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            (result, $"Thông tin chi tiết của user {id}",  HttpContext.TraceIdentifier));
    }

    
}