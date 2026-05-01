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
    
    public class SubCourtResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CreateConfigSlotResponse
    {
        public Guid Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }
    
    public class ConfigSlotResponse: CreateConfigSlotResponse
    {
       
    }

    public class CreateOverrideResponse
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
    }
    
}