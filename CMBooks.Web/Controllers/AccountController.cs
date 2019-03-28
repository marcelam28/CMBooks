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
                return Json(ResponseFactory.Error(ResponseCode.ErrorInvalidInput));
            }

            var user = UserCore.GetSingle(userTemp => userTemp.Email == model.Email);
            if (user == null)
            {
                return Json(ResponseFactory.Error(ResponseCode.ErrorEmailInvalid));
            }

            var check = Md5Helper.VerifyPassword(model.Password,user.Password);

            if (check == false)
            {
                return Json(ResponseFactory.Error(ResponseCode.ErrorInvalidPassword));
            }

            return Json(response);
        }
    }
}
