namespace Facade.Project
{
    [Serializable]
    public class LogTimeRequest
    {
        public Guid ProjectKey { get; set; }

        public Duration Duration { get; set; }
    }
}
