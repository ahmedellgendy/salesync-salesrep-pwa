namespace Salesync.SalesRep.Pwa.Models.Responses.Reports
{
    public class SupervisorVisitReportItemDto
    {
        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime? EndTime { get; set; }
        public int SalesRepId { get; set; }
        public string SalesRepName { get; set; }= string.Empty;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }= string.Empty;
        public int? RouteId { get; set; }
        public int? VisitType { get; set; }
        public int Status { get; set; }
        public int? NegativeReason { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentId { get; set; }
        public int? InvoiceReturnId { get; set; }
        public string? Notes { get; set; }
    }
}