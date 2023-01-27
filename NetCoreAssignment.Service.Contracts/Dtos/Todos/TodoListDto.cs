using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAssignment.Service.Contracts.Dtos.Todos
{
    public class TodoListDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string UserEmail { get; set; }
    }
}
