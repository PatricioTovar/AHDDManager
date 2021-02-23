using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            string user;
            try
            {
                if (Session["Associate"] != null)
                {
                    user = ((AHDDManagerClass.Associate)Session["Associate"]).UserName;
                }
                else
                {
                    user = "unknown";
                }
            }
            catch
            {
                user = "unknown";
            }


            AHDDManager.Models.Logging.LogClockIn("User Logged OUT: " + user, user);

            Session.Abandon();

            return Redirect("/home/");
        }
    }
}