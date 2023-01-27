using NetCoreAssignment.Service.Contracts.Dtos.Todos;

namespace NetCoreAssignment.Service.Contracts.Services
{
    public interface ITodoService
    {
        Task<List<TodoListDto>> GetList(GetTodoListDto getTodoListDto);

        Task CreatAsync(CreateTodoDto model);

        Task UpdateAsync(int id, UpdateTodoDto model);
        Task DeleteAsync(int id);
    }
}
