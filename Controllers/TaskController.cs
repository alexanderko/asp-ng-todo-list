using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoSpa.Models;

namespace TodoSpa.Controllers {
    [Route ("api/tasks")]
    public class TaskController : Controller {
        static ICollection<Task> tasks;

        static TaskController()
        {
            tasks = new List<Task> {
                new Task { Title = "Register on Meetup" },
                new Task { Title = "Get amazed by ASP.NET Core" },
                new Task { Title = "Apply to InterLink inCamp" },
            };
        }

        [HttpGet]
        public ICollection<Task> Get() {
            return tasks;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Task task) {
            tasks.Add(task);
            return Created("api/tasks", task);
        }

    }

}
