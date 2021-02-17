using Squad3.AppService.UsersInfoAppService.DTOs;
using Squad3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UsersInfoAppService
{
    public interface IUsersInfo
    {
        //List<UsersInfoOutput> GetUsersInfo();
        public UsersInfoOutput GetUserInfo(UsersCore user);
    }
}
