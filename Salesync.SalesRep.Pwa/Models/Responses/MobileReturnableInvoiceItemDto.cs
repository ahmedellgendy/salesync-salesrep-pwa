namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class MobileReturnableInvoiceItemDto
    {
        public int InvoiceItemId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ItemCode { get; set; } = string.Empty;

        public int SoldQuantity { get; set; }

        public int BonusQuantity { get; set; }

        public int PreviouslyReturnedQuantity { get; set; }

        public int PreviouslyReturnedBonusQuantity { get; set; }

        public int RemainingReturnableQuantity { get; set; }

        public int RemainingReturnableBonusQuantity { get; set; }

        public string SmallUnit { get; set; } = "قطعة";

        public string LargeUnit { get; set; } = "كرتونة";

        public int UnitsPerLargeUnit { get; set; } = 1;

        public decimal UnitPrice { get; set; }
    }
}