using global::Salesync.SalesRep.Pwa.Models.Responses.Reports;
using System.Net.Http.Json;

namespace Salesync.SalesRep.Pwa.Services.Api.Supervisor
{
    public sealed class SupervisorReportApiService
    {
        private readonly HttpClient _httpClient;

        public SupervisorReportApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SupervisorSummaryReportDto?> GetSummaryAsync(DateOnly fromDate, DateOnly toDate)
        {
            var url =
                $"api/reports/supervisor/summary" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}";

            return await _httpClient.GetFromJsonAsync<SupervisorSummaryReportDto>(url);
        }

        public async Task<PagedReportResult<SupervisorSalesReportItemDto>?> GetSalesAsync(DateOnly fromDate, DateOnly toDate, int pageNumber = 1, int pageSize = 10)
        {
            var url =
                $"api/reports/supervisor/sales" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}" +
                $"&pageNumber={pageNumber}" +
                $"&pageSize={pageSize}";

            return await _httpClient
                .GetFromJsonAsync<
                    PagedReportResult<
                        SupervisorSalesReportItemDto>>(url);
        }

        public async Task<PagedReportResult<SupervisorInvoiceReportItemDto>?> GetInvoicesAsync(DateOnly fromDate, DateOnly toDate, int pageNumber = 1, int pageSize = 10)
        {
            var url =
                $"api/reports/supervisor/invoices" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}" +
                $"&pageNumber={pageNumber}" +
                $"&pageSize={pageSize}";

            return await _httpClient.GetFromJsonAsync<PagedReportResult<SupervisorInvoiceReportItemDto>>(url);
        }

        public async Task<PagedReportResult<SupervisorPaymentReportItemDto>?> GetPaymentsAsync(DateOnly fromDate, DateOnly toDate, int pageNumber = 1, int pageSize = 10)
        {
            var url =
                $"api/reports/supervisor/payments" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}" +
                $"&pageNumber={pageNumber}" +
                $"&pageSize={pageSize}";

            return await _httpClient.GetFromJsonAsync<PagedReportResult<SupervisorPaymentReportItemDto>>(url);
        }

        public async Task<PagedReportResult<SupervisorReturnReportItemDto>?> GetReturnsAsync(DateOnly fromDate, DateOnly toDate, int pageNumber = 1, int pageSize = 10)
        {
            var url =
                $"api/reports/supervisor/returns" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}" +
                $"&pageNumber={pageNumber}" +
                $"&pageSize={pageSize}";

            return await _httpClient
                .GetFromJsonAsync<
                    PagedReportResult<
                        SupervisorReturnReportItemDto>>(url);
        }

        public async Task<PagedReportResult<SupervisorVisitReportItemDto>?> GetVisitsAsync(DateOnly fromDate, DateOnly toDate, int pageNumber = 1, int pageSize = 10)
        {
            var url =
                $"api/reports/supervisor/visits" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}" +
                $"&pageNumber={pageNumber}" +
                $"&pageSize={pageSize}";

            return await _httpClient
                .GetFromJsonAsync<
                    PagedReportResult<
                        SupervisorVisitReportItemDto>>(url);
        }

        public async Task<List<SupervisorSalesRepPerformanceDto>?>GetSalesRepPerformanceAsync(DateOnly fromDate,DateOnly toDate)
        {
            var url =
                $"api/reports/supervisor/salesrep-performance" +
                $"?fromDate={fromDate:yyyy-MM-dd}" +
                $"&toDate={toDate:yyyy-MM-dd}";

            return await _httpClient
                .GetFromJsonAsync<
                    List<SupervisorSalesRepPerformanceDto>>(url);
        }

    }
}