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
  
    public class GetMyCourtsRequest  
    {  
        public string? Name { get; set; }  
        public int PageIndex { get; set; } = 1;   
        public int PageSize { get; set; } = 10;  
    }

    public class CreateSubCourtRequest
    {
        public Guid CourtId { get; set; }
        public string Name { get; set; } = null!;
    }
    
    public class GetMySubCourtsRequest  
    {  
        public Guid? CourtId { get; set; }
        public string? Name { get; set; }  
        public int PageIndex { get; set; } = 1;   
        public int PageSize { get; set; } = 10;  
    }

    public class CreateConfigSlotRequest
    {
        public Guid SubCourtId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal Price { get; set; }
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
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Reason { get; set; } = null!;
    }
    
    public class GetAvailableSlotsRequest
    {
        public Guid SubCourtId { get; set; }
        public DateOnly Date { get; set; }
    }
 
}