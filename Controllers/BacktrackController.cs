using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class BacktrackController : Models.AHDDSecurity
    {
        // GET: Backtrack
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Transactions(int id)
        {
            AHDDManagerClass.BackTracks objBs = new AHDDManagerClass.BackTracks(id);
            AHDDManagerClass.Customer objC = new AHDDManagerClass.Customer(id);

            ViewBag.CustomerName = objC.FirstName + " " + objC.LastName;

            Session["SelectedCustomer"] = objC;

            return View(objBs);
        }

        public ActionResult AddTransaction()
        {
            return View();
        }

        public ActionResult GetAssociates()
        {
            AHDDManagerClass.Associates objAs = new AHDDManagerClass.Associates(1);

            return Json(objAs);
        }

        public ActionResult TransactionDetails(int id)
        {
            AHDDManagerClass.TransactionDetails objTDs = new AHDDManagerClass.TransactionDetails(id);
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments(id);
            AHDDManagerClass.BackTrack objB = new AHDDManagerClass.BackTrack(id);
            AHDDManagerClass.Refunds objRs = new AHDDManagerClass.Refunds(id);

            var tuple = new Tuple<AHDDManagerClass.TransactionDetails, AHDDManagerClass.Payments, AHDDManagerClass.BackTrack, AHDDManagerClass.Refunds>(objTDs, objPs, objB, objRs);
            return View(tuple);
        }


        public ActionResult MakePayment(AHDDManagerClass.Payment payment)
        {
            if (payment.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }


        public ActionResult UpdateBacktrack(AHDDManagerClass.BackTrack transaction, List<AHDDManagerClass.TransactionDetail> transactiondetails, List<AHDDManagerClass.Payment> Payments)
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone);
            
            //this is set by user in backtrackscenario

            transaction.ModifiedDate = Convert.ToDateTime(cstTime);
            transaction.ModifiedBy = base.Associate.AssociateID;
            transaction.RefundedAmount = 0;
            transaction.TotalCollected = 0;           
            transaction.BusinessID = base.Business.BusinessID;

            if (transaction.Update())
            {
                foreach (AHDDManagerClass.TransactionDetail item in transactiondetails)
                {
                    item.TransactionID = transaction.TransactionID;

                    if (!item.Update())
                    {
                        return Json("0");
                    }
                }

                foreach (AHDDManagerClass.Payment item in Payments)
                {
                    if (!item.Update())
                    {
                        AHDDManager.Models.Logging.LogEvent("ERROR: Adding backtrack payment - trans ID: " + item.TransactionID + " | payment amount: " + item.PaymentAmount.ToString());
                    }

                }
                
                return Json(transaction.TransactionID);
            }
            else
            {
                return Json("0");
            }
        }



    }





}