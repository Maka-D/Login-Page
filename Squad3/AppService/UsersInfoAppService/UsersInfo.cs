using Squad3.AppService.PasswordHashAppService;
using Squad3.AppService.UsersInfoAppService.DTOs;
using Squad3.Core;
using Squad3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UsersInfoAppService
{
    public class UsersInfo : IUsersInfo
    {
        private readonly AppDbContext _repository;
        private readonly IPasswordHash _passHash;
        public UsersInfo(AppDbContext repository, IPasswordHash passHash)
        {
            _repository = repository;
            _passHash = passHash;
        }

        public UsersInfoOutput GetUserInfo(UsersCore user)
        {
            UsersInfoOutput u = new UsersInfoOutput();
            //string hashedPass = _passHash.GetPassword();
            //var user = _repository.Users.Where(x => x.Username == username && x.Password == hashedPass).FirstOrDefault();
            u.Id = user.Id;
            u.Username = user.Username;
            u.Email = user.Email;
            u.CreationTime = user.CreationTime;
            return u;

        }

        //For outputing all data from database
        //public List<UsersInfoOutput> GetUsersInfo()
        //{
        //    List<UsersInfoOutput> Users = new List<UsersInfoOutput>();
        //    foreach(var item in _repository.Users.OrderByDescending(x=>x.CreationTime))
        //    {
        //        UsersInfoOutput get = new UsersInfoOutput();
        //        get.Id = item.Id;
        //        get.Username = item.Username;
        //        get.Email = item.Email;
        //        get.CreationTime = item.CreationTime;
        //        Users.Add(get);
        //    }
        //    return Users;
        //}
    }
}
