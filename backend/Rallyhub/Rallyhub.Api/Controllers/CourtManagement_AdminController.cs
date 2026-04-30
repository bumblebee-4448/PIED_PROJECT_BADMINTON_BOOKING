using Microsoft.AspNetCore.Mvc;
using Rallyhub.Repository;

namespace Rallyhub.Api.Controllers;
//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CourtManagement_AdminController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly Service.Admin.CourtManagement.IService _adminService;

    public CourtManagement_AdminController(AppDbContext dbContext, Service.Admin.CourtManagement.IService adminService)
    {
        _dbContext = dbContext;
        _adminService = adminService;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourt(Guid id)
    {
        await _adminService.DeleteCourt(id);
        return Ok(Service.Models.ApiResponseFactory.SuccessResponse
            ($"Xóa sân thành công",HttpContext.TraceIdentifier));
    }
}