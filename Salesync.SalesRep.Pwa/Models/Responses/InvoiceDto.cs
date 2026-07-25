namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public int WarehouseId { get; set; }
        public int? SalesRepId { get; set; }
        public int? SalesRepSessionId { get; set; }

        public int SalesChannel { get; set; }
        public int Status { get; set; }
        public int PaymentStatus { get; set; }

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }

        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<InvoiceItemDto> InvoiceItems { get; set; } = new();
    }
}