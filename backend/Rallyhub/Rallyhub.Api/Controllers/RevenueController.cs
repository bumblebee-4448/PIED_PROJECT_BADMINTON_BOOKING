using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Models;
using Rallyhub.Service.Revenue;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rallyhub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpGet("owner")]
        [Authorize(Policy = JwtExtensions.OwnerPolicy)]
        public async Task<IActionResult> GetOwnerRevenue(
            [FromQuery] DateTime? startDate, 
            [FromQuery] DateTime? endDate, 
            [FromQuery] Guid? courtId)
        {
            var ownerIdClaim = User.Claims.FirstOrDefault(x => x.Type == "OwnerId")?.Value;
            if (string.IsNullOrEmpty(ownerIdClaim)) 
            {
                return Unauthorized(ApiResponseFactory.ErrorResponse("Không tìm thấy thông tin Owner", HttpContext.TraceIdentifier));
            }
            
            if (!Guid.TryParse(ownerIdClaim, out var ownerId))
            {
                return BadRequest(ApiResponseFactory.ErrorResponse("OwnerId không hợp lệ", HttpContext.TraceIdentifier));
            }
            
            var result = await _revenueService.GetOwnerRevenue(ownerId, startDate, endDate, courtId);
            return Ok(ApiResponseFactory.SuccessResponse(result, "Lấy dữ liệu doanh thu thành công", HttpContext.TraceIdentifier));
        }
    }
}
