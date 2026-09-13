namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SupervisorSalesRepDto
    {
        public int Id { get; set; }
        public string SalesRepCode { get; set; }= string.Empty;
        public string Name { get; set; }= string.Empty;
        public string Phone { get; set; }= string.Empty;
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public int? SalesRepType { get; set; }
        public int BranchId { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
   
    }
}