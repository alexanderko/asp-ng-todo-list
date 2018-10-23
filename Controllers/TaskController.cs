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

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Task req) {
            Task task = _context.Tasks.Find(id);

            if (task == null) {
                return NotFound();
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            task.IsDone = req.IsDone;
            task.Title = req.Title;
            _context.Update(task);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Task task) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Created("api/tasks", task);
        }

    }

}
