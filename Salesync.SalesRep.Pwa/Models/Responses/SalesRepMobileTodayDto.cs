namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SalesRepMobileTodayDto
    {
        public bool HasTodaySession { get; set; }

        public bool HasOpenSession { get; set; }

        public bool IsDayClosed { get; set; }

        public SalesRepSessionDto? Session { get; set; }
    }
}