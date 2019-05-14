using CMBooks.BusinessLogic.Models;
using CMBooks.BussinessLogic.Cores;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using Deventure.DataLayer.EF.Enums;
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

        [HttpPost]
        public JsonResult DeleteComment(Guid commentId)
        {
            var comment = CommentCore.Get(commentId);
            comment.Status = EntityStatus.Deleted;
            var result = CommentCore.Update(comment);

            return Json("ok");
        }
    }
}