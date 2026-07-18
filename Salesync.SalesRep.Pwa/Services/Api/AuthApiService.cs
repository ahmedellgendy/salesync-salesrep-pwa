using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public sealed class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<TokenResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using var httpResponse = await _httpClient.PostAsJsonAsync(
                    "api/Auth/login",
                    request,
                    cancellationToken);

                var apiResponse = await httpResponse.Content
                    .ReadFromJsonAsync<ApiResponse<TokenResponse>>(
                        cancellationToken: cancellationToken);

                if (apiResponse is not null)
                {
                    return apiResponse;
                }

                return CreateErrorResponse(
                    "لم يتم استلام استجابة صحيحة من الخادم.",
                    (int)httpResponse.StatusCode);
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse(
                    "تعذر الاتصال بالخادم. تأكد من تشغيل Salesync API.");
            }
            catch (TaskCanceledException)
            {
                return CreateErrorResponse(
                    "انتهت مهلة الاتصال بالخادم.");
            }
            catch (JsonException)
            {
                return CreateErrorResponse(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch (Exception)
            {
                return CreateErrorResponse(
                    "حدث خطأ غير متوقع أثناء تسجيل الدخول.");
            }
        }

        private static ApiResponse<TokenResponse> CreateErrorResponse(
            string message,
            int statusCode = 500)
        {
            return new ApiResponse<TokenResponse>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}