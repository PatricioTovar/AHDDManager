using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class ExpensesController : Models.AHDDSecurity
    {
        // GET: Expenses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExpensesPrint(string startdate, string enddate)
        {
            return View();
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult SearchExpenses(string StartDate, string EndDate)
        {
            AHDDManagerClass.Expenses objEs = new AHDDManagerClass.Expenses(StartDate, EndDate, false);
            return Json(objEs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteExpense(int ExpenseID)
        {
            try
            {
                AHDDManagerClass.Expense objE = new AHDDManagerClass.Expense();
                objE.ExpenseID = ExpenseID;

                if (objE.Delete(base.Associate.AssociateID))
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
            }
            catch
            {
                return Json("0");
            }


        }

        public ActionResult SearchRefunds(string StartDate, string EndDate)
        {
            AHDDManagerClass.Expenses objEs = new AHDDManagerClass.Expenses(StartDate, EndDate, true);
            return Json(objEs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SearchDeletedExpenses(string StartDate, string EndDate)
        {
            AHDDManagerClass.ExpensesDeleted objEDs = new AHDDManagerClass.ExpensesDeleted(StartDate, EndDate);
            return Json(objEDs, JsonRequestBehavior.AllowGet);
        }



        public ActionResult RefundExpense(int ExpenseID)
        {
            try
            {
                AHDDManagerClass.Expense objE = new AHDDManagerClass.Expense(ExpenseID);

                if (!objE.ExpenseExists)
                {
                    return Json("0");
                }

                objE.Refunded = true;
                objE.RefundedBy = base.Associate.AssociateID;

                if (objE.Update())
                { return Json("1"); }
                else
                { return Json("0"); }
            }
            catch
            {
                return Json("0");
            }

        }

        public ActionResult UpdateExpense(AHDDManagerClass.Expense expense)
        {
            expense.DateEntered = DateTime.Now;
            expense.Refunded = false;
            expense.TakenBy = base.Associate.AssociateID;
            expense.BusinessID = base.Business.BusinessID;

            if (expense.Update())
            { return Json("1"); }
            else
            { return Json("There was an error adding the expense."); }

        }

    }
}
