namespace Salesync.SalesRep.Pwa.Models.Responses.Reports
{
    public class SupervisorSalesReportItemDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }= string.Empty;
        public DateTime InvoiceDate { get; set; }
        public int SalesRepId { get; set; }
        public string SalesRepName { get; set; }= string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }= string.Empty;
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentStatus { get; set; }
    }
}