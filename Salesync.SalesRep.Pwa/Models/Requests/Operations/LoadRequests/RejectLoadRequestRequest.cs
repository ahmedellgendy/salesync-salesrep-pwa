namespace Salesync.SalesRep.Pwa.Models.Requests.Operations.LoadRequests;

public sealed class RejectLoadRequestRequest
{
    public string RejectionReason { get; set; } = string.Empty;
}