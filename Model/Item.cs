using System.ComponentModel.DataAnnotations;
using TrackerTask.Enums;

namespace TrackerTask.Model
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public Proirity Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
