using Salesync.SalesRep.Pwa.Models.Responses;
using Salesync.SalesRep.Pwa.Models.Responses.Profile;
using System.Net.Http.Json;

namespace Salesync.SalesRep.Pwa.Services.Api
{
    public sealed class ProfileApiService
    {
        private readonly HttpClient _httpClient;

        public ProfileApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<CurrentUserProfileDto>?> GetMyProfileAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<ApiResponse<CurrentUserProfileDto>>(
                    "api/profile/me");
        }
    }
}