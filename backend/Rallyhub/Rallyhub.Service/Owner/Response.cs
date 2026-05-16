using Microsoft.AspNetCore.Http;

namespace Rallyhub.Service.Owner;

public class Response
{
    public class CreateCourtResponse  
    {  
        public Guid CourtId { get; set; }  
        public string Status { get; set; } = null!;  
    }  
  
    public class GetMyCourtsResponse  
    {  
        public Guid CourtId { get; set; }
        public string Name { get; set; } = null!;  
        public string Status { get; set; } = null!;  
        public string Address { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string PictureUrl { get; set; } = null!;
        public string MapUrl { get; set; } = null!;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
    
    public class CreateSubCourtResponse
    {
        public Guid SubCourtId { get; set; }
        public string Name { get; set; } = null!;
    }
    
    public class GetMySubCourtsResponse
    {
        public Guid CourtId { get; set; }
        public Guid SubCourtId { get; set; }
        public string Name { get; set; } = null!;
    }
    
    public class CreateConfigSlotResponse
    {
        public Guid Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }
    
    public class GetConfigSlotResponse: CreateConfigSlotResponse
    {
        public string Type { get; set; } = null!;
    }

    public class CreateOverrideSlotResponse
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }

    public class GetOverrideSlotResponse: CreateOverrideSlotResponse
    {   
        public bool IsRecurring { get; set; }
        public string Type { get; set; } = null!;
    }
    
    public class CreateExceptionSlotResponse
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Reason { get; set; } = null!;
    }
    
    public class GetExceptionSlotResponse: CreateExceptionSlotResponse
    {
        public bool IsRecurring { get; set; }
        public string Type { get; set; } = null!;
    }
    
    public class GetSetupSlotResponse
    {
        public List<GetConfigSlotResponse> ConfigSlots { get; set; } = new ();
        public List<GetOverrideSlotResponse> OverrideSlots { get; set; } = new ();
        public List<GetExceptionSlotResponse> ExceptionSlots { get; set; } = new ();
    }

    public class SlotResponse
    {
        public Guid? ConfigSlotId { get; set; }
        public Guid? OverrideSlotId { get; set; }
        public Guid? ExceptionId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? Reason { get; set; }
        public string Type { get; set; } = null!;
    }
    
    public class UpdateCourtInfoResponse
    {
        public Guid CourtId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MapUrl { get; set; }
        public string? PictureUrl { get; set; }
        public string? Description { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public int? TimeRefundBefore { get; set; } 
    }
    public class UpdateSubCourtInfoResponse
    {
        public Guid SubCourtId { get; set; }
        public string Name { get; set; } = null!;
    }

    public class DashboardResponse
    {
        public decimal CurrentRevenue { get; set; }
        public decimal PreviousRevenue { get; set; }
        public double ComparisonPercentage { get; set; }
        public decimal RevenueDifference { get; set; }
        public string ComparisonStatus { get; set; } = null!; // "Increase", "Decrease", "NoChange"
        
        public int CurrentBookingCount { get; set; }
        public int PreviousBookingCount { get; set; }
        public double BookingComparisonPercentage { get; set; }
        public int BookingDifference { get; set; }
        public string BookingComparisonStatus { get; set; } = null!;

        public string Period { get; set; } = null!;
    }

    public class GetCourtBookingsResponse
    {
        public Guid BookingId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CourtName { get; set; } = null!;
        public DateTimeOffset BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = null!;
        public List<BookingSlotResponse> Slots { get; set; } = new();
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class BookingSlotResponse
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }
}