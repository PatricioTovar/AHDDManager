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
using AHDDManagerClass;

namespace AHDDManager.Controllers
{

    public class AccountController : AHDDSecurity
    {
        public ActionResult AssociateProfile()
        {
            ViewBag.AssociateID = Associate.AssociateID;

            return View();
        }

        public ActionResult Collected()
        {
            return View();
        }

        public JsonResult GetStates()
        {
            var result = new Result();
            try
            {
                result.Object = States.GetStates();
            }
            catch (Exception ex)
            {
                result.Res = false;
                result.Message = ex.Message;
            }

            return Json(result);
        }

        public ActionResult MyHours()
        {
            return View();
        }

        public ActionResult ResumeAssociate()
        {
            return View();
        }

        public ActionResult SearchClockIns(string StartDate, string EndDate)
        {
            try
            {
                AssociateHoursWorked objACH = new AssociateHoursWorked(StartDate, EndDate, Associate.AssociateID);

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
                AssociateClockInHistories objACH = new AssociateClockInHistories(StartDate, EndDate, Associate.AssociateID);

                return Json(objACH);
            }
            catch
            {
                return Json("0");
            }



        }

        public JsonResult GetAssociateTransactionPayments(DateTime StartDate, DateTime EndDate)
        {
            Transactions objTs = new Transactions();

            int AssociateID = Associate.AssociateID;

            var ret = objTs.GetTransactionPaymentsReport(StartDate, EndDate, AssociateID);

            return Json(ret);
        }


        public ActionResult SearchClockIns2(string StartDate, string EndDate)
        {
            try
            {
                //get raw associate clockin data
                AssociateClockInHistories objACH = new AssociateClockInHistories();

                var ret = objACH.GetAllClockinsUnfiltered(StartDate, StartDate, Associate.AssociateID);

                Models.Logging.LogEvent("My Hours: ");

                foreach  (AssociateClockInHistory item in ret)
                {
                    Models.Logging.LogEvent(item.LoginDatetime.ToString());
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
                AssociateHoursWorked objACH = new AssociateHoursWorked(StartDate, EndDate, AssociateID);
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