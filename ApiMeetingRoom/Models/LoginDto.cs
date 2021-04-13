using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeetingRoom.Models
{
    public class LoginDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
        public Guid RoleId { get; set; }
    }
}
