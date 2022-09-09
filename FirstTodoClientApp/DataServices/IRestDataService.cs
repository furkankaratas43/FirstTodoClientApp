using FirstTodoClientApp.Models;

namespace FirstTodoClientApp.DataServices
{
    public interface IRestDataService
    {

        Task<List<ToDo>> GetAllTodosAsync();
        Task AddTodoAsync(ToDo toDo);
        Task UpdateTodoAsync(ToDo toDo);
        Task DeleteTodoAsync(int id);
    }
}