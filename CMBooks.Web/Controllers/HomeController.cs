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
            var books = BookCore.GetAll();
            return View(books);
        }

        public PartialViewResult Filter(string genre)
        {
            IList<DataLayer.Book> books;
            if (string.IsNullOrWhiteSpace(genre))
            {
                books = BookCore.GetAll();
            }
            else
            {
                books = BookCore.GetList(b => b.Genre == genre);
            }
            return PartialView("~/Views/Home/_BooksGallery.cshtml", books);
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
    }
}