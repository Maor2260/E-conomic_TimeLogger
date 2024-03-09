namespace Facade.Project
{
    [Serializable]
    public class CreateProjectRequest
    {
        public string Name { get; set; }

        //public string Description { get; set; }

        public DateTime? Deadline { get; set; }
    }
}
