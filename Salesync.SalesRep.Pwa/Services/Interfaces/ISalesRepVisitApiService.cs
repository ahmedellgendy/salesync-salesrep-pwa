using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepVisitApiService
    {
        Task<ApiResponse<CustomerVisitDto>?> StartVisitAsync(StartSalesRepMobileVisitRequest request);
    }
}
