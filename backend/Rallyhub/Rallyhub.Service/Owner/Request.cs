using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.Owner;

public class Request
{
    
    public class CreateCourtRequest  
    {  
        public required string Name { get; set; }   
        public required TimeOnly OpenTime  { get; set; }  
        public required TimeOnly CloseTime { get; set; }  
        public required string Address { get; set; }  
        public required decimal Latitude { get; set; }   
        public required decimal Longitude { get; set; }  
        public required string MapUrl  { get; set; }   
        public required IFormFile PictureUrl { get; set; }  
    }  
  
    public class GetAllMyCourtsRequest: Base.Request.PagingRequest
    { 
        public string? Name { get; set; }  
    }

    public class CreateSubCourtRequest
    {
        public Guid CourtId { get; set; }
        public string Name { get; set; } = null!;
        public decimal DefaultPrice { get; set; }
    }
    
    public class GetMySubCourtsRequest: Base.Request.PagingRequest
    {  
        public Guid? CourtId { get; set; }
        public string? Name { get; set; }  
    }
    
    public class CreateOverrideSlotRequest
    {
        public Guid SubCourtId { get; set; }
        public bool IsRecurring { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }
    
    
    public class CreateExceptionSlotRequest
    {
        public Guid SubCourtId { get; set; } 
        public bool IsRecurring { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Reason { get; set; } = null!;
    }
    
    public class GetAvailableSlotsRequest
    {
        public Guid SubCourtId { get; set; }
        public DateOnly Date { get; set; }
    }

    public class UpdateConfigSlotPriceRequest
    {
        public Guid ConfigSlotId { get; set; }
        public decimal NewPrice { get; set; }
    }

    public class UpdateCourtInfoRequest
    {
        public Guid CourtId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public IFormFile? PictureUrl { get; set; }
        public string? Description { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public int? TimeRefundBefore { get; set; }
    }
    public class UpdateSubCourtInfoRequest
    {
        public Guid SubCourtId { get; set; }
        public string Name { get; set; } = null!;
    }

    public class DashboardRequest
    {
        public Guid? CourtId { get; set; }
        public Guid? BookingId { get; set; }
        public string Period { get; set; } = "Day"; // Day, Month, Quarter, Year
        public DateOnly? Date { get; set; }
    }

    public class GetCourtBookingsRequest : Base.Request.Pagination
    {
        public Guid CourtId { get; set; }
        public string Period { get; set; } = "Day"; // Day, Week, Month, Quarter, Year
        public DateOnly? Date { get; set; }
    }
}