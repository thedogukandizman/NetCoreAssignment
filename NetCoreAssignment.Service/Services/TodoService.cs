using AutoMapper;
using NetCoreAssignment.Service.Contracts.Services;
using NetCoreAssignment.Domain.Repositories;
using NetCoreAssignment.Domain.Entities;
using NetCoreAssignment.Service.Contracts.Dtos.Todos;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAssignment.Service.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public TodoService(ITodoRepository todoRepository,IUserRepository userRepository,IMapper mapper)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<TodoListDto>> GetList(GetTodoListDto getTodoListDto)
        {
            var todoList = await _todoRepository.GetListWithUser(getTodoListDto.Status).ToListAsync();
            if (todoList.Count == 0)
                return new List<TodoListDto>();

            return _mapper.Map<List<TodoListDto>>(todoList);
        }

        public async Task CreatAsync(CreateTodoDto model)
        {
            var user = await _userRepository.GetByIdAsync(model.UserId);
            if (user == null) throw new KeyNotFoundException("User not found");

            var todoModel = _mapper.Map<CreateTodoDto, Todo>(model);
            await _todoRepository.CreateAsync(todoModel);
            await _todoRepository.SaveAsync();
        }
        public async Task UpdateAsync(int id, UpdateTodoDto model)
        {
            var todoModel = await _todoRepository.GetByIdAsync(id);
            if (todoModel == null) throw new KeyNotFoundException("Todo not found");

            todoModel.Status = (int)model.Status;
            todoModel.Description = model.Description;
            todoModel.Name = model.Name;

            _todoRepository.Update(todoModel);
            await _todoRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoModel = await _todoRepository.GetByIdAsync(id);
            if(todoModel==null) throw new KeyNotFoundException("Todo not found");

            await _todoRepository.DeleteAsync(id);
            await _todoRepository.SaveAsync();
        }


    }
}
