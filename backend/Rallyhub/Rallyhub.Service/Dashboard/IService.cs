namespace Rallyhub.Service.Dashboard;

public interface IService
{
    public Task<Response.DashboardAdminResponse> DashboardAdmin();
}