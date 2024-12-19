using Microsoft.EntityFrameworkCore;
using Task.API.Data;
using Task.API.Models;

namespace Task.API.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoItemRepository(TodoDbContext todoDbContext) 
        {
            _todoDbContext = todoDbContext;
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _todoDbContext.TodoItems.Add(todoItem);
            _todoDbContext.SaveChanges();
        }

        public void DeleteTodoItem(int id)
        {
            var todoItemToDelete = _todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemToDelete != null)
            {
                _todoDbContext.TodoItems.Remove(todoItemToDelete);
                _todoDbContext.SaveChanges();
            }
        }

        public TodoItem GetTodoItem(int id)
        {
            return _todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _todoDbContext.TodoItems.ToList();
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            var itemToEdit = _todoDbContext.TodoItems.FirstOrDefault(x =>x.Id == todoItem.Id);
            if (itemToEdit != null)
            {
                _todoDbContext.Entry(todoItem).State = EntityState.Modified;
                _todoDbContext.SaveChanges();
            }
        }
    }
}
