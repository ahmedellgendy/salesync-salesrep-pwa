namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public string PaymentNumber { get; set; } = string.Empty;

        public int InvoiceId { get; set; }

        public decimal Amount { get; set; }

        public int PaymentMethod { get; set; }

        public int Status { get; set; }

        public DateTime PaymentDate { get; set; }

        public int? SalesRepId { get; set; }

        public int? SalesRepSessionId { get; set; }

        public string? Notes { get; set; }
    }
}