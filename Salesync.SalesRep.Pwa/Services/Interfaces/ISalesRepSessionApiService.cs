using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepSessionApiService
    {
        Task<ApiResponse<SalesRepSessionDto>?> StartDayAsync(int salesRepId);

        Task<ApiResponse<SalesRepSessionDto>?> CloseDayAsync(int sessionId);

        Task<ApiResponse<SalesRepSessionDto>?> GetSessionByIdAsync(int sessionId);

        Task<ApiResponse<IEnumerable<SalesRepSessionDto>>?> GetSessionsBySalesRepAsync(int salesRepId);
    }
}