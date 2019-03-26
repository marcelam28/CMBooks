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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public bool CreateBook(DataLayer.Book book)
        {
            bool response = false;
            if (book == null)
            {
                return response;
            }

            var createdBook = BookCore.Create(book);

            return true;
        }
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