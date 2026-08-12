namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class InvoiceReturnDto
    {
        public int Id { get; set; }

        public string ReturnNumber { get; set; } = string.Empty;

        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public int? SalesRepId { get; set; }

        public int? SalesRepSessionId { get; set; }

        public int Status { get; set; }

        public int ReturnReason { get; set; }

        public decimal TotalAmount { get; set; }

        public string? ReasonNotes { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<InvoiceReturnItemDto> Items { get; set; } = new();
    }
}