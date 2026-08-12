using System.Net.Http.Json;
using System.Text.Json;
using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepUnloadRequestApiService : ISalesRepUnloadRequestApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepUnloadRequestApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<SalesRepUnloadRequestDto>?> CreateAsync(CreateUnloadRequestRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/mobile/salesrep/unload-requests",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<SalesRepUnloadRequestDto>>();

                return response ?? CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "حدث خطأ غير متوقع أثناء إنشاء طلب تفريغ الحمولة.");
            }
        }

        public async Task<ApiResponse<IEnumerable<SalesRepUnloadRequestDto>>?> GetMyRequestsAsync()
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepUnloadRequestDto>>>(
                        "api/mobile/salesrep/unload-requests/my");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepUnloadRequestDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepUnloadRequestDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepUnloadRequestDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<SalesRepUnloadRequestDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل طلبات تفريغ الحمولة.");
            }
        }

        public async Task<ApiResponse<SalesRepUnloadRequestDto>?> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<SalesRepUnloadRequestDto>>(
                        $"api/mobile/salesrep/unload-requests/{id}");

                return response ?? CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<SalesRepUnloadRequestDto>(
                    "حدث خطأ غير متوقع أثناء تحميل تفاصيل طلب التفريغ.");
            }
        }

        public async Task<ApiResponse<string>?> CancelAsync(int id,CancelUnloadRequestRequest request)
        {
            try
            {
                using var httpResponse = await _httpClient.PutAsJsonAsync(
                    $"api/mobile/salesrep/unload-requests/{id}/cancel",
                    request);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<string>>();

                return response ?? CreateErrorResponse<string>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<string>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<string>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<string>(
                    "حدث خطأ غير متوقع أثناء إلغاء طلب تفريغ الحمولة.");
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