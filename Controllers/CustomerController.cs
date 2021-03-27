using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHDDManagerClass;

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
            Models.Invoice objI = new Models.Invoice();

            Transaction objT = new Transaction(id);
            Customer objC;
            Business objB;
            TransactionDetails objTDs;
            Payments objPs;
            Refunds objRs;

            if (objT.TransactionsExists)
            {
                objC = new Customer(objT.CustomerID);
                objB = new Business(objT.BusinessID);
                objTDs = new TransactionDetails(id);
                objPs = new Payments(id);
                objRs = new Refunds(id);
                

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
            Customers objCusts = new Customers(SearchCriteria);

            return Json(objCusts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomer(int CustomerID)
        {
            Customer objC = new Customer(CustomerID);

            return Json(objC);
        }

        public ActionResult DeleteCustomer(int CustomerID)
        {
            Customer objF = new Customer(CustomerID);
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
            CustomerNote objF = new CustomerNote();

                if (objF.Delete(CustomerNoteID))
                {
                    return Json("0");
                }
                else
                {
                    return Json("There was an error deleting the customer.");
                }

        }
        


        public ActionResult UpdateCustomer(Customer customer)
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
            CustomerNotes objCNs = new CustomerNotes(CustomerID);

            return Json(objCNs);
        }

        public ActionResult AddCustomerNote(CustomerNote CustomerNote)
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
            Payments objPs = new Payments();
            Customer objC = new Customer(ID);

            //objC.LoadByTransactionID(ID);

            ViewBag.CustomerName = objC.FullName;

            return View(objPs.GetCustomerPayments(ID));
        }


        public JsonResult GetAssociates()
        {
            try
            {
                Associates objAs = new Associates(base.Business.BusinessID, true);

                return Json(objAs);
            }
            catch
            {
                return Json("0");
            }

        }


        public JsonResult GetAllAssociates()
        {
            try
            {
                Associates objAs = new Associates(base.Business.BusinessID);

                return Json(objAs);
            }
            catch
            {
                return Json("0");
            }

        }
    }
}
