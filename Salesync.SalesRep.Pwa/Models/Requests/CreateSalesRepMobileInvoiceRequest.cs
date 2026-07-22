namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateSalesRepMobileInvoiceRequest
    {
        public int VisitId { get; set; }
        public int CustomerId { get; set; }
        public int SalesRepSessionId { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? Notes { get; set; }
        public List<CreateSalesRepMobileInvoiceItemRequest> Items { get; set; } = new();
    }

    public class CreateSalesRepMobileInvoiceItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int BonusQuantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}