namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public int BonusQuantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
