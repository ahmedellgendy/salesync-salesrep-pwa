using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepRouteApiService
    {
        Task<ApiResponse<IEnumerable<SalesRepMobileRouteDto>>?> GetRoutesAsync(int sessionId);

        Task<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>?> GetRouteCustomersAsync(int sessionId,int routeId);
    }
}