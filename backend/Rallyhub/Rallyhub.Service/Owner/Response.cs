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
}