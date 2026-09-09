using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepPaymentApiService
    {
        Task<ApiResponse<PaymentDto>?> CreatePaymentAsync(CreateSalesRepMobilePaymentRequest request);
        Task<ApiResponse<IEnumerable<OutstandingInvoiceDto>>?> GetOutstandingInvoicesAsync();
    }
}