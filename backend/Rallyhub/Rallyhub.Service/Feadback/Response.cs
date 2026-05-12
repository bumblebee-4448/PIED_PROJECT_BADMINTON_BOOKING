namespace Rallyhub.Service.Feadback;

public class Response
{
    public class GetFeadbackResponse
    {
        public string NameCustomer { get; set; }
        public string? Comment {get; set;}
        public int Rating {get; set;}
        public DateTimeOffset CreatedAt {get; set;}
    }
}