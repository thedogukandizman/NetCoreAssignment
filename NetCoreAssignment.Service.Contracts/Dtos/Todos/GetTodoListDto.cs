using NetCoreAssignment.Domain.Shared.Types;

namespace NetCoreAssignment.Service.Contracts.Dtos.Todos
{
    public class GetTodoListDto
    {
        public StatusType? Status { get; set; }
    }
}
