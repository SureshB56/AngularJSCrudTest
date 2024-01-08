using AngularJSTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace AngularJSTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("api/login")]


        public async Task<ActionResult> login(LoginModel LoginModel)
        {
            try
            {
                int keyLength = 30;
                string base64Key = string.Empty;
                using (var rng = new RNGCryptoServiceProvider())
                {
                    byte[] keyBytes = new byte[keyLength];
                    rng.GetBytes(keyBytes);
                    base64Key = Convert.ToBase64String(keyBytes);

                }

                if (!ModelState.IsValid)
                {
                    return View("Login", LoginModel);
                }
                string encrptpwd = LoginModel.Password;
                var userPassword = Convert.ToString(ConfigurationManager.AppSettings["config:Password"]);
                var userName = Convert.ToString(ConfigurationManager.AppSettings["config:UserName"]);

                var roles = new string[] { "superAdmin", "Admin" };
                var JwtSecurityToken = Authentication.GenerateJWTToken("Admin", roles.ToList(), base64Key);
                Session["LoginID"] = userName;

            
                var validuserName = Authentication.ValidateToken(JwtSecurityToken, base64Key);
                return RedirectToAction("Index", "Home");


                ModelState.AddModelError("", "Invaild UserName or Password");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Invaild UserName or Password");
            }
            return View("Login", LoginModel);
        }



    }
}