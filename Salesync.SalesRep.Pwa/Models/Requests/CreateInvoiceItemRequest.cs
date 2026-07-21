namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateInvoiceItemRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int BonusQuantity { get; set; }

        public string? Notes { get; set; }
    }
}