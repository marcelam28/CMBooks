using CMBooks.BussinessLogic.Cores;
using CMBooks.Common.Response;
using CMBooks.Web.Helpers;
using CMBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMBooks.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(LoginModel model)
        {
            var response = ResponseFactory.Success(ResponseCode.SuccessLoggedIn);
            if (model == null)
            {
                return Json(ResponseFactory.Error(ResponseCode.ErrorInvalidInput),JsonRequestBehavior.AllowGet);
            }

            var user = UserCore.GetSingle(userTemp => userTemp.Email == model.Email);
            if (user == null)
            {
                return Json(ResponseFactory.Error(ResponseCode.ErrorEmailInvalid), JsonRequestBehavior.AllowGet);
            }

            var check = Md5Helper.VerifyPassword(model.Password,user.Password);

            if (check == false)
            {
                return Json(ResponseFactory.Error(ResponseCode.ErrorInvalidPassword), JsonRequestBehavior.AllowGet);
            }

            if (user.IsAdmin == true)
            {
                Session["isAdmin"] = true;
            }
            Session["userId"] = user.Id;
            Session["userName"] = user.FirstName;
            return Json(response);
        }

        [HttpPost]
        public JsonResult LogOut()
        {
            Session.Abandon(); // it will clear the session at the end of request
            return Json("Ok");
        }
    }
}
