using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rallyhub.Repository;

namespace Rallyhub.Service.Campaign;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Service(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task CreateCampaign(Request.CreateCampaignRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("No user claim found");
        }
        var userId = Guid.Parse(getUserId);
        if (request.DiscountPercent < 0 ||  request.DiscountPercent > 100)
        {
            throw new Exception("Discount percent must be between 0 and 100");
        }

        if (request.UsageLimit < 0)
        {
            throw new Exception("Usage limit must be greater than 0");
        }

        if (request.UsedCount < 0)
        {
            throw new Exception("UsedCount must be greater than 0");
        }

        if (request.UsageLimit < request.UsedCount)
        {
            throw new Exception("The Usage limit must be greater than the used count");
        }

        if (request.StartDate > request.EndDate)
        {
            throw new Exception("Start date must be before end date");
        }
        var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Code == request.Code);
        if (campaign != null)
        {
            if (campaign.IsDeleted)
            {
                campaign.IsDeleted = false;
                campaign.DiscountPercent = request.DiscountPercent;
                campaign.MaxDiscountAmount = request.MaxDiscountAmount;
                campaign.MinBookingAmount = request.MinBookingAmount;
                campaign.UsageLimit = request.UsageLimit;
                campaign.UsedCount = request.UsedCount;
                campaign.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
                campaign.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);
                campaign.CreatedAt = DateTimeOffset.UtcNow;
                _dbContext.Campaigns.Update(campaign);
                await _dbContext.SaveChangesAsync();
                return;
            }
            throw new Exception("Campaign already exists");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("No user found");
        }
        if (user.Role == "Admin")
        {
            var newCampaign = new Repository.Entity.Campaign()
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                IsGlobal = true,
                DiscountPercent = request.DiscountPercent,
                MaxDiscountAmount = request.MaxDiscountAmount,
                MinBookingAmount = request.MinBookingAmount,
                UsageLimit = request.UsageLimit,
                UsedCount = request.UsedCount,
                StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc),
                EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc),
                CreatedAt = DateTimeOffset.UtcNow
            };
            await _dbContext.Campaigns.AddAsync(newCampaign);
            await _dbContext.SaveChangesAsync();
            return;
        }
        if (user.Role == "Owner")
        {
            var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == userId);
            if (owner == null)
            {
                throw new Exception("No owner found");
            }
            var newCampaign = new Repository.Entity.Campaign()
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                IsGlobal = false,
                OwnerId = owner.Id,
                DiscountPercent = request.DiscountPercent,
                MaxDiscountAmount = request.MaxDiscountAmount,
                MinBookingAmount = request.MinBookingAmount,
                UsageLimit = request.UsageLimit,
                UsedCount = request.UsedCount,
                StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc),
                EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc),
                CreatedAt = DateTimeOffset.UtcNow
            };
            await _dbContext.Campaigns.AddAsync(newCampaign);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task CreateCampaignCourt(Request.CreateCampaignCourtRequest request)
    {
        var court = await _dbContext.Courts.FirstOrDefaultAsync(x => x.Id == request.CourtId);
        if (court == null)
        {
            throw new Exception("Court not found");
        }
        
        var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == request.CampaignId);
        if (campaign == null)
        {
            throw new Exception("Campaign not found");
        }
        var check = await _dbContext.CampaignCourts
                                .FirstOrDefaultAsync(x => x.CampaignId == request.CampaignId && 
                                                                        x.CourtId == request.CourtId);
        if (check != null)
        {
            if (check.IsDeleted)
            {
                check.IsDeleted = false;
                check.UpdatedAt  = DateTimeOffset.UtcNow;
                _dbContext.CampaignCourts.Update(check);
                await _dbContext.SaveChangesAsync();
                return;
            }
            throw new Exception("Campaign and court exists");
        }
        
        if (campaign.OwnerId != court.OwnerId)
        {
            throw new  Exception("Campaign owner mismatch");
        }
        
        var result = new Repository.Entity.CampaignCourt()
        {
            CourtId = court.Id,
            CampaignId = campaign.Id,
            CreatedAt = DateTimeOffset.UtcNow
        };
        await _dbContext.CampaignCourts.AddAsync(result);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateCampaign(Request.UpdateCampaignRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("No user claim found");
        }
        var userId = Guid.Parse(getUserId);
        if (request.DiscountPercent < 0 ||  request.DiscountPercent > 100)
        {
            throw new Exception("Discount percent must be between 0 and 100");
        }

        if (request.UsageLimit < 0)
        {
            throw new Exception("Usage limit must be greater than 0");
        }

        if (request.UsedCount < 0)
        {
            throw new Exception("UsedCount must be greater than 0");
        }

        if (request.UsageLimit < request.UsedCount)
        {
            throw new Exception("The Usage limit must be greater than the used count");
        }

        if (request.StartDate > request.EndDate)
        {
            throw new Exception("Start date must be before end date");
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        if (user.Role == "Owner")
        {
            var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == userId);
            if (owner == null)
            {
                throw new Exception("No owner found");
            }
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Code == request.Code);
            if (campaign == null)
            {
                throw new Exception("Campaign not found");
            }
            if (campaign.OwnerId != owner.Id)
            {
                throw new Exception("Campaign owner mismatch");
            }
            campaign.DiscountPercent = request.DiscountPercent;
            campaign.MaxDiscountAmount = request.MaxDiscountAmount;
            campaign.MinBookingAmount = request.MinBookingAmount;
            campaign.UsageLimit = request.UsageLimit;
            campaign.UsedCount = request.UsedCount;
            campaign.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            campaign.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);
            campaign.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Update(campaign);
            await _dbContext.SaveChangesAsync();
            return;
        }

        if (user.Role == "Admin")
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Code == request.Code);
            if (campaign == null)
            {
                throw new Exception("Campaign not found");
            }
            campaign.DiscountPercent = request.DiscountPercent;
            campaign.MaxDiscountAmount = request.MaxDiscountAmount;
            campaign.MinBookingAmount =  request.MinBookingAmount;
            campaign.UsageLimit = request.UsageLimit;
            campaign.UsedCount = request.UsedCount;
            campaign.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            campaign.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);
            campaign.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Update(campaign);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Response.CampaignDetailResponse> CampaignDetail(Request.CampaignDetailRequest request)
    {
        var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Code == request.Code);
        if (campaign == null)
        {
            throw new Exception("Campaign not found");
        }

        if (campaign.IsDeleted)
        {
            throw new Exception("Campaign is not exist");
        }
        return new Response.CampaignDetailResponse()
        {
            Code =  campaign.Code,
            DiscountPercent = campaign.DiscountPercent,
            MaxDiscountAmount = campaign.MaxDiscountAmount,
            MinBookingAmount = campaign.MinBookingAmount,
            UsageLimit =  campaign.UsageLimit,
            UsedCount = campaign.UsedCount,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate,
        };
    }
    public async Task DeleteCampaign(Request.DeleteCampaignRequest request)
    {
        var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Code == request.Code);
        if (campaign == null)
        {
            throw new Exception("Campaign not found");
        }

        if (campaign.IsDeleted)
        {
            throw new Exception("Campaign is already deleted");
        }
        var campaignCourt = await _dbContext.CampaignCourts.Where(x => x.CampaignId == campaign.Id).ToListAsync();
        foreach (var item in campaignCourt)
        {
            item.IsDeleted = true;
            item.UpdatedAt = DateTimeOffset.UtcNow;
        }
        campaign.IsDeleted = true;
        campaign.UpdatedAt = DateTimeOffset.UtcNow;
        _dbContext.CampaignCourts.UpdateRange(campaignCourt);
        _dbContext.Campaigns.Update(campaign);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Base.Response.PageResult<Response.GetAllCampaignResponse>> GetAllCampaign(Base.Request.PagingRequest request)
    {
        var campaignList = _dbContext.Campaigns.Where(x => x.IsDeleted == false && x.IsGlobal == true);
        var sortEndTime = campaignList.OrderBy(x => x.EndDate);
        var pageQuery = sortEndTime.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetAllCampaignResponse()
        {
            Code =  x.Code,
            MaxDiscountAmount = x.MaxDiscountAmount,
            MinBookingAmount = x.MinBookingAmount,
            Expired = x.EndDate - x.StartDate,
            Quantity = x.UsageLimit - x.UsedCount,
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetAllCampaignResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize =  request.PageSize,
            TotalItems =  listResult.Count,
        };
        return result;
    }

    public async Task<Base.Response.PageResult<Response.GetAllCampaignResponse>> GetAllCampaignCourt(Base.Request.PagingRequest request)
    {
        var getUserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
        if (getUserId == null)
        {
            throw new Exception("No user claim found");
        }
        var userId = Guid.Parse(getUserId);
        var owner = await _dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == userId);
        if (owner == null)
        {
            throw new Exception("No owner found");
        }
        var campaignList = _dbContext.Campaigns
                                                .Where(x => x.IsDeleted == false && 
                                                                        x.IsGlobal == false && 
                                                                        x.OwnerId == owner.Id);
        var sort = campaignList.OrderByDescending(x => x.CreatedAt);
        var pageQuery = sort.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectQuery = pageQuery.Select(x => new Response.GetAllCampaignResponse()
        {
            Code =  x.Code,
            MaxDiscountAmount = x.MaxDiscountAmount,
            MinBookingAmount = x.MinBookingAmount,
            Expired = x.EndDate - x.StartDate,
            Quantity = x.UsageLimit - x.UsedCount,
        });
        var listResult = await selectQuery.ToListAsync();
        var result = new Base.Response.PageResult<Response.GetAllCampaignResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize =  request.PageSize,
            TotalItems =  listResult.Count,
        };
        return result;
    }

    public async Task<Base.Response.PageResult<Response.GetAllCampaignResponse>> CampaignByCourt(Request.GetCampaignByCourtRequest request)
    {
        var campaignCourtList = await _dbContext.CampaignCourts.Where(x => x.CourtId == request.CourtId).ToListAsync();
        List<Repository.Entity.Campaign> campaigns = new List<Repository.Entity.Campaign>();
        foreach (var item in campaignCourtList)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(x => x.Id == item.CampaignId);
            if (campaign != null)
            {
                campaigns.Add(campaign);
            }
        }
        var selectCampaign = campaigns.Select(x => new Response.GetAllCampaignResponse()
        {
            Code =  x.Code,
            MaxDiscountAmount = x.MaxDiscountAmount,
            MinBookingAmount = x.MinBookingAmount,
            Expired = x.EndDate - x.StartDate,
            Quantity = x.UsageLimit - x.UsedCount,
        });
        var listResult = selectCampaign.ToList();
        var result = new Base.Response.PageResult<Response.GetAllCampaignResponse>()
        {
            Items = listResult,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalItems = listResult.Count,
        };
        return result;
    }
}