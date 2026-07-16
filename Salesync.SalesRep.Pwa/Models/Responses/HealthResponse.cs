namespace Salesync.SalesRep.Pwa.Models.Responses;

public sealed class HealthResponse
{
    public string Status { get; set; } = string.Empty;

    public string Application { get; set; } = string.Empty;

    public DateTime ServerTime { get; set; }
}       