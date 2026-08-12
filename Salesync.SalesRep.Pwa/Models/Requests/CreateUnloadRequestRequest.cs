namespace Salesync.SalesRep.Pwa.Models.Requests
{
    public class CreateUnloadRequestRequest
    {
        public int SalesRepSessionId { get; set; }

        public int WarehouseId { get; set; }

        public string? SalesRepNotes { get; set; }
    }
}