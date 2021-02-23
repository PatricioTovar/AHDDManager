using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class CustomerController : Models.AHDDSecurity
    {
        // GET: Customer
        public ActionResult Index()
        {
            ViewData["IsAdmin"] = base.Associate.IsAdmin;
            ViewBag.AssociateID = base.Associate.AssociateID;
            return View();
        }

        public ActionResult Invoice(int id) // transaction id
        {
            AHDDManager.Models.Invoice objI = new Models.Invoice();

            AHDDManagerClass.Transaction objT = new AHDDManagerClass.Transaction(id);
            AHDDManagerClass.Customer objC;
            AHDDManagerClass.Business objB;
            AHDDManagerClass.TransactionDetails objTDs;
            AHDDManagerClass.Payments objPs;
            AHDDManagerClass.Refunds objRs;

            if (objT.TransactionsExists)
            {
                objC = new AHDDManagerClass.Customer(objT.CustomerID);
                objB = new AHDDManagerClass.Business(objT.BusinessID);
                objTDs = new AHDDManagerClass.TransactionDetails(id);
                objPs = new AHDDManagerClass.Payments(id);
                objRs = new AHDDManagerClass.Refunds(id);
                

                objI.Customer = objC;
                objI.Business = objB;
                objI.TransactionDetails = objTDs;
                objI.Transaction = objT;
                objI.Payments = objPs;
                objI.Refunds = objRs;

                //var t = new Tuple<AHDDManagerClass.Customer, AHDDManagerClass.Business, AHDDManagerClass.TransactionDetails, AHDDManagerClass.Transaction, AHDDManagerClass.Payments>(objC, objB, objTDs, objT, objPs);
                return View(objI);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SearchCustomers(string SearchCriteria)
        {
            AHDDManagerClass.Customers objCusts = new AHDDManagerClass.Customers(SearchCriteria);

            return Json(objCusts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomer(int CustomerID)
        {
            AHDDManagerClass.Customer objC = new AHDDManagerClass.Customer(CustomerID);

            return Json(objC);
        }

        public ActionResult DeleteCustomer(int CustomerID)
        {
            AHDDManagerClass.Customer objF = new AHDDManagerClass.Customer(CustomerID);
            if (!objF.CustomersExist)
            {
                return Json("The specified customer does not exist.");
            }

            if (objF.Deleteable)
            {
                if (objF.Delete())
                {
                    return Json("0");
                }
                else
                {
                    return Json("There was an error deleting the customer.");
                }
            }
            else
            {
                return Json("This customer cannot be deleted because it is part of a transaction or payment.");
            }

        }
        public ActionResult DeleteCustomerNote(int CustomerNoteID)
        {
            AHDDManagerClass.CustomerNote objF = new AHDDManagerClass.CustomerNote();

                if (objF.Delete(CustomerNoteID))
                {
                    return Json("0");
                }
                else
                {
                    return Json("There was an error deleting the customer.");
                }

        }
        


        public ActionResult UpdateCustomer(AHDDManagerClass.Customer customer)
        {
            try
            {
                if (customer.CustomerID == 0)
                {
                    customer.DateCreated = DateTime.Now;
                    customer.Active = true;
                }

                if (customer.Update())
                { return Json(customer.CustomerID); }
                else
                { return Json("0"); }
            }
            catch
            {
                return Json("0");
            }

        }


        public ActionResult GetCustomerNotes(int CustomerID)
        {
            AHDDManagerClass.CustomerNotes objCNs = new AHDDManagerClass.CustomerNotes(CustomerID);

            return Json(objCNs);
        }

        public ActionResult AddCustomerNote(AHDDManagerClass.CustomerNote CustomerNote)
        {

            CustomerNote.DateAdded = DateTime.Now;
            CustomerNote.AddedBy = base.Associate.AssociateID;

            if (CustomerNote.Update())
            { return Json("1"); }
            else
            { return Json("0"); }
        }

        public ActionResult Payments(int ID)
        {
            AHDDManagerClass.Payments objPs = new AHDDManagerClass.Payments();
            AHDDManagerClass.Customer objC = new AHDDManagerClass.Customer(ID);

            //objC.LoadByTransactionID(ID);

            ViewBag.CustomerName = objC.FullName;

            return View(objPs.GetCustomerPayments(ID));
        }


        public JsonResult GetAssociates()
        {
            try
            {
                AHDDManagerClass.Associates objAs = new AHDDManagerClass.Associates(base.Business.BusinessID);

                return Json(objAs);
            }
            catch
            {
                return Json("0");
            }

        }


    }
}
