namespace Rallyhub.Service.Dashboard;

public interface IService
{
    public Task<Response.DashboardAdminResponse> DashboardAdmin();
    //public Task<Response.DashboardOwnerResponse> DashboardOwner();
}