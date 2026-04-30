using Microsoft.AspNetCore.Mvc;
using Rallyhub.Repository;

namespace Rallyhub.Api.Controllers;
//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserManagement_AdminController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Admin.UserManagement.IService _adminService;

    public UserManagement_AdminController(AppDbContext dbContext, Service.Admin.UserManagement.IService adminService)
    {
        _dbContext = dbContext;
        _adminService = adminService;
    }

    [HttpGet("")]
    public async Task<IActionResult> getUser(string? search, int pageIndex, int pageSize, Guid? id, Service.Enum.Enum.Role? role, Service.Enum.Enum.StatusUsers? status)
    {
        var result = await _adminService.GetUsers(search, pageIndex, pageSize, id, role, status);
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