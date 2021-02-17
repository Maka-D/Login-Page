using Squad3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UserFirstDetailsAppService.DTOs
{
    public class FirstDetailsInput
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public GenderEnum? Gender { get; set; }
        public int UserId { get; set; }
    }
}
