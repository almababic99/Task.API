using Task.API.Models;

namespace Task.API.Repository
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetTodoItems();

        TodoItem GetTodoItem(int id);

        void AddTodoItem(TodoItem todoItem);

        void UpdateTodoItem(TodoItem todoItem);

        void DeleteTodoItem(int id);
    }
}
