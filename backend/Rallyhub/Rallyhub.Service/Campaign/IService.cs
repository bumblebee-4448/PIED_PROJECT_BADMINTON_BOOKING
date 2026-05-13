using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.Campaign;

public interface IService
{
    public Task CreateCampaign(Request.CreateCampaignRequest request);
    public Task CreateCampaignCourt(Request.CreateCampaignCourtRequest request);
    public Task UpdateCampaign(Request.UpdateCampaignRequest request);
    public Task<Response.CampaignDetailResponse> CampaignDetail(Request.CampaignDetailRequest request);
    public Task DeleteCampaign(Request.DeleteCampaignRequest request);
    public Task<Base.Response.PageResult<Response.GetAllCampaignResponse>> GetAllCampaign(Request.GetAllCampaignRequest request);
}