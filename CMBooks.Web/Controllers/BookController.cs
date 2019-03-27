﻿using CMBooks.BussinessLogic.Cores;
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
        
    }
}