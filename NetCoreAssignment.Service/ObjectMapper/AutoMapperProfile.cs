namespace NetCoreAssignment.Service.ObjectMapper;

using AutoMapper;
using NetCoreAssignment.Service.Contracts.Dtos.Users;
using NetCoreAssignment.Service.Contracts.Dtos.Todos;
using NetCoreAssignment.Domain.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<User, LoginResponseDto>();
        CreateMap<RegisterDto, User>().ForMember(x => x.Password, opt => opt.Ignore());

        CreateMap<Todo, TodoDto>();
        CreateMap<CreateTodoDto, Todo>()
            .ForMember(des => des.Status, opt => opt.MapFrom(x => (int)x.Status));
        CreateMap<Todo, TodoListDto>()
                    .ForMember(des => des.UserEmail, opt => opt.MapFrom(x => x.User.Email));
        CreateMap<UpdateTodoDto, Todo>();
    }
}