using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UserRegistrationAppService.DTOs
{
    public class RegistrationInput
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

    }
}
