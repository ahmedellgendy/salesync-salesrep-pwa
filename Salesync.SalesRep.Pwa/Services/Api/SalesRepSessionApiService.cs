using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public sealed class SalesRepSessionApiService : ISalesRepSessionApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepSessionApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<SalesRepMobileTodayDto>?> GetTodayAsync()
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<SalesRepMobileTodayDto>>(
                        "api/mobile/salesrep/today");

                return response ?? CreateErrorResponse<SalesRepMobileTodayDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepMobileTodayDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepMobileTodayDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<SalesRepMobileTodayDto>(
                    "حدث خطأ غير متوقع أثناء تحميل بيانات اليوم.");
            }
        }

        public async Task<ApiResponse<SalesRepSessionDto>?> StartDayAsync()
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/mobile/salesrep/day/start",
                    new { notes = "Start day from PWA" });

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<SalesRepSessionDto>>();

                return response ?? CreateErrorResponse<SalesRepSessionDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "حدث خطأ غير متوقع أثناء بدء اليوم.");
            }
        }

        public async Task<ApiResponse<SalesRepSessionDto>?> CloseDayAsync(int sessionId)
        {
            try
            {
                using var httpResponse = await _httpClient.PutAsync(
                    $"api/mobile/salesrep/day/{sessionId}/close",
                    content: null);

                var response = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<SalesRepSessionDto>>();

                return response ?? CreateErrorResponse<SalesRepSessionDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "حدث خطأ غير متوقع أثناء قفل اليوم.");
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