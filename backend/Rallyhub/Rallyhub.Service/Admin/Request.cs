namespace Rallyhub.Service.Admin;

public class Request
{
    public class UpdateStatusUserResponse
    {
        public Guid Id  { get; set; }
        public string Status { get; set; }
    }
    
    public class GetMyCourtsRequest  
    {  
        public string? Name { get; set; }  
        public int PageIndex { get; set; } = 1;   
        public int PageSize { get; set; } = 10;  
    }

    public class GetPendingCourtsRequest  
    {  
        public string? Name { get; set; }  
        public int PageIndex { get; set; } = 1;   
        public int PageSize { get; set; } = 10;  
    }  
  
    public class RejectPendingCourtsRequest  
    {  
        public required string Reason { get; set; }  
    }

    public class RefundRequest
    {
        public required Guid CustomerId  { get; set; }
        public required Guid BookingDetailId  { get; set; }
        public required string ImageUrl  { get; set; }
    }
    public class GetWalletRequest
    {
        public required string Email { get; set; }
    }
}