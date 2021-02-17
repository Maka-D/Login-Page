using Squad3.AppService.UserRegistrationAppService.DTOs;
using Squad3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UserRegistrationAppService
{
    public interface IUsers 
    {
        string Registration(RegistrationInput input);
        UsersCore Login(string usrnmLog, string pswLog);
    }
}
