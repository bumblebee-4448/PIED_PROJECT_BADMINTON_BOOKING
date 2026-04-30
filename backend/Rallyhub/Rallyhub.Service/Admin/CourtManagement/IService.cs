namespace Rallyhub.Service.Admin.CourtManagement;

public interface IService
{
    public Task DeleteCourt(Guid id);
}