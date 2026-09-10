using Salesync.SalesRep.Pwa.Common;
using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public class SalesRepRouteApiService : ISalesRepRouteApiService
    {
        private readonly HttpClient _httpClient;

        public SalesRepRouteApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SalesyncApi");
        }

        public async Task<ApiResponse<IEnumerable<SalesRepMobileRouteDto>>?> GetRoutesAsync(int sessionId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepMobileRouteDto>>>(
                        $"api/mobile/salesrep/routes?sessionId={sessionId}");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepMobileRouteDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileRouteDto>>(
                    AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileRouteDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileRouteDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل خطوط السير.");
            }
        }

        public async Task<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>?> GetRouteCustomersAsync(
            int sessionId,
            int routeId)
        {
            try
            {
                var response = await _httpClient
                    .GetFromJsonAsync<ApiResponse<IEnumerable<SalesRepMobileCustomerDto>>>(
                        $"api/mobile/salesrep/routes/{routeId}/customers?sessionId={sessionId}");

                return response ?? CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "لم يتم استلام استجابة صحيحة من الخادم.");
            }
            catch (HttpRequestException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    AppMessages.ConnectionError);
            }
            catch (JsonException)
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "صيغة الاستجابة القادمة من الخادم غير صحيحة.");
            }
            catch
            {
                return CreateErrorResponse<IEnumerable<SalesRepMobileCustomerDto>>(
                    "حدث خطأ غير متوقع أثناء تحميل عملاء خط السير.");
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