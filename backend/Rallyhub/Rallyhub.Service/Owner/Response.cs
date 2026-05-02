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
        public string Name { get; set; } = null!;  
        public string Status { get; set; } = null!;  
    }
    
    public class CreateSubCourtResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
    
    public class GetMySubCourtsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CourtId { get; set; }
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
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Reason { get; set; } = null!;
    }
    
    public class GetExceptionSlotResponse: CreateExceptionSlotResponse
    {
        
    }
    
    public class GetSetupSlotResponse
    {
        public List<GetConfigSlotResponse> ConfigSlots { get; set; } = new ();
        public List<GetOverrideSlotResponse> OverrideSlots { get; set; } = new ();
        public List<GetExceptionSlotResponse> ExceptionSlots { get; set; } = new ();
    }
}