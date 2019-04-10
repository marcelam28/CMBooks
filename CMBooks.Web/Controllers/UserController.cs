using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using CMBooks.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMBooks.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUser(UserViewModel user)
        {
                if (user != null)
                {
                    user.Password = Md5Helper.Hash(user.Password);
                }
                var createdUser = UserCore.Create(user);
                return Json(createdUser);
        }
    }
}