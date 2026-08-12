using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepUnloadRequestApiService
    {
        Task<ApiResponse<SalesRepUnloadRequestDto>?> CreateAsync(CreateUnloadRequestRequest request);

        Task<ApiResponse<IEnumerable<SalesRepUnloadRequestDto>>?> GetMyRequestsAsync();

        Task<ApiResponse<SalesRepUnloadRequestDto>?> GetByIdAsync(int id);

        Task<ApiResponse<string>?> CancelAsync(int id,CancelUnloadRequestRequest request);
    }
}