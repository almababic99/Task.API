using Task.API.Models;

namespace Task.API.Repository
{
    public class NewWayDatabase : ITodoItemRepository
    {
        public void AddTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodoItem(int id)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetTodoItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return new List<TodoItem>()
            {
                new TodoItem
                {
                    Id = 1,
                    Title = "Learn C#",
                    Description = "Learn C# and .NET Core",
                    IsCompleted = false
                },
                new TodoItem
                {
                    Id = 2,
                    Title = "Learn Angular",
                    Description = "Learn Angular and TypeScript",
                    IsCompleted = false
                }
            };
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
