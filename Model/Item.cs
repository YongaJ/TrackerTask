using System.ComponentModel.DataAnnotations;
using TrackerTask.Enums;

namespace TrackerTask.Model
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Title must be minimum 3 characttors")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
