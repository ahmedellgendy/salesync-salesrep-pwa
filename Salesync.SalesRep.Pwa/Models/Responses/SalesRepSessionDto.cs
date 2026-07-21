namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SalesRepSessionDto
    {
        public int Id { get; set; }
        public int SalesRepId { get; set; }
        public DateTime WorkingDate { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal GrossSales { get; set; }
        public decimal NetSales { get; set; }
        public decimal TotalCollection { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public int TotalInvoices { get; set; }
        public int TotalVisits { get; set; }
        public string? Notes { get; set; }
    }
}