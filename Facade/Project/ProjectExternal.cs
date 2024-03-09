namespace Facade.Project
{
    [Serializable]
    public class ProjectExternal
    {
        public string Name { get; set; }

        //public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public List<Duration> Records { get; set; } = new List<Duration>();
    }
}
