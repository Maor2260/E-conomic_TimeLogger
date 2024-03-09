namespace Service.Project
{
    public class CreateProjectDTO
    {
        public string Name { get; set; }

        public DateTime? Deadline { get; set; }
        
        public CreateProjectDTO(string name, DateTime? deadline = null)
        {
            Name = name;
            Deadline = deadline;
        }
    }
}
