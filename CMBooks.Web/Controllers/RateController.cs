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
    public class RateController : Controller
    {

        [HttpPost]
        public JsonResult CreateRate(RateViewModel rate)
        {
            var createdRate = RateCore.Create(rate);
            return Json(createdRate);
        }
    }
}