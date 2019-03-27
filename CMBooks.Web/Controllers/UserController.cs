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

        public bool CreateUser(DataLayer.User user)
        {
            bool response = false;
            if (user == null)
            {
                return response;
            }

            var createdUser = UserCore.Create(user);

            return true;
        }
    }
}