namespace Rallyhub.Service.Campaign;

public class Response
{
    public class CampaignDetailResponse
    {
        public required string Code  { get; set; }
        public required decimal DiscountPercent  { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal? MinBookingAmount { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class GetAllCampaignResponse
    {
        public required string Code { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal? MinBookingAmount { get; set; }
        public int Quantity { get; set; }
        public TimeSpan Expired { get; set; }
    }
}