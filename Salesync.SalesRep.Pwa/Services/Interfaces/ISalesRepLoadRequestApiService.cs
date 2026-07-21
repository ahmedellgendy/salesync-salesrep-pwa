using Salesync.SalesRep.Pwa.Models.Requests;
using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepLoadRequestApiService
    {
        Task<ApiResponse<LoadRequestDto>?> CreateAsync(CreateLoadRequestRequest request);

        Task<ApiResponse<IEnumerable<LoadRequestDto>>?> GetBySalesRepAsync(int salesRepId);

        Task<ApiResponse<IEnumerable<SalesRepInventoryDto>>?> GetInventoryAsync(int salesRepId);
    }
}