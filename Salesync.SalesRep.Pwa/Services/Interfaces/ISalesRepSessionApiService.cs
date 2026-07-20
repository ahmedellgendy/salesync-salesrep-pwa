using Salesync.SalesRep.Pwa.Models.Responses;

namespace Salesync.SalesRep.Pwa.Services.Interfaces
{
    public interface ISalesRepSessionApiService
    {
        Task<ApiResponse<SalesRepMobileTodayDto>?> GetTodayAsync();

        Task<ApiResponse<SalesRepSessionDto>?> StartDayAsync();

        Task<ApiResponse<SalesRepSessionDto>?> CloseDayAsync(int sessionId);
    }
}