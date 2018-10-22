using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoSpa.Models;

namespace TodoSpa.Controllers {
    [Route ("api/tasks")]
    public class TaskController : Controller {
        [HttpGet ("")]
        public ICollection<Task> Get () {
            var tasks = new List<Task> {
                new Task { Title = "Register on Meetup" },
                new Task { Title = "Get amazed by ASP.NET Core" },
                new Task { Title = "Apply to InterLink inCamp" },
            };

            return tasks;
        }

    }

}
