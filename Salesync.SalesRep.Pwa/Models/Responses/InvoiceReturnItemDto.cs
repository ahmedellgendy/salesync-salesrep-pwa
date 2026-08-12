namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class InvoiceReturnItemDto
    {
        public int Id { get; set; } 
        public int InvoiceItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int BonusQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public int Condition { get; set; }

        public string? Notes { get; set; }
    }
}