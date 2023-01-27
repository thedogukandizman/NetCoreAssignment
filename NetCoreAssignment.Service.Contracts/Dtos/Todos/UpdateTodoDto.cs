using NetCoreAssignment.Domain.Shared.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAssignment.Service.Contracts.Dtos.Todos
{
    public class UpdateTodoDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public StatusType Status { get; set; }

    }
}
