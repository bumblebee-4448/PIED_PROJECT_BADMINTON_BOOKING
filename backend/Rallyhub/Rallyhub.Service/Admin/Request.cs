namespace Rallyhub.Service.Admin;

public class Request
{
    public class UpdateStatusUserResponse
    {
        public Guid Id  { get; set; }
        public string Status { get; set; }
    }
}