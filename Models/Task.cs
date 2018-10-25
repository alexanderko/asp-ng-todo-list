 using System.ComponentModel.DataAnnotations;

namespace TodoSpa.Models
{
    public class Task
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MinLength(2)]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public int TodoListId { get; set; }
    }
}
