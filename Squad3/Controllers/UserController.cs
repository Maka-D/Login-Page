using Microsoft.AspNetCore.Mvc;
using Squad3.AppService.UserFirstDetailsAppService;
using Squad3.AppService.UserFirstDetailsAppService.DTOs;
using Squad3.AppService.UserRegistrationAppService;
using Squad3.AppService.UserRegistrationAppService.DTOs;
using Squad3.AppService.UsersInfoAppService;
using Squad3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.Controllers
{
    public class UserController : Controller
    {
        private readonly IFirstDetailsInfo _firstInfo;
        private readonly IUsers _user;
        private readonly IUsersInfo _usersInfo;
        public UserController(IUsers user, IUsersInfo usersInfo, IFirstDetailsInfo firstInfo)
        {
            _user = user;
            _usersInfo = usersInfo;
            _firstInfo = firstInfo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Registration(RegistrationInput input)
        {
            string message = _user.Registration(input);
            return Json(message);
        }
        [HttpPost]
        public IActionResult Login(string usrnmLog, string pswLog)
        {
            var user = _user.Login(usrnmLog, pswLog);
            if (user.Username != null)
            {
                return RedirectToAction("Profile", "User", user);
            }
            else
            {
                ViewBag.error = "Username or Password is incorrect!";
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult Profile(UsersCore user)
        {
            var GetUsersInfo = _usersInfo.GetUserInfo(user);
            return View(GetUsersInfo);
        }
        [HttpPost]
        public JsonResult AddFirstDetails(FirstDetailsInput input)
        {
            _firstInfo.Registration(input);
            //string message = _firstInfo.CheckInfo(input);
            return Json("");
        }

    }

}