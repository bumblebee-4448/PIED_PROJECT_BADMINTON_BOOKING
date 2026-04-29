using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Models;
using Rallyhub.Service.Owner;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnerController: ControllerBase
{
    private readonly IService _ownerService;
    
    public OwnerController(IService ownerService)
    {
        _ownerService = ownerService;
    }
        
    [HttpPost("CreateCourt")]
    public async Task<IActionResult> CreateCourt(Request.CreateCourtRequest request)
    {
        var result = await _ownerService.CreateCourt(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Tạo sân thành công, đang chờ Admin duyệt" 
            , HttpContext.TraceIdentifier));
    }
    
    [HttpGet("GetMyCourts")]
    public async Task<IActionResult> GetAllCourts([FromQuery] Request.GetMyCourtsRequest request)
    {
        var result = await _ownerService.GetAllCourts(request);
        return Ok(ApiResponseFactory.SuccessResponse( result,"Danh sách tất cả các sân" 
            , HttpContext.TraceIdentifier));
    }

}