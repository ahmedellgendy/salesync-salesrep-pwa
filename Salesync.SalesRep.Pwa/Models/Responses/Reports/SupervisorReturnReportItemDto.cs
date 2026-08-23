namespace Salesync.SalesRep.Pwa.Models.Responses.Reports
{
    public class SupervisorReturnReportItemDto
    {
        public int ReturnId { get; set; }
        public string ReturnNumber { get; set; }= string.Empty;
        public DateTime ReturnDate { get; set; }
        public int SalesRepId { get; set; }
        public string SalesRepName { get; set; }= string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }= string.Empty;
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }= string.Empty;
        public int ReturnReason { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string? ReasonNotes { get; set; }
    }
}