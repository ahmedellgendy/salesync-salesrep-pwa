using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepInvoiceApiService
    {
        Task<ApiResponse<InvoiceDto>?> CreateInvoiceAsync(CreateInvoiceRequest request);
        Task<ApiResponse<InvoiceDto>?> ConfirmInvoiceAsync(int invoiceId);
        Task<ApiResponse<IEnumerable<SalesRepMobileInvoiceDto>>?> GetMyInvoicesAsync(int sessionId);
        Task<ApiResponse<InvoiceDto>?> CreateMobileInvoiceAsync(CreateSalesRepMobileInvoiceRequest request);
    }
}