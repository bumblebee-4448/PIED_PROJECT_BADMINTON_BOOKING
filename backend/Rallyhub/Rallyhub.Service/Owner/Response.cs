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
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
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
    }
    
    public class GetSetupSlotResponse
    {
        public List<GetConfigSlotResponse> ConfigSlots { get; set; } = new ();
        public List<GetOverrideSlotResponse> OverrideSlots { get; set; } = new ();
        public List<GetExceptionSlotResponse> ExceptionSlots { get; set; } = new ();
    }

    public class SlotResponse
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
       // public string? Reason { get; set; }
        public string Type { get; set; } = null!;
    }
}