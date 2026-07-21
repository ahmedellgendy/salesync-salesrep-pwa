namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class StartSalesRepMobileVisitRequest
    {
        public int CustomerId { get; set; }
        public int RouteId { get; set; }
        public int SalesRepSessionId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Notes { get; set; }
    }
}