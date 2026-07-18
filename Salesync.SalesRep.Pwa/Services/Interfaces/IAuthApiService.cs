using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces;

public interface IAuthApiService
{
    Task<ApiResponse<TokenResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}