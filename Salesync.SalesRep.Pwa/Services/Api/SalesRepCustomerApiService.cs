using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public sealed class SalesRepCustomerApiService : ISalesRepCustomerApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepCustomerApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>?> GetCustomersAsync(int sessionId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>>(
                        $"api/mobile/salesrep/customers?sessionId={sessionId}");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل العملاء.");
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