namespace AwesomeDevEvents.Api.Entities
{
    public class DevEventStudent
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? TalkTitle { get; set; }
        public string? Talkdescription { get; set; }
        public string? LinkedInProfile { get; set; }
    }
}
