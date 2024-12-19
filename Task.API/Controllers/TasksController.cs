using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.API.Data;
using Task.API.Models;
using Task.API.Repository;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // private static readonly List<TodoItem> _todoItems = [];
        private readonly ITodoItemRepository _repository;

        public TodoDbContext TodoDbContext { get; }

        public TasksController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            // var item = _todoDbContext.TodoItems.ToList();
            var item = _repository.GetTodoItems();
            return Ok(item);
        }

        [HttpGet("{id}")]

        public ActionResult<TodoItem> Get(int id)
        {
            // var todoItem = _todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
            var todoItem = _repository.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]

        public ActionResult Post([FromBody] TodoItem todoItem)
        {
            // _todoDbContext.TodoItems.Add(todoItem);
            _repository.AddTodoItem(todoItem);
            // _todoDbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _repository.UpdateTodoItem(todoItem);

            //var todoItemToUpdate = _todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);

            //if (todoItemToUpdate == null)
            //{
            //    return NotFound();
            //}

            //todoItemToUpdate.Title = todoItem.Title;
            //todoItemToUpdate.Description = todoItem.Description;
            //todoItemToUpdate.IsCompleted = todoItem.IsCompleted;
            //_todoDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            _repository.DeleteTodoItem(id);

            //var todoItemToDelete = _todoDbContext.TodoItems.FirstOrDefault(x =>x.Id == id);
            //if (todoItemToDelete == null)
            //{
            //    return NotFound();                
            //}

            //_todoDbContext.TodoItems.Remove(todoItemToDelete);
            //_todoDbContext.SaveChanges();

            return NoContent();
        }
    }
}
