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
    public class CommentController : Controller
    {

        [HttpPost]
        public JsonResult CreateComment(CommentViewModel comment)
        {
            var createdComment = CommentCore.Create(comment);
            return Json(createdComment);
        }
    }
}