using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Dashboard;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Response.DashboardAdminResponse> DashboardAdmin()
    {
        return new Response.DashboardAdminResponse()
        {
            TotalAmount = await  _dbContext.Bookings.Where(x => x.Status == "Completed").SumAsync(y => y.FinalPrice),
            TotalUsers = await _dbContext.Users.CountAsync(x => x.IsDeleted == false),
            TotalCourtActive = await _dbContext.Courts.CountAsync(x => x.Status == "Active"),
        };
    }
}