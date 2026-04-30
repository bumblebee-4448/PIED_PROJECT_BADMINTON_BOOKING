namespace Rallyhub.Service.Admin.UserManagement;

public class Request
{
    public class GetUserRequest
    {
        public string? SearchTmp { get; set; }
        public int PageIndex  { get; set; }
        public int PageSize   { get; set; }
        public Guid? Id  { get; set; }
        public Enum.Enum.Role? Role  { get; set; }
        public Enum.Enum.StatusUsers? Status  { get; set; }
    }
    public class GetUserByIdRequest
    {
        public Guid? Id  { get; set; }
    }
}