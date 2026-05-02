using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Quartz.Util;
using Rallyhub.Repository;
using Rallyhub.Repository.Entity;
using Exception = System.Exception;

namespace Rallyhub.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task UpdateProfile(Request.UpdateProfile request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        var userId = Guid.Parse(getUserId!);
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        user!.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;
        user.UpdatedAt = DateTimeOffset.Now;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}