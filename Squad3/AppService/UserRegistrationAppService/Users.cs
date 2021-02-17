using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Squad3.AppService.PasswordHashAppService;
using Squad3.AppService.UserRegistrationAppService.DTOs;
using Squad3.Core;
using Squad3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Squad3.AppService.UserRegistrationAppService
{
    public class Users :IUsers
    {
        private readonly AppDbContext _regRepository;
        private readonly IPasswordHash _passHash;
        public Users(AppDbContext regRepository, IPasswordHash passHash)
        {
            _regRepository = regRepository;
            _passHash = passHash;
           
        }
        [UnitOfWork]
        public UsersCore Login(string usrnmLog, string pswLog)
        {
            if (usrnmLog != null && pswLog != null)
            {
                var UsersInfo = _regRepository.Users;
                string hashPass = _passHash.GetPassword(pswLog);
                if (UsersInfo.Where(x => x.Username == usrnmLog && x.Password == hashPass).Any())
                {
                    var user = UsersInfo.Where(x => x.Username == usrnmLog && x.Password == hashPass).FirstOrDefault();
                    return user;
                }
                else
                {
                    return new UsersCore();
                }
            }
            else
            {
                return new UsersCore();
            }
        }
        [UnitOfWork]
        public string Registration(RegistrationInput input)
        {
            var UserInfo = _regRepository.Users;
            if(UserInfo.Where(x=>x.Username == input.Username).Any())
            {
                return "UserNameFalse";
            }
            else if(UserInfo.Where(x=>x.Email == input.Email).Any())
            {
                return "InvalidEmail!";
            }
            else
            {
                UsersCore reg = new UsersCore();
                reg.Username = input.Username;
                reg.Email = input.Email;
                string hashPassword = _passHash.GetPassword(input.Password);
                reg.Password = hashPassword;
                _regRepository.Users.Add(reg);
                _regRepository.SaveChanges();
                return "ok";
            }

            

        }

    }
}
