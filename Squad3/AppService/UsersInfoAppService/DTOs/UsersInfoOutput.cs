using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UsersInfoAppService.DTOs
{
    public class UsersInfoOutput
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreationTime { get; set; } 
    }
}
