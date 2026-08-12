namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateInvoiceReturnItemRequest
    {
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public int BonusQuantity { get; set; }
        public int Condition { get; set; }
        public string? Notes { get; set; }
    }
}