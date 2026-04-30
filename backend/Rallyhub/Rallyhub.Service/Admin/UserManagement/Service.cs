using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Admin.UserManagement;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Base.Response.PageResult<Response.UserDto>>
        GetUsers(string? search, int pageIndex, int pageSize, Guid? id, Enum.Enum.Role? role, Enum.Enum.StatusUsers? status)
    {
        var roleAdmin = _httpContextAccessor.HttpContext.User.Claims
                                .FirstOrDefault(x => x.Type == "Role")?.Value;
        if (roleAdmin != Enum.Enum.Role.Admin.ToString())
        {
            throw new Exception("Bạn không được ủy quyền");
        }
        var getAllUser = _dbContext.Users.Where(x => true);

        if (!string.IsNullOrWhiteSpace(search))
        {
            getAllUser = getAllUser.Where(x => x.Email.Contains(search) ||
                                               (x.PhoneNumber != null && x.PhoneNumber.Contains(search)));
        }
        if (id.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Id == id);
        }
        if (role.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Role == role.ToString());
        }
        if (status.HasValue)
        {
            getAllUser = getAllUser.Where(x => x.Status == status.ToString());
        }
        var toTalItems = getAllUser.Count();
        if (toTalItems < 1)
        {
            return new Base.Response.PageResult<Response.UserDto>()
            {
                Items = [],
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItems = toTalItems,
            };
        }
        var sortName = getAllUser.OrderBy(x => x.FirstName);
        var pagedQuery = sortName.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        var selectQuery = pagedQuery.Select(x => new Response.UserDto()
        {
            Email = x.Email,
            Role = x.Role,
            FirstName =  x.FirstName,
            LastName =  x.LastName,
            PhoneNumber = x.PhoneNumber,
            Status = x.Status,
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.UserDto>()
        {
            Items = listResult,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalItems = toTalItems,
        };
        return result;
    }

    public async Task<Response.UserDto> GetUserById(Guid id)
    {
        var roleAdmin = _httpContextAccessor.HttpContext.User.Claims
                                .FirstOrDefault(x => x.Type == "Role")?.Value;
        if (roleAdmin != Enum.Enum.Role.Admin.ToString())
        {
            throw new Exception("Bạn không được ủy quyền");
        }
        var user = await _dbContext.Users
            .Include(x => x.Customer)
            .Include(x => x.Owner).FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw new Exception("user không tồn tại");
        }

        if (user.Role == Enum.Enum.Role.Customer.ToString())
        {
            if(user.Customer == null) throw new Exception("Customer không tồn tại");
            var bookings = _dbContext.Bookings.Where(x => x.CustomerId == user.Customer.Id);
            var bookingDto = bookings.Select(x => new Response.BookingDto()
            {
                TotalPrice = x.TotalPrice,
                DiscountAmount =  x.DiscountAmount,
                FinalPrice =  x.FinalPrice,
                Status =  x.Status,
                CancellationReason =   x.CancellationReason,
            });
            var resultBookingDto = await bookingDto.ToListAsync();
            var result = new Response.CustomerDto()
            {
                Email = user.Email,
                Role = user.Role,
                FirstName =  user.FirstName,
                LastName =  user.LastName,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                Bookings = resultBookingDto
            };
            return result;
        }

        if (user.Role == Enum.Enum.Role.Owner.ToString())
        {
            if(user.Owner == null) throw new Exception("Owner không tồn tại");
            var courts = _dbContext.Courts.Where(x => x.OwnerId == user.Owner.Id);
            var courtDto = courts.Select(x => new Response.CourtDto()
            {
                Name = x.Name,
                Address = x.Address,
                OpenTime = x.OpenTime,
                CloseTime = x.CloseTime,
                Status = x.Status,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                MapUrl = x.MapUrl,
            });
            var resultCourtDto =  await courtDto.ToListAsync();
            var result = new Response.OwnerDto()
            {
                Email = user.Email,
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                BusinessAddress = user.Owner.BusinessAddress,
                BusinessName = user.Owner.BusinessName,
                TaxCode = user.Owner.TaxCode,
                Courts = resultCourtDto
            };
            return result;
        }
        throw new Exception("Không có quyền xem user admin");
    }

    
}