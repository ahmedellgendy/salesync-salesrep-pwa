namespace Salesync.SalesRep.Pwa.Models.Requests.Operations.LoadRequests;

public sealed class ApproveLoadRequestRequest
{
    public List<ApproveLoadRequestItemRequest> Items { get; set; } = new();

    public string? Notes { get; set; }
}

public sealed class ApproveLoadRequestItemRequest
{
    public int LoadRequestItemId { get; set; }

    public int ApprovedLargeQuantity { get; set; }
}