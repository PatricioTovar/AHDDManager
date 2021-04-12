using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Associate"] != null) {
                return RedirectToAction("Index", "Customer");
            }
                return View();
        }

        [HttpPost]
        [AHDDManager.AjaxSessionExpireActionFilter(Disable = true)]
        public ActionResult Login(string UserName, string Password)
        {
            try
            {
                AHDDManagerClass.Associate objA = new AHDDManagerClass.Associate(UserName, Password);
                AHDDManagerClass.Business objB;
                              
                if (objA.AssociatesExist)
                {

                    objB = new AHDDManagerClass.Business(objA.BusinessID);

                    if (objB.BusinessesExist)
                    {
                        Session["Associate"] = objA;

                        Session["Business"] = objB;

                        Models.Logging.LogClockIn("User Logged in: " + objA.UserName + " (" + objA.FirstName +  " " + objA.LastName + ")", objA.UserName);

                        Session.Timeout = 600;

                        return Json("0");
                    }
                    else
                    {
                        Models.Logging.LogClockIn("User LOGGED in. Could not find business: " + objA.UserName + " (" + objA.FirstName + " " + objA.LastName + ") | " + objA.BusinessID, objA.UserName);
                        return Json("There was an error logining in.");
                    }
                }
                else
                {
                    Models.Logging.LogClockIn("User Login FAILED: " + UserName + " | " + Password, objA.UserName);
                    return Json("Login failed.");
                }
            }
            catch
            {
                Models.Logging.LogClockIn("User Login FAILED: " + UserName + " | " + Password, UserName);
                return Json("There was an error logining in.");
            }
            
        

    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }
}
}