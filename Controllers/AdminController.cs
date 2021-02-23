using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class AdminController : Models.AHDDSecurity
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult Payments()
        {
            return View();
        }

        public ActionResult PaymentsDetails()
        {
            return View();
        }

        public ActionResult TransactionsInfo()
        {
            return View();
        }

        public ActionResult ResumeReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DailyInvoices()
        {
            return View();
        }

        public ActionResult AccountsReceivable()
        {
            return View();
        }
        public ActionResult Refunds()
        {
            return View();
        }
        public ActionResult DeletedExpenses()
        {
            return View();
        }

        public ActionResult AssociateHours()
        {
            return View();
        }
        public ActionResult AssociateHoursPrint()
        {
            return View();
        }

        public ActionResult GetAssociateName(int AssociateID)
        {
            try
            {
                AHDDManagerClass.Associate objA = new AHDDManagerClass.Associate(AssociateID);

                if (objA.AssociatesExist)
                {
                    return Json(objA.FirstName + " " + objA.LastName);
                }
                else
                {
                    return Json("Name: Error");
                }
            }
            catch
            {
                return Json("Name: Error");
            }


        }


        public ActionResult GetAccountsReceivables()
        {
            AHDDManagerClass.Customers objCs = new AHDDManagerClass.Customers();

            var AR = objCs.GetCustomerAccountReceivables();

            return Json(AR);
        }

        public ActionResult GetTodaysTransactions()
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions(DateTime.Now.ToUniversalTime().AddHours(-6));

            return Json(objTs);
        }

        public JsonResult GetTransactionsReport(DateTime StartDate, DateTime EndDate, bool IncludeOpens)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransactionsReport(StartDate, EndDate, IncludeOpens);

            return Json(ret);
        }


        public JsonResult GetTransactionPaymentsReport(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransactionPaymentsReport(StartDate, EndDate);

            return Json(ret);
        }

        public JsonResult GetTransactionsWithPayments(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransactionsWithPaymentsByDate(StartDate, EndDate);

            return Json(ret);
        }

        public JsonResult GetTransCompletedWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransCompletedWOPaymentByDate(StartDate, EndDate);

            return Json(ret);
        }

        public JsonResult GetTransCancelledWORefundByDate(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransCancelledWORefundByDate(StartDate, EndDate);

            return Json(ret);
        }

        public JsonResult GetTransCancelledWRefundByDate(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransCancelledWRefundByDate(StartDate, EndDate);

            return Json(ret);
        }


        public JsonResult GetTransOpenWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var ret = objTs.GetTransOpenWOPaymentByDate(StartDate, EndDate);

            return Json(ret);
        }


        public JsonResult GetPaymentDetailsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.PaymentDetail objPs = new AHDDManagerClass.PaymentDetail();
            var ret = objPs.GetPaymentDetailsByDateRange(StartDate, EndDate);

            return Json(ret);
        }

        public JsonResult GetPaymentsCollectedByDateRange(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            var ret = objPs.GetPaymentsCollectedByDateRange(StartDate, EndDate);

            return Json(ret);
        }


        public JsonResult GetPaymentsCollectedNotToday()
        {
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            var ret = objPs.GetPaymentsCollectedByDateRange(DateTime.Now, DateTime.Now);

            return Json(ret);
        }


        public JsonResult GetPaymentsByTransactionID(int TransactionID)
        {
            try
            {
                AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments(TransactionID);
                return Json(objPs);
            }
            catch
            { return Json("0"); }
        }


        public JsonResult GetPaymentsCollectedByAssociate(int AssociateID, DateTime StartDate, DateTime EndDate)
        {
            if (AssociateID == 0)
            { AssociateID = base.Associate.AssociateID; }

            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            var ret = objPs.GetPaymentsCollectedByAsscociateID(AssociateID, StartDate, EndDate);

            return Json(ret);
        }


        public JsonResult GetPayMethodCountsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            var ret = objPs.GetPayMethodCountsByDateRange(StartDate, EndDate);

            return Json(new { OverallTotal = ret.OverallTotal, ret = ret });
        }



        public JsonResult GetPayMethodCountsByDateRangeAssocID(int AssociateID, DateTime StartDate, DateTime EndDate)
        {
            if (AssociateID == 0)
            { AssociateID = base.Associate.AssociateID; }

            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            AHDDManagerClass.PaymentMethodCounts ret = objPs.GetPayMethodCountsByDateRangeAssocID(StartDate, EndDate, AssociateID);

            return Json(new { OverallTotal = ret.OverallTotal, ret = ret });
        }




        public JsonResult GetCustomerByPaymentID(int PaymentID)
        {
            AHDDManagerClass.Payment objP = new AHDDManagerClass.Payment();
            var ret = objP.GetCustomerByPaymentID(PaymentID);

            return Json(ret);
        }


        public JsonResult GetTransactionByPaymentID(int PaymentID)
        {
            AHDDManagerClass.Payment objP = new AHDDManagerClass.Payment();
            var ret = objP.GetTransactionByPaymentID(PaymentID);

            return Json(ret);
        }

        public JsonResult GetTransactionDetailsByPaymentID(int PaymentID)
        {
            AHDDManagerClass.Payment objP = new AHDDManagerClass.Payment();
            var ret = objP.GetTransactionDetailsByPaymentID(PaymentID);

            return Json(ret);
        }


        public JsonResult GetTransactionDetailsByTransactionID(int TransactionID)
        {
            AHDDManagerClass.TransactionDetails objTDs = new AHDDManagerClass.TransactionDetails(TransactionID);
            return Json(objTDs);
        }

        public ContentResult GetAssociateHours(string StartDate, string EndDate)
        {
            AHDDManagerClass.AssociatesHoursWorked objAHWs = new AHDDManagerClass.AssociatesHoursWorked(StartDate, EndDate);

            return Content(JsonConvert.SerializeObject(objAHWs), "application/json");
        }


        public ActionResult ChangeClockedInStatus()
        {
            return ChangeAssociateClockedInStatus(base.Associate.AssociateID);
        }

        public ActionResult ChangeAssociateClockedInStatus(int AssociateID)
        {
            try
            {
                AHDDManagerClass.Associate objA = new AHDDManagerClass.Associate(AssociateID);

                objA.ChangeClockInStatus();

                AHDDManager.Models.Logging.LogClockIn("User clock in status changed to " + objA.ClockedIn + ": " + objA.UserName + " (" + objA.FirstName + " " + objA.LastName + ")", objA.UserName);
                
                if (AssociateID == base.Associate.AssociateID)
                {
                    Session["Associate"] = null;
                    Session["Associate"] = objA;

                    if (!objA.ClockedIn) //if logged out, kill session and redirect
                    {
                        AHDDManager.Models.Logging.LogClockIn("User Logged OUT: " + objA.UserName, objA.UserName);

                        Session.Abandon();

                        //return Redirect("/home/");
                    }

                }

                return Json("1");
            }
            catch (Exception ex)
            {
                AHDDManager.Models.Logging.LogClockIn("ERROR: User clock in status change: " + AssociateID, "unknown");

                return Json("0");
            }
        }


        // GET: Admin
        public ActionResult Associates()
        {
            if (base.Associate.IsAdmin)
            {
                AHDDManagerClass.Associates objAs = new AHDDManagerClass.Associates(base.Business.BusinessID);

                return View(objAs);
            }
            else
            { return Redirect("/customer/"); }
        }


        public ActionResult GetAssociate(int AssociateID)
        {
            AHDDManagerClass.Associate objA = new AHDDManagerClass.Associate(AssociateID);

            return Json(objA);
        }

        public ActionResult UpdateAssociate(AHDDManagerClass.Associate associate)
        {
            AHDDManagerClass.Associate objA;
            associate.BusinessID = base.Business.BusinessID;


            if (associate.AssociateID > 0)
            {
                objA = new AHDDManagerClass.Associate(associate.AssociateID);

                objA.FirstName = associate.FirstName;
                objA.LastName = associate.LastName;
                objA.Address = associate.Address;
                objA.City = associate.City;
                objA.State = associate.State;
                objA.Zip = associate.Zip;
                objA.Phone = associate.Phone;
                objA.AltPhone = associate.AltPhone;
                objA.Email = associate.Email;
                objA.UserName = associate.UserName;
                objA.Password = associate.Password;
                objA.Active = associate.Active;
                objA.BackgroundColor = associate.BackgroundColor;
                objA.TextColor = associate.TextColor;

                if (objA.Update())
                {
                    if (objA.AssociateID == base.Associate.AssociateID)
                    {
                        Session["Associate"] = null;
                        Session["Associate"] = objA;
                    }
                    return Json("1");

                }
                else
                { return Json("0"); }
            }
            else
            {
                associate.DateCreated = DateTime.Now;

                if (associate.Update())
                { return Json("1"); }
                else
                { return Json("0"); }
            }
        }

        public ActionResult UpdateHours(int AssociateClockInHistoryID, string LogInDate, string LogOutDate)
        {
            try
            {
                AHDDManagerClass.AssociateClockInHistory objACH = new AHDDManagerClass.AssociateClockInHistory(AssociateClockInHistoryID);

                if (objACH.AssociateClockInHistoryExists)
                {
                    LogInDate = LogInDate.Remove(LogInDate.IndexOf("GMT")).Trim();
                    LogOutDate = LogOutDate.Remove(LogOutDate.IndexOf("GMT")).Trim();

                    AHDDManager.Models.Logging.LogEvent("************************************************************************");
                    AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours input param: LogInDate - " + LogInDate);
                    AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours input param: LogOutDate - " + LogOutDate);


                    objACH.LoginDatetime = DateTime.Parse(LogInDate);
                    objACH.LogoutDatetime = DateTime.Parse(LogOutDate);

                    AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours converted:  objACH.LoginDatetime - " + objACH.LoginDatetime);
                    AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours converted: objACH.LogoutDatetime - " + objACH.LogoutDatetime);
                    AHDDManager.Models.Logging.LogEvent("************************************************************************");

                    if (objACH.Update())
                    {
                        return Json("1");
                    }
                    else
                    {
                        AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours error: UpdateHours failed to update.");
                        return Json("0");
                    }
                }
                else
                {
                    AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours error: AssociateClockInHistoryID could not be found");
                    return Json("0");
                }
            }
            catch (Exception ex)
            {
                AHDDManager.Models.Logging.LogEvent("Admin.UpdateHours error: " + ex.Message);
                return Json("0");
            }



        }



        public ActionResult DeleteForm(int FormID)
        {

            if (!base.Associate.IsAdmin)
            {
                return Json("This form cannot be deleted because you are not an admin.");
            }

            AHDDManagerClass.Form objF = new AHDDManagerClass.Form(FormID);
            if (!objF.FormsExists)
            {
                return Json("The specified form does not exist.");
            }

            if (objF.Deleteable)
            {
                if (objF.Delete())
                {
                    return Json("0");
                }
                else
                {
                    return Json("There was an error deleting the form.");
                }
            }
            else
            {
                return Json("This form cannot be deleted because it is part of a transaction.");
            }

        }


        public JsonResult GetForms()
        {
            AHDDManagerClass.Forms objFs = new AHDDManagerClass.Forms();

            return Json(objFs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateForm(AHDDManagerClass.Form form)
        {
            if (form.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }


        public JsonResult GetStates()
        {
            return Json(AHDDManager.Models.States.GetStates());
        }

        public JsonResult GetColors()
        {
            AHDDManagerClass.Colors objCs = new AHDDManagerClass.Colors();


            return Json(objCs.GetAvailableColors());
        }

    }

}