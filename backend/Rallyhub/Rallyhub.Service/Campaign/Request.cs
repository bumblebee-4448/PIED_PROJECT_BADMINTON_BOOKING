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
        public required Guid Id  { get; set; }
        public required decimal DiscountPercent  { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal? MinBookingAmount { get; set; }
        public int UsageLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CampaignDetailRequest
    {
        public Guid Id { get; set; }
    }
    public class GetCampaignByCourtRequest: Base.Request.PagingRequest
    {
        public required Guid CourtId { get; set; }
    }
    public class DeleteCampaignRequest
    {
        public required Guid Id { get; set; }
    }

    public class GetAllCampaignCourt : Base.Request.PagingRequest
    {
        public Guid CourtId { get; set; }
    }
}