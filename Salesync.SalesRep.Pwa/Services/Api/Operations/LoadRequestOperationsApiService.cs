using Salesync.SalesRep.Pwa.Models.Requests.Operations.LoadRequests;
using Salesync.SalesRep.Pwa.Models.Responses;
using System.Net.Http.Json;

namespace Salesync.SalesRep.Pwa.Services.Api.Operations;

public sealed class LoadRequestOperationsApiService
{
    private readonly HttpClient _httpClient;

    public LoadRequestOperationsApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<IEnumerable<LoadRequestDto>>?> GetAllAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<
                ApiResponse<IEnumerable<LoadRequestDto>>>(
                "api/loadrequest");
    }

    public async Task<ApiResponse<IEnumerable<LoadRequestDto>>?> GetPendingAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<
                ApiResponse<IEnumerable<LoadRequestDto>>>(
                "api/loadrequest/pending");
    }

    public async Task<ApiResponse<IEnumerable<LoadRequestDto>>?> GetApprovedAsync()
    {
        return await _httpClient
            .GetFromJsonAsync<
                ApiResponse<IEnumerable<LoadRequestDto>>>(
                "api/loadrequest/approved");
    }

    public async Task<ApiResponse<LoadRequestDto>?> GetByIdAsync(int id)
    {
        return await _httpClient
            .GetFromJsonAsync<
                ApiResponse<LoadRequestDto>>(
                $"api/loadrequest/{id}");
    }

    public async Task<ApiResponse<LoadRequestDto>?> ApproveAsync(int id,ApproveLoadRequestRequest request)
    {
        var response =
            await _httpClient.PutAsJsonAsync(
                $"api/loadrequest/{id}/approve",
                request);

        return await response.Content.ReadFromJsonAsync<ApiResponse<LoadRequestDto>>();
    }

    public async Task<ApiResponse<LoadRequestDto>?> RejectAsync(int id,RejectLoadRequestRequest request)
    {
        var response =await _httpClient.PutAsJsonAsync(
                $"api/loadrequest/{id}/reject",
                request);

        return await response.Content.ReadFromJsonAsync<ApiResponse<LoadRequestDto>>();
    }
}