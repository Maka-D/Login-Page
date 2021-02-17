using Squad3.AppService.UserFirstDetailsAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UserFirstDetailsAppService
{
    public interface IFirstDetailsInfo
    {
        FirstDetailsInput Registration(FirstDetailsInput input);
       // string CheckInfo(FirstDetailsInput input);
    }
}
