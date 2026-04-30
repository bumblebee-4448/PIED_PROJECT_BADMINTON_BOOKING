using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Admin.CourtManagement;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task DeleteCourt(Guid id)
    {
        // var roleAdmin = _httpContextAccessor.HttpContext.User.Claims
        //                         .FirstOrDefault(x => x.Type == "Role")?.Value;
        // if (roleAdmin != Enum.Enum.Role.Admin.ToString())
        // {
        //     throw new Exception("Bạn không được ủy quyền");
        // }
        var court = await  _dbContext.Courts.FirstOrDefaultAsync(x => x.Id == id);
        if (court == null)
        {
            throw new Exception("Không tìm thấy sân");
        }
        _dbContext.Courts.Remove(court);
        await _dbContext.SaveChangesAsync();
    }
}