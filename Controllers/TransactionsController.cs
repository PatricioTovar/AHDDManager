using AHDDManagerClass;
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
            Transactions objTs = new Transactions(id);
            Customer objC = new Customer(id);

            ViewBag.CustomerName = objC.FirstName + " " + objC.LastName;
            ViewBag.CustomerID = objC.CustomerID;
            
            Session["SelectedCustomer"] = objC;

            return View(objTs);
        }


        public ActionResult SearchForms(string SearchCriteria)
        {
            Forms objFs = new Forms(SearchCriteria);

            return Json(objFs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddTransaction()
        {
            ViewBag.CustomerID = Url.RequestContext.RouteData.Values["id"];
            return View();
        }

        public ActionResult AddRefund(Refund Refund)
        {
            //Refund.RefundDate = DateTime.Now.AddHours(2); //PT - add time in the client side
            Refund.RefundedBy = base.Associate.AssociateID;

            if (Refund.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        public ActionResult AddNewTransaction(Transaction transaction, List<TransactionDetail> transactiondetails)
        {
            //transaction.TransactionDate = DateTime.Now; //PT - add time in the client side
            transaction.BusinessID = base.Business.BusinessID;
            if (transaction.AssociateID == 0)
            {
                transaction.AssociateID = base.Associate.AssociateID;
            }
            transaction.TransactionStatusID = 1;
            transaction.TransactionStatus = "OPEN";
            //transaction.ModifiedDate = DateTime.UtcNow.AddHours(-6); //PT - add time in the client side
            transaction.ModifiedBy = base.Associate.AssociateID;
            transaction.RefundedAmount = 0;
            transaction.TotalCollected = 0;


            if (!transaction.Update())
            {
                return Json("0");
            }
            if (transactiondetails != null) { 
                foreach (TransactionDetail item in transactiondetails)
                {
                    item.TransactionID = transaction.TransactionID;

                    if (!item.Update())
                    {
                        return Json("0");
                    }
                }
            }
            return Json(transaction.TransactionID);
        }
    


        public ActionResult AddTransactionDetail(TransactionDetail transactionDetail)
        {

            if (!transactionDetail.Update())
            {
                return Json("0");
            }

            return Json(transactionDetail.TransactionID);
        }

        public ActionResult TransactionDetails(int id)
        {
            TransactionDetails objTDs = new TransactionDetails(id);
            Payments objPs = new Payments(id);
            Transaction objT = new Transaction(id);
            Refunds objRs = new Refunds(id);

            var tuple = new Tuple<TransactionDetails, Payments, Transaction, Refunds>(objTDs, objPs, objT, objRs);
            return View(tuple);
        }

        public ActionResult SearchTransaction(int TransactionID)
        {
            Transaction objT = new Transaction(TransactionID);

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

            Transactions objTs = new Transactions();

            var listTrans = objTs.GetTransactionsReport(StartDate, EndDate, false);

            return Json(listTrans);
        }


        public ActionResult MakePayment(Payment payment)
        {
            //payment.PaymentDate = DateTime.Now;
            payment.AssociateID = base.Associate.AssociateID;
            payment.DeletedBy = base.Associate.AssociateID;

            if (payment.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        public ActionResult GetForms()
        {
            Forms objFs = new Forms();

            return Json(objFs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteTransactionDetail(int TransactionDetailID)
        {
            TransactionDetail objTD = new TransactionDetail();

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
            Payment objTD = new Payment();

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
            Transaction objT = new Transaction(TransactionID);

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
            Transaction objT = new Transaction(TransactionID);

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
            Transaction objT = new Transaction(TransactionID);

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


        public ActionResult UpdateTransactionCustomer(int TransactionID, int CustomerID)
        {
            var result = new Result();
            try
            {
                Transaction objT = new Transaction(TransactionID);

                if (objT.TransactionsExists)
                {
                    var objC = new Customer(CustomerID);
                    if (objC.CustomersExist)
                    {
                        objT.CustomerID = CustomerID;
                        if (objT.Update())
                        {
                            result.Res = true;
                            result.Message = "Records updated successfully.";
                        }
                        else
                        {
                            result.Res = false;
                            result.Message = "There was an error updating the records.";
                        }
                    }
                    else
                    {
                        result.Res = false;
                        result.Message = "The customer was not found.";
                    }

                }
                else
                {
                    result.Res = false;
                    result.Message = "The transaction was not found.";
                }
            }
            catch (Exception ex)
            {
                result.Res = false;
                result.Message = ex.Message;
            }

            return Json(result);
        }
    }

}
