using System.Net.Http.Json;
using System.Text.Json;
using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepInvoiceApiService : ISalesRepInvoiceApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepInvoiceApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<InvoiceDto>?> CreateInvoiceAsync(CreateInvoiceRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/Invoice",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<InvoiceDto>>();

                return response ?? CreateErrorResponse<InvoiceDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<InvoiceDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceDto>(
                    "حدث خطأ غير متوقع أثناء إنشاء الفاتورة.");
            }
        }

        public async Task<ApiResponse<InvoiceDto>?> ConfirmInvoiceAsync(int invoiceId)
        {
            try
            {
                using var httpResponse = await _httpClient.PutAsync(
                    $"api/Invoice/{invoiceId}/confirm",
                    null);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<InvoiceDto>>();

                return response ?? CreateErrorResponse<InvoiceDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<InvoiceDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceDto>(
                    "حدث خطأ غير متوقع أثناء تأكيد الفاتورة.");
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