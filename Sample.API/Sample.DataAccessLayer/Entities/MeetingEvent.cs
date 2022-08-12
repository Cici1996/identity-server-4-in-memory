namespace Sample.DataAccessLayer.Entities
{
    public class MeetingEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}