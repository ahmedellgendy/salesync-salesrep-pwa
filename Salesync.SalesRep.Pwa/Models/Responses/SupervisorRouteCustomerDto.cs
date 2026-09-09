namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SupervisorRouteCustomerDto
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int CustomerId { get; set; }
        public int VisitSequence { get; set; }
        public string? VisitDays { get; set; }
        public string? Notes { get; set; }
        public SupervisorCustomerDto Customer { get; set; } = new();
    }


    public class SupervisorCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Region { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal OrderCeiling { get; set; }
        public string Status { get; set; } = string.Empty;

        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        
        public int? RouteId { get; set; }
        public string? RouteName { get; set; }
    }
}