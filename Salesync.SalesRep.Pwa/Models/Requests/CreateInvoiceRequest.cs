namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateInvoiceRequest
    {
        public int CustomerId { get; set; }

        public int WarehouseId { get; set; }

        public int? SalesRepSessionId { get; set; }

        public int SalesChannel { get; set; } = 1;

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public string? Notes { get; set; }

        public List<CreateInvoiceItemRequest> Items { get; set; } = new();
    }
}