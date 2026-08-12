namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateInvoiceReturnRequest
    {
        public int InvoiceId { get; set; }

        public int ReturnReason { get; set; }

        public string? ReasonNotes { get; set; }

        public List<CreateInvoiceReturnItemRequest> Items { get; set; } = new();
    }
}