using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.BussinessLogic.Helpers;
using CMBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMBooks.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var books = BookCore.GetAll(new[] { nameof(Book.Rates),
                                                $"{nameof(Book.Comments)}.{nameof(DataLayer.Comment.User)}"
            });
            List<BookViewModel> booksVMList = DLtoModelsConvertor.ConvertBookDLIntoBookVM(books);

            return View(booksVMList);
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
                books = BookCore.GetList(b => b.Genre == genre, new[] { nameof(Book.Rates) ,
                                                                $"{nameof(Book.Comments)}.{nameof(DataLayer.Comment.User)}"});
            }
            List<BookViewModel> booksVMList = DLtoModelsConvertor.ConvertBookDLIntoBookVM(books);

            return PartialView("~/Views/Home/_BooksGallery.cshtml", booksVMList);
        }

        public PartialViewResult GetBookDetails(Guid id)
        {
            DataLayer.Book book;
            if (id == Guid.Empty)
            {
                return null;
            }
            else
            {
                book = BookCore.Get(id, new[] { nameof(Book.Rates),
                                                 $"{nameof(Book.Comments)}.{nameof(DataLayer.Comment.User)}"});
            }
            BookViewModel bookVM = DLtoModelsConvertor.ConvertBookDLIntoBookVM(book);
            return PartialView("~/Views/Home/_BookDetails.cshtml", bookVM);
        }

        //public PartialViewResult GetBookComments(Guid id)
        //{
        //    DataLayer.Book book;
        //    if (id == Guid.Empty)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        book = BookCore.Get(id, new[] { nameof(Book.Rates), nameof(Book.Comments) });
        //    }
        //    BookViewModel bookVM = DLtoModelsConvertor.ConvertBookDLIntoBookVM(book);
        //    return PartialView("~/Views/Home/_BookComments.cshtml", bookVM.Comments);
        //}

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