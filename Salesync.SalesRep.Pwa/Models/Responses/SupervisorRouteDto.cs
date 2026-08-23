namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SupervisorRouteDto
    {
        public int Id { get; set; }
        public string RouteCode { get; set; }= string.Empty;
        public string Name { get; set; }= string.Empty;
        public int BranchId { get; set; }
        public int? BusinessUnitId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}