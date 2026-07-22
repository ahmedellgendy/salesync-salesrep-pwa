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

        public async Task<ApiResponse<IEnumerable<SalesRepMobileInvoiceDto>>?> GetMyInvoicesAsync(int sessionId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepMobileInvoiceDto>>>(
                        $"api/mobile/salesrep/invoices?sessionId={sessionId}");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepMobileInvoiceDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileInvoiceDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileInvoiceDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileInvoiceDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل الفواتير.");
            }
        }


        public async Task<ApiResponse<InvoiceDto>?> CreateMobileInvoiceAsync(CreateSalesRepMobileInvoiceRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "api/mobile/salesrep/invoices",
                    request);

                var result =
                    await response.Content.ReadFromJsonAsync<ApiResponse<InvoiceDto>>();

                return result ?? CreateErrorResponse<InvoiceDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceDto>(
                    "حدث خطأ غير متوقع أثناء إنشاء الفاتورة.");
            }
        }

        private static ApiResponse<T> CreateErrorResponse<T>(string message,int statusCode = 500)
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