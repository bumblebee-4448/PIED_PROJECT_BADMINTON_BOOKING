namespace Rallyhub.Service.Campaign;

public class Request
{
    public class CreateCampaignRequest
    {
        public required string Code  { get; set; }
        public required decimal DiscountPercent  { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal? MinBookingAmount { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateCampaignCourtRequest
    {
        public required Guid CourtId  { get; set; }
        public required Guid CampaignId   { get; set; }
    }
    public class UpdateCampaignRequest
    {
        public required string Code  { get; set; }
        public required decimal DiscountPercent  { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal? MinBookingAmount { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CampaignDetailRequest
    {
        public required string Code { get; set; }
    }
    public class GetAllCampaignRequest: Base.Request.PagingRequest
    {
        
    }
    public class DeleteCampaignRequest
    {
        public required string Code { get; set; }
    }
}