using Salesync.SalesRep.Pwa.Models.Requests;
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

        public async Task<ApiResponse<SalesRepSessionDto>?> StartDayAsync(int salesRepId)
        {
            try
            {
                var request = new CreateSalesRepSessionRequest
                {
                    SalesRepId = salesRepId
                };

                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/SalesRepSession/start",
                    request);

                var apiResponse = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<SalesRepSessionDto>>();

                if (apiResponse is not null)
                    return apiResponse;

                return CreateErrorResponse<SalesRepSessionDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (TaskCanceledException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "انتهت مهلة الاتصال بالخادم.");
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
                    $"api/SalesRepSession/{sessionId}/close",
                    content: null);

                var apiResponse = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<SalesRepSessionDto>>();

                if (apiResponse is not null)
                    return apiResponse;

                return CreateErrorResponse<SalesRepSessionDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (TaskCanceledException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "انتهت مهلة الاتصال بالخادم.");
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

        public async Task<ApiResponse<SalesRepSessionDto>?> GetSessionByIdAsync(int sessionId)
        {
            try
            {
                var apiResponse = await _httpClient
                    .GetFromJsonAsync<ApiResponse<SalesRepSessionDto>>(
                        $"api/SalesRepSession/{sessionId}");

                return apiResponse ?? CreateErrorResponse<SalesRepSessionDto>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (TaskCanceledException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "انتهت مهلة الاتصال بالخادم.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<SalesRepSessionDto>(
                    "حدث خطأ غير متوقع أثناء تحميل بيانات اليوم.");
            }
        }

        public async Task<ApiResponse<IEnumerable<SalesRepSessionDto>>?> GetSessionsBySalesRepAsync(int salesRepId)
        {
            try
            {
                var apiResponse = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepSessionDto>>>(
                        $"api/SalesRepSession/salesrep/{salesRepId}");

                return apiResponse ?? CreateErrorResponse<IEnumerable<SalesRepSessionDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepSessionDto>>(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (TaskCanceledException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepSessionDto>>(
                    "انتهت مهلة الاتصال بالخادم.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepSessionDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse<IEnumerable<SalesRepSessionDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل أيام المندوب.");
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