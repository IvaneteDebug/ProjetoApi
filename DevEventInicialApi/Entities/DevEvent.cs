namespace AwesomeDevEvents.Api.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Students = new List<DevEventStudent>();
            IsDelete = false;

        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDelete { get; set; }

        public List<DevEventStudent> Students { get; set; }
        public void UpDate(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;

        }

        public void Delete()
        {
            IsDelete = true;
        }
    }
}
