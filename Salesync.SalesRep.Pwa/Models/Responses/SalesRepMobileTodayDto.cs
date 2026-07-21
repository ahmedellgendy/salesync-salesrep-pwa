namespace Salesync.SalesRep.Pwa.Models.Responses
{
    public class SalesRepMobileTodayDto
    {
        public bool HasOpenSession { get; set; }

        public SalesRepSessionDto? Session { get; set; }
    }
}
