using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class AppointmentsController : Models.AHDDSecurity
    {
        // GET: Appointments
        public ActionResult Index()
        {
            ViewBag.AssociateID = base.Associate.AssociateID;
            return View();
        }



        public ActionResult GetAppointments(int Month, int Year)
        {
            AHDDManagerClass.Appointments objAppts = new AHDDManagerClass.Appointments(Month, Year);

            return Json(objAppts, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteAppointment(int AppointmentID)
        {
            AHDDManagerClass.Appointment objA = new AHDDManagerClass.Appointment();

            if (objA.Delete(AppointmentID))
            {
                return Json("1");
            }
            else
            {
                AHDDManager.Models.Logging.LogEvent("Event add FAILED");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Failed to add appointment.");
            }
        }

        public ActionResult AddAppointment(AHDDManagerClass.Appointment appointment)
        {
            appointment.CreatedBy = base.Associate.AssociateID;
            appointment.BusinessID = base.Business.BusinessID;

            AHDDManager.Models.Logging.LogEvent("Event to Add by " + appointment.AssignedTo + " - TITLE: " + appointment.AppointmentName + " | Start Date: " + appointment.StartDateString + " (" + appointment.StartDateString + ")");

            if (appointment.Update())
            {
                appointment = new AHDDManagerClass.Appointment(appointment.AppointmentID);

                AHDDManager.Models.Logging.LogEvent("Event: Appt id - " + appointment.AppointmentID);

                return Json(appointment, JsonRequestBehavior.AllowGet);
            }
            else
            {
                AHDDManager.Models.Logging.LogEvent("Event add FAILED");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Failed to add appointment.");
            }
        }

        public ActionResult UpdateAppointment(int AppointmentID, string StartDate, string EndDate)
        {
            AHDDManagerClass.Appointment objA = new AHDDManagerClass.Appointment();

            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

            var x = (Convert.ToDateTime(StartDate)).ToUniversalTime();
            DateTime start = TimeZoneInfo.ConvertTimeFromUtc(x, cstZone);

            var y = (Convert.ToDateTime(EndDate)).ToUniversalTime();
            DateTime end = TimeZoneInfo.ConvertTimeFromUtc(y, cstZone);

            if (objA.UpdateTimes(AppointmentID, start, end))
            {
                return Json("1");
            }
            else
            {
                AHDDManager.Models.Logging.LogEvent("Event update FAILED");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Failed to update appointment.");
            }
        }

        public ActionResult UpdateAppointmentInfo(int ApptID, string Title, string Description)
        {
            AHDDManagerClass.Appointment objA = new AHDDManagerClass.Appointment(ApptID);

            objA.AppointmentName = Title;
            objA.Description = Description;

            if (objA.Update())
            {
                return Json("1");
            }
            else
            {
                AHDDManager.Models.Logging.LogEvent("Event update FAILED");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Failed to update appointment.");
            }
        }

    }
}