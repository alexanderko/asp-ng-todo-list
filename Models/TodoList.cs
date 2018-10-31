using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TodoSpa.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        public List<Task> Tasks { get; set; }
    }
}
