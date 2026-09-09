using System.Net.Http.Json;
using System.Text.Json;
using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepPaymentApiService : ISalesRepPaymentApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepPaymentApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<PaymentDto>?> CreatePaymentAsync(
            CreateSalesRepMobilePaymentRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/mobile/salesrep/payments",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<PaymentDto>>();

                return response ?? CreateErrorResponse<PaymentDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<PaymentDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<PaymentDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<PaymentDto>(
                    "حدث خطأ غير متوقع أثناء تسجيل التحصيل.");
            }
        }

        public async Task<ApiResponse<IEnumerable<OutstandingInvoiceDto>>?> GetOutstandingInvoicesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<
                    ApiResponse<IEnumerable<OutstandingInvoiceDto>>>(
                        "api/Payment/outstanding-invoices/current-sales-rep");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<OutstandingInvoiceDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<OutstandingInvoiceDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<OutstandingInvoiceDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل مديونيات العملاء.");
            }
        }

        private static ApiResponse<T> CreateErrorResponse<T>(
            string message,
            int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}