using Salesync.SalesRep.Pwa.Models.Responses;
using System.Net.Http.Json;

namespace Salesync.SalesRep.Pwa.Services.Api.Supervisor
{
    public sealed class SupervisorSalesRepApiService
    {
        private readonly HttpClient _httpClient;

        public SupervisorSalesRepApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<IEnumerable<SupervisorSalesRepDto>>?>GetMyTeamAsync()
        {
            return await _httpClient.GetFromJsonAsync<
                    ApiResponse<IEnumerable<SupervisorSalesRepDto>>>("api/SalesRep/my-team");
        }

        public async Task<ApiResponse<IEnumerable<SupervisorRouteDto>>?>GetSalesRepRoutesAsync(int salesRepId)
        {
            return await _httpClient
                .GetFromJsonAsync<
                    ApiResponse<IEnumerable<SupervisorRouteDto>>>($"api/Route/by-salesrep/{salesRepId}");
        }

        public async Task<ApiResponse<IEnumerable<SupervisorRouteCustomerDto>>?>GetRouteCustomersAsync(int routeId)
        {
            return await _httpClient
                .GetFromJsonAsync<
                    ApiResponse<IEnumerable<SupervisorRouteCustomerDto>>>($"api/RouteCustomer/route/{routeId}/customers");
        }
    }
}