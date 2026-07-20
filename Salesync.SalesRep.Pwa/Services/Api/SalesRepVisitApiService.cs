using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public sealed class SalesRepVisitApiService : ISalesRepVisitApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepVisitApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<CustomerVisitDto>?> StartVisitAsync(StartSalesRepMobileVisitRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/mobile/salesrep/visits/start",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<CustomerVisitDto>>();

                return response ?? CreateErrorResponse<CustomerVisitDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<CustomerVisitDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<CustomerVisitDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<CustomerVisitDto>(
                    "حدث خطأ غير متوقع أثناء بدء الزيارة.");
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