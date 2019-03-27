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

        
        public bool CreateRate(DataLayer.Rate rate)
        {
            bool response = false;
            if (rate == null)
            {
                return response;
            }

            var createdRate = RateCore.Create(rate);

            return true;
        }
    }
}