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
using CMBooks.Web.Helpers;

namespace CMBooks.Web.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        public JsonResult CreateBook(BookViewModel book)
        {
            var file = Request.Files["PictureUrl"];
            var url = AzureHelper.Upload(file, "PictureUrl");
            book.PictureUrl = url;
            var createdBook = BookCore.Create(book);
            return Json(createdBook);
        }
    }
}