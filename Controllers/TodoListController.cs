using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoSpa.Models;

namespace TodoSpa.Controllers
{
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        private readonly TodoContext _context;

        public TodoListController(TodoContext context)
        {
            _context = context;
        }

        // GET api/todolist
        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> Gets()
        {
            // TODO: use DTO to return list with tasks count.
            return _context.TodoLists.ToList();
        }

        // GET api/todolist/5
        [HttpGet("{id}")]
        public ActionResult<TodoList> GetById(int id)
        {
            // TODO: Use DTO to Ignore Task.TodoListId property
            TodoList todoList = _context.TodoLists
                .Include(l => l.Tasks)
                .Single(l => l.Id == id);

            if (todoList == null)
            {
                return NotFound();
            }

            return todoList;
        }

        // POST api/todolist
        [HttpPost]
        public ActionResult<TodoList> Post([FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.TodoLists.Add(todoList);
            _context.SaveChanges();

            return todoList;
        }
    }
}
