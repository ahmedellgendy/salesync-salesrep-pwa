using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepCustomerApiService
    {
        Task<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>?> GetCustomersAsync(int sessionId);
    }
}