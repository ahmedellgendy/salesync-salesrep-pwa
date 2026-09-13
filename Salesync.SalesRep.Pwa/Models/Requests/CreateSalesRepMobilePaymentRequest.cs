namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateSalesRepMobilePaymentRequest
    {
        public int InvoiceId { get; set; }

        public decimal Amount { get; set; }

        public int PaymentMethod { get; set; } = 1;

        public string? Notes { get; set; }
    }
}