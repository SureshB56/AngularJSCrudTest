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
            catch (Exception ex)
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


     



        [Route("~/Home/UpdateUser")]
        [HttpPost]
        public JsonResult update_record(UserInfo userInfo)

        {

            string res = string.Empty;
            try
            {
                DBconnection.UpdaetUserInfo(userInfo);
                res = "Update";
            }
            catch (Exception ex)
            {
                res = "faild";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);




        }


       
        public JsonResult delete_record(int id)

        {

            string res = string.Empty;
            try
            {
                DBconnection.DeleteUserInfo(id);
                res = "Deleted";
            }
            catch (Exception ex)
            {
                res = "faild";
                throw;
            }
            return Json(res, JsonRequestBehavior.AllowGet);




        }


        public JsonResult Get_databyid(int id)

        {

            DataSet ds = DBconnection.get_recordbyid(id);

            List<UserInfo> listrs = new List<UserInfo>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new UserInfo

                {

                    UserTableID = Convert.ToInt32(dr["UserTableID"]),

                    FirstName = dr["FirstName"].ToString(),

                    LastName = dr["LastName"].ToString(),

                    Email = dr["Email"].ToString(),

                    PhoneNumber = dr["PhoneNumber"].ToString(),

                    Address = dr["Address"].ToString(),

                    City = dr["City"].ToString(),
                    State = dr["State"].ToString(),


                    Country = dr["Country"].ToString(),
                    PostalCode = dr["PostalCode"].ToString(),


                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

    

     

    }
}