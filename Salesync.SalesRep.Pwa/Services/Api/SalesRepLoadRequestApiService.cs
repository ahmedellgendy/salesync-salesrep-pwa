using System.Net.Http.Json;
using System.Text.Json;
using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepLoadRequestApiService : ISalesRepLoadRequestApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepLoadRequestApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<LoadRequestDto>?> CreateAsync(CreateLoadRequestRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/LoadRequest",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<LoadRequestDto>>();

                return response ?? CreateErrorResponse<LoadRequestDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<LoadRequestDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<LoadRequestDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<LoadRequestDto>(
                    "حدث خطأ غير متوقع أثناء إنشاء طلب التحميل.");
            }
        }

        public async Task<ApiResponse<IEnumerable<LoadRequestDto>>?> GetBySalesRepAsync(int salesRepId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<LoadRequestDto>>>(
                        $"api/LoadRequest/salesrep/{salesRepId}");

                return response ?? CreateErrorResponse<IEnumerable<LoadRequestDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<LoadRequestDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<LoadRequestDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<LoadRequestDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل طلبات التحميل.");
            }
        }

        public async Task<ApiResponse<IEnumerable<SalesRepInventoryDto>>?> GetInventoryAsync(int salesRepId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepInventoryDto>>>(
                        $"api/LoadRequest/salesrep-inventory/{salesRepId}");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepInventoryDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepInventoryDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepInventoryDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<SalesRepInventoryDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل مخزون المندوب.");
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