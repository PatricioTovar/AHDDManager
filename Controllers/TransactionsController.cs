using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class TransactionsController : Models.AHDDSecurity
    {
        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerTransactions(int id)
        {
            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions(id);
            AHDDManagerClass.Customer objC = new AHDDManagerClass.Customer(id);

            ViewBag.CustomerName = objC.FirstName + " " + objC.LastName;

            Session["SelectedCustomer"] = objC;

            return View(objTs);
        }


        public ActionResult SearchForms(string SearchCriteria)
        {
            AHDDManagerClass.Forms objFs = new AHDDManagerClass.Forms(SearchCriteria);

            return Json(objFs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddTransaction()
        {
            return View();
        }

        public ActionResult AddRefund(AHDDManagerClass.Refund Refund)
        {
            //Refund.RefundDate = DateTime.Now.AddHours(2); //PT - add time in the client side
            Refund.RefundedBy = base.Associate.AssociateID;

            if (Refund.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        public ActionResult AddNewTransaction(AHDDManagerClass.Transaction transaction, List<AHDDManagerClass.TransactionDetail> transactiondetails)
        {
            //transaction.TransactionDate = DateTime.Now; //PT - add time in the client side
            transaction.BusinessID = base.Business.BusinessID;
            transaction.AssociateID = base.Associate.AssociateID;
            transaction.TransactionStatusID = 1;
            transaction.TransactionStatus = "OPEN";
            //transaction.ModifiedDate = DateTime.UtcNow.AddHours(-6); //PT - add time in the client side
            transaction.ModifiedBy = base.Associate.AssociateID;
            transaction.RefundedAmount = 0;
            transaction.TotalCollected = 0;


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
                return Json(transaction.TransactionID);
            }
            else
            {
                return Json("0");
            }
        }


        public ActionResult AddTransactionDetail(AHDDManagerClass.TransactionDetail transactionDetail)
        {

            if (!transactionDetail.Update())
            {
                return Json("0");
            }

            return Json(transactionDetail.TransactionID);
        }

        public ActionResult TransactionDetails(int id)
        {
            AHDDManagerClass.TransactionDetails objTDs = new AHDDManagerClass.TransactionDetails(id);
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments(id);
            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(id);
            AHDDManagerClass.Refunds objRs = new AHDDManagerClass.Refunds(id);

            var tuple = new Tuple<AHDDManagerClass.TransactionDetails, AHDDManagerClass.Payments, AHDDManagerClass.Transaction, AHDDManagerClass.Refunds>(objTDs, objPs, objT, objRs);
            return View(tuple);
        }

        public ActionResult SearchTransaction(int TransactionID)
        {
            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(TransactionID);

            if (objT.TransactionsExists)
            {
                return Json(objT);
            }
            else
            {
                return Json("0");
            }

        }

        public ActionResult SearchTransactionByDates(DateTime StartDate, DateTime EndDate)
        {

            AHDDManagerClass.Transactions objTs = new AHDDManagerClass.Transactions();

            var listTrans = objTs.GetTransactionsReport(StartDate, EndDate, false);

            return Json(listTrans);
        }


        public ActionResult MakePayment(AHDDManagerClass.Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            payment.AssociateID = base.Associate.AssociateID;
            payment.DeletedBy = base.Associate.AssociateID;

            if (payment.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        public ActionResult GetForms()
        {
            AHDDManagerClass.Forms objFs = new AHDDManagerClass.Forms();

            return Json(objFs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteTransactionDetail(int TransactionDetailID)
        {
            AHDDManagerClass.TransactionDetail objTD = new AHDDManagerClass.TransactionDetail();

            if (objTD.Delete(TransactionDetailID, base.Associate.AssociateID))
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        public ActionResult DeletePayment(int PaymentID)
        {
            AHDDManagerClass.Payment objTD = new AHDDManagerClass.Payment();

            if (objTD.Delete(PaymentID, base.Associate.AssociateID))
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        public ActionResult CancelTransaction(int TransactionID, DateTime ModifiedDate)
        {
            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(TransactionID);

            if (objT.TransactionsExists)
            {
                objT.TransactionStatusID = 3;
                objT.TransactionStatus = "CANCELLED";
                objT.ModifiedBy = base.Associate.AssociateID;
                //objT.ModifiedDate = DateTime.UtcNow.AddHours(-6); //PT - add time in the client side
                objT.ModifiedDate = ModifiedDate;

                if (objT.Update())
                {
                    return Json("1");
                }
                else
                {
                    return Json("There was an error cancelling the transaction");
                }
            }
            else
            {
                return Json("This specified transaction was not found.");
            }
        }

        public ActionResult CompleteTransaction(int TransactionID, DateTime ModifiedDate)
        {
            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(TransactionID);

            if (objT.TotalOwed > 0)
            {
                return Json("This transaction cannot be completed. " + String.Format("{0:C2}", objT.TotalOwed) + " is still owed.");
            }
            else
            {
                if (objT.TransactionsExists)
                {
                    objT.TransactionStatusID = 2;
                    objT.TransactionStatus = "COMPLETED";
                    objT.ModifiedBy = base.Associate.AssociateID;
                    //objT.ModifiedDate = DateTime.UtcNow.AddHours(-6); //PT - add time in the client side
                    objT.ModifiedDate = ModifiedDate;

                    if (objT.Update())
                    {
                        return Json("1");
                    }
                    else
                    {
                        return Json("There was an error completing the transaction.");
                    }
                }
                else
                {
                    return Json("This specified transaction was not found.");

                }


            }
        }

        public ActionResult ReOpenTransaction(int TransactionID, DateTime ModifiedDate)
        {
            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(TransactionID);

            if (objT.TransactionsExists)
            {
                objT.TransactionStatusID = 1;
                objT.TransactionStatus = "RE-OPEN";
                objT.ModifiedBy = base.Associate.AssociateID;
                //objT.ModifiedDate = DateTime.UtcNow.AddHours(-6); //PT - add time in the client side
                objT.ModifiedDate = ModifiedDate;

                if (objT.Update())
                {
                    return Json("1");
                }
                else
                {
                    return Json("There was an error re-opening the transaction");
                }
            }
            else
            {
                return Json("This specified transaction was not found.");
            }
        }

        //public ActionResult GetPaymentMethods()
        //{
        //    return Json({ "Id":0,"Name":"None"},{ "Id":2097155,"Name":"Guest"},{ "Id":2916367,"Name":"Reader"});
        //}



    }
}
