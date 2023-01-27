using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAssignment.Service.Contracts.Dtos.Users
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
