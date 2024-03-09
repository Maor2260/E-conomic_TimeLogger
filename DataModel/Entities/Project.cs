using System.ComponentModel.DataAnnotations;

namespace DataModel.Entities
{
    public class Project
    {
        [Key]
        public Guid Key { get; set; }

        public string Name { get; set; }

        //public string? Description { get; set; }

        public DateTime? Deadline { get; set; }

        public List<TimeLog> Logs { get; set; } = new List<TimeLog>(); // 1 -> n relation

        //public DateTime TotalTimeSpent { get; set; } - If storage was an issue.
    }
}
