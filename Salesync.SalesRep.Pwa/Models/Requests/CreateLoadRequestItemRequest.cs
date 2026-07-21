namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateLoadRequestItemRequest
    {
        public int ProductId { get; set; }

        public int RequestedQuantity { get; set; }

        public string? Notes { get; set; }
    }
}