using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMBooks.Web.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public JsonResult CreateUser(UserViewModel user)
        {
            var createdUser = UserCore.Create(user);
            return Json(createdUser);
        }
    }
}