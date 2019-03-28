using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.Common.Response;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMBooks.Web.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        public JsonResult CreateBook(BookViewModel book)
        {
            var createdBook = BookCore.Create(book);
            return Json(createdBook);
        }
    }
}