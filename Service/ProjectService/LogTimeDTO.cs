namespace Service.ProjectService
{
    public class LogTimeDTO
    {
        public Guid ProjectKey { get; set; }

        public TimeSpan Duration { get; set; }

        public LogTimeDTO(Guid projectKey, TimeSpan duration)
        {
            ProjectKey = projectKey;
            Duration = duration;
        }
    }
}
