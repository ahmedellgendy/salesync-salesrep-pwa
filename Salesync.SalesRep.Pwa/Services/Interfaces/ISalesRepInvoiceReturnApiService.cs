using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepInvoiceReturnApiService
    {
        Task<ApiResponse<IEnumerable<InvoiceReturnDto>>?> GetMyReturnsAsync();
        Task<ApiResponse<InvoiceReturnDto>?> GetByIdAsync(int id);
        Task<ApiResponse<InvoiceReturnDto>?> CreateAsync(CreateInvoiceReturnRequest request);
        Task<ApiResponse<InvoiceReturnDto>?> CancelAsync(int id);

        Task<ApiResponse<IEnumerable<MobileReturnableInvoiceDto>>?>GetReturnableInvoicesAsync(int customerId);
        Task<ApiResponse<MobileReturnableInvoiceDetailsDto>?>GetReturnableInvoiceDetailsAsync(int invoiceId);
    }
}