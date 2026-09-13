using Salesync.SalesRep.Pwa.Common;
using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepInvoiceReturnApiService : ISalesRepInvoiceReturnApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepInvoiceReturnApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient =
                httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<IEnumerable<InvoiceReturnDto>>?> GetMyReturnsAsync()
        {
            try
            {
                var response =await _httpClient.GetFromJsonAsync<
                        ApiResponse<IEnumerable<InvoiceReturnDto>>>("api/mobile/salesrep/returns");

                return response
                    ?? CreateErrorResponse<IEnumerable<InvoiceReturnDto>>("لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<InvoiceReturnDto>>(AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<InvoiceReturnDto>>("صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<InvoiceReturnDto>>("حدث خطأ غير متوقع أثناء تحميل طلبات المرتجع.");
            }
        }

        public async Task<ApiResponse<InvoiceReturnDto>?>GetByIdAsync(int id)
        {
            try
            {
                var response =await _httpClient.GetFromJsonAsync<
                        ApiResponse<InvoiceReturnDto>>($"api/mobile/salesrep/returns/{id}");

                return response?? CreateErrorResponse<InvoiceReturnDto>("لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceReturnDto>(AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<InvoiceReturnDto>("صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceReturnDto>("حدث خطأ غير متوقع أثناء تحميل تفاصيل المرتجع.");
            }
        }
        public async Task<ApiResponse<IEnumerable<MobileReturnableInvoiceDto>>?>GetReturnableInvoicesAsync(int customerId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<MobileReturnableInvoiceDto>>>(
                        $"api/mobile/salesrep/customers/{customerId}/returnable-invoices");

                return response
                    ?? CreateErrorResponse<IEnumerable<MobileReturnableInvoiceDto>>(
                        "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<MobileReturnableInvoiceDto>>(
                    AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<MobileReturnableInvoiceDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<MobileReturnableInvoiceDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل الفواتير القابلة للمرتجع.");
            }
        }
        public async Task<ApiResponse<MobileReturnableInvoiceDetailsDto>?>GetReturnableInvoiceDetailsAsync(int invoiceId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<MobileReturnableInvoiceDetailsDto>>(
                        $"api/mobile/salesrep/returns/invoices/{invoiceId}");

                return response
                    ?? CreateErrorResponse<MobileReturnableInvoiceDetailsDto>(
                        "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<MobileReturnableInvoiceDetailsDto>(
                    AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<MobileReturnableInvoiceDetailsDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<MobileReturnableInvoiceDetailsDto>(
                    "حدث خطأ غير متوقع أثناء تحميل تفاصيل الفاتورة القابلة للمرتجع.");
            }
        }
        public async Task<ApiResponse<InvoiceReturnDto>?>CreateAsync(CreateInvoiceReturnRequest request)
        {
            try
            {
                using var httpResponse =await _httpClient.PostAsJsonAsync("api/mobile/salesrep/returns",request);

                var response =await httpResponse.Content.ReadFromJsonAsync<
                        ApiResponse<InvoiceReturnDto>>();

                return response?? CreateErrorResponse<InvoiceReturnDto>("لم يتم استلام استجابة صحيحة من الخادم.",(int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceReturnDto>(AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<InvoiceReturnDto>("صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceReturnDto>("حدث خطأ غير متوقع أثناء إنشاء طلب المرتجع.");
            }
        }

        public async Task<ApiResponse<InvoiceReturnDto>?>CancelAsync(int id)
        {
            try
            {
                using var httpResponse =await _httpClient.PutAsync($"api/mobile/salesrep/returns/{id}/cancel",null);

                var response =await httpResponse.Content.ReadFromJsonAsync<
                        ApiResponse<InvoiceReturnDto>>();

                return response
                    ?? CreateErrorResponse<InvoiceReturnDto>("لم يتم استلام استجابة صحيحة من الخادم.",(int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<InvoiceReturnDto>(AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<InvoiceReturnDto>("صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<InvoiceReturnDto>("حدث خطأ غير متوقع أثناء إلغاء طلب المرتجع.");
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