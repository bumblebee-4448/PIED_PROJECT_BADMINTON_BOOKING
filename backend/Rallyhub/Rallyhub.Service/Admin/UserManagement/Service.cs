using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Admin.UserManagement;

public class Service : IService
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

    public async Task<Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>> AdminGetOwnerRequest(Base.Request.Pagination request)
    {
        var query = _dbContext.OwnerRequests.Where(x => x.Status == "Pending");
        if (request.Id != null)
        {
            query = query.Where(x => x.CustomerId == request.Id);
        }

        if (request.Search != null)
        {
            query = query.Where(x => 
                x.BusinessName.Contains(request.Search) ||
                x.BusinessAddress.Contains(request.Search) ||
                x.IdentityNumber.Contains(request.Search) ||
                x.TaxCode.Contains(request.Search));
        }

        query = query.OrderBy(x => x.CreatedAt);
        query = query
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
        var selectOwenerRequest = query.Select(x => new Response.AdminGetOwnerRequestResponse()
        {
            Id = x.Id,
            UserId =  x.Customer.UserId,
            CustomerId = x.CustomerId,
            BusinessName = x.BusinessName,
            TaxCode = x.TaxCode,
            BusinessAddress = x.BusinessAddress,
            BusinessLicenseUrl = x.BusinessLicenseUrl,
            IdentityNumber = x.IdentityNumber,
            IdentityCardFrontUrl = x.IdentityCardFrontUrl,
            IdentityCardBackUrl = x.IdentityCardBackUrl,
            Status = x.Status,
            CreatedAt = x.CreatedAt,
        });
        var listOwnerRequest = await selectOwenerRequest.ToListAsync();
        var total = listOwnerRequest.Count();

        var result = new Base.Response.PageResult<Response.AdminGetOwnerRequestResponse>()
        {
            Items = listOwnerRequest,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = total,
        };
        return result;
    }

    public async Task<string> AdminAcceptOwnerRequest(Guid ownerRequestId)
    {
        var query = await _dbContext.OwnerRequests.Include(ownerRequest => ownerRequest.Customer).FirstOrDefaultAsync(x => x.Id == ownerRequestId);
        if (query!.Status != "Pending")
        {
            throw new Exception("Error 500");
        }
        if (query.OwnerId != null)
        {
            throw new Exception("Error 500");
        }

        var newOwner = new Repository.Entity.Owner()
        {
            UserId = query.Customer.UserId,
            BusinessName = query.BusinessName,
            TaxCode = query.TaxCode,
            BusinessAddress = query.BusinessAddress,
            BusinessLicenseUrl = query.BusinessLicenseUrl,
            IdentityNumber = query.IdentityNumber,
            IdentityCardFrontUrl = query.IdentityCardFrontUrl,
            IdentityCardBackUrl = query.IdentityCardBackUrl,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        query.Status = "Accept";
        query.UpdatedAt = DateTimeOffset.UtcNow;
        var userId = query.Customer.UserId;
        var queryUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        queryUser!.Status = "Owner";
        _dbContext.Owners.Add(newOwner);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }

    public async Task<string> AdminRejectOwnerRequest(Guid ownerRequestId, string? rejectReason)
    {
        var query = await _dbContext.OwnerRequests.Include(ownerRequest => ownerRequest.Customer).FirstOrDefaultAsync(x => x.Id == ownerRequestId);
        if (query!.Status != "Pending")
        {
            throw new Exception("Error 500");
        }
        if (query.OwnerId != null)
        {
            throw new Exception("Error 500");
        }
        query.Status = "Reject";
        query.RejectionReason = rejectReason;
        query.UpdatedAt = DateTimeOffset.UtcNow;
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return "Success";
        }
        return "Fail";
    }
}