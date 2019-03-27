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

        public bool CreateComment(DataLayer.Comment comment)
        {
            bool response = false;
            if (comment == null)
            {
                return response;
            }
            comment.AddedAt = DateTime.Now;
            var createdComment = CommentCore.Create(comment);

            return true;
        }
    }
}