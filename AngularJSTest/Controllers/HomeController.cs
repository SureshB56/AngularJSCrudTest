using AngularJSTest.DBConnectionString;
using AngularJSTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSTest.Controllers
{
    public class HomeController : Controller
    {
        DB DBconnection = new DB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show_data()
        {
            return View();
        }

        public ActionResult Update_data()
        {
            return View();
        }

        [Route("~/Home/AddUser")]
        [HttpPost]
        public JsonResult AddUser(UserInfo userInfo)
        {
            string res = string.Empty;
            try
            {
                DBconnection.PostUserInfo(userInfo);
                res = "Insert";
            }
            catch(Exception ex)
            {
                res = "faild";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        [Route("~/Home/Getdata")]
        [HttpGet]
        public JsonResult Getdata(string Name = null, string Email = null, string PhoneNumber = null)
        {
            List<UserInfo> listrs = new List<UserInfo>();
            listrs = DBconnection.GetUserRoleList(Name, Email, PhoneNumber);

            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
    }
}