using Abp.Domain.Uow;
using Squad3.AppService.UserFirstDetailsAppService.DTOs;
using Squad3.Core;
using Squad3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.AppService.UserFirstDetailsAppService
{
    public class FirstDetailsInfo : IFirstDetailsInfo
    {
        private readonly AppDbContext _regRepository;
        public FirstDetailsInfo(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }
        [UnitOfWork]
        public FirstDetailsInput Registration(FirstDetailsInput input)
        {
            var r = new UsersFirstDetailsInfoCore();
            r.Name = input.Name;
            r.Surname = input.Surname;
            r.Age = input.Age;
            r.Gender = input.Gender;
            r.DateTime = DateTime.Now;
            r.UserId = input.UserId;
            _regRepository.UsersFirstDetailsInfoCores.Add(r);
            _regRepository.SaveChanges();
            FirstDetailsInput u = new FirstDetailsInput();
            u.Name = input.Name;
            u.Name = input.Name;
            u.Surname = input.Surname;
            u.Age = input.Age;
            u.UserId = input.UserId;
            return u;
        }
        //[UnitOfWork] homework#1
        //public FirstDetailsInput CheckInfo(FirstDetailsInput input)
        //{
        //    var userInput = Registration(input);
        //    var userInfo = _regRepository.UsersFirstDetailsInfoCores;
        //    if (userInfo.Where(x=>x.UserId == userInput.UserId).Any())
        //    {
        //        return userInput;
        //    }
        //    else
        //    {
        //        return userInput;
        //    }
        //}
    }
}
