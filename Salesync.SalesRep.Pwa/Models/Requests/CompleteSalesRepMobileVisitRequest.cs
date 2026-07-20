namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CompleteSalesRepMobileVisitRequest
    {
        public int VisitType { get; set; }

        public int? NegativeReason { get; set; }

        public int? InvoiceId { get; set; }

        public int? PaymentId { get; set; }

        public int? InvoiceReturnId { get; set; }

        public string? Notes { get; set; }
    }
}