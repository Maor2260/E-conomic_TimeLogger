using System.ComponentModel.DataAnnotations;

namespace DataModel.Entities
{
    public class TimeLog
    {
        [Key]
        public Guid Key { get; set; }

        //public string? Description { get; set; }

        public TimeSpan Duration { get; set; }

        //public DateTime Start { get; set; }

        //public DateTime? End { get; set; }
    }
}
