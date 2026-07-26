namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class LoadRequestItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ItemCode { get; set; } = string.Empty;
        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int ConfirmedQuantity { get; set; }
        public int RequestedLargeQuantity { get; set; }
        public int ApprovedLargeQuantity { get; set; }
        public int ConfirmedLargeQuantity { get; set; }
        public string SmallUnit { get; set; } = "قطعة";
        public string LargeUnit { get; set; } = "كرتونة";
        public int UnitsPerLargeUnit { get; set; } = 1;
        public string? Notes { get; set; }
    }
}