using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AHDDManager.Models;

namespace AHDDManager.Controllers
{

    public class AccountController : AHDDSecurity
    {
        public ActionResult AssociateProfile()
        {
            ViewBag.AssociateID = base.Associate.AssociateID;

            return View();
        }

        public ActionResult Collected()
        {
            return View();
        }

        public JsonResult GetStates()
        {
            return Json(AHDDManager.Models.States.GetStates());
        }

        public ActionResult MyHours()
        {
            return View();
        }

        public ActionResult SearchClockIns(string StartDate, string EndDate)
        {
            try
            {
                AHDDManagerClass.AssociateHoursWorked objACH = new AHDDManagerClass.AssociateHoursWorked(StartDate, EndDate, base.Associate.AssociateID);

                return Json(objACH);
            }
            catch
            {
                return Json("0");
            }



        }

        public ActionResult SearchClockInsUnfiltered(string StartDate, string EndDate)
        {
            try
            {
                AHDDManagerClass.AssociateClockInHistories objACH = new AHDDManagerClass.AssociateClockInHistories(StartDate, EndDate, base.Associate.AssociateID);

                return Json(objACH);
            }
            catch
            {
                return Json("0");
            }



        }




        public ActionResult SearchClockIns2(string StartDate, string EndDate)
        {
            try
            {
                //get raw associate clockin data
                AHDDManagerClass.AssociateClockInHistories objACH = new AHDDManagerClass.AssociateClockInHistories();

                var ret = objACH.GetAllClockinsUnfiltered(StartDate, StartDate, base.Associate.AssociateID);

                AHDDManager.Models.Logging.LogEvent("My Hours: ");

                foreach  (AHDDManagerClass.AssociateClockInHistory item in ret)
                {
                    AHDDManager.Models.Logging.LogEvent(item.LoginDatetime.ToString());
                }


                return Json(ret);
            }
            catch
            {
                return Json("0");
            }
        }


        public ActionResult SearchClockInsByID(string StartDate, string EndDate, int AssociateID)
        {
            try
            {
                //AHDDManagerClass.AssociateClockInHistories objACH = new AHDDManagerClass.AssociateClockInHistories();
                AHDDManagerClass.AssociateHoursWorked objACH = new AHDDManagerClass.AssociateHoursWorked(StartDate, EndDate, AssociateID);
                //var ret = objACH.GetAllClockinsUnfiltered(StartDate, EndDate, AssociateID);
                

                return Json(objACH);
            }
            catch
            {
                return Json("0");
            }
        }




    }
}