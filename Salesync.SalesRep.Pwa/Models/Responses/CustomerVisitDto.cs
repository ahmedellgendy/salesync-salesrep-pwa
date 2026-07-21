namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class CustomerVisitDto
    {
        public int Id { get; set; }

        public int SalesRepId { get; set; }

        public int CustomerId { get; set; }

        public int? RouteId { get; set; }

        public int SalesRepSessionId { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime? EndTime { get; set; }

        public int? VisitType { get; set; }

        public int Status { get; set; }

        public int? NegativeReason { get; set; }

        public int? InvoiceId { get; set; }

        public int? PaymentId { get; set; }

        public int? InvoiceReturnId { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string? Notes { get; set; }
    }
}