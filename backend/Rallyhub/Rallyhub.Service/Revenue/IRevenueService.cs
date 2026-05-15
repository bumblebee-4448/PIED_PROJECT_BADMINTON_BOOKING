using System;
using System.Threading.Tasks;

namespace Rallyhub.Service.Revenue
{
    public interface IRevenueService
    {
        Task<Response.OwnerRevenueResponse> GetOwnerRevenue(Guid ownerId, DateTime? startDate, DateTime? endDate, Guid? courtId);
    }
}
