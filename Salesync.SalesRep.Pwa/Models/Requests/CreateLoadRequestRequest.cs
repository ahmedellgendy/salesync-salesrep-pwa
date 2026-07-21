namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateLoadRequestRequest
    {
        public int? SalesRepId { get; set; }

        public int WarehouseId { get; set; }

        public string? Notes { get; set; }

        public List<CreateLoadRequestItemRequest> Items { get; set; } = new();
    }
}