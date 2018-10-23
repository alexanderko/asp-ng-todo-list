using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoSpa.Models;
using System.Linq;

namespace TodoSpa.Controllers {
    [Route ("api/tasks")]
    public class TaskController : Controller {

        private readonly TodoContext _context;

        public TaskController(TodoContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ICollection<Task> Get() {
            return _context.Tasks.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Task task) {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Created("api/tasks", task);
        }

    }

}
