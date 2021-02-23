using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class Expense
    {
        private int iExpenseID;
        private int iBusinessID;
        private string strPaidTo;
        private string strDescription;
        private DateTime dtmExpenseDate;
        private DateTime dtmDateEntered;
        private Boolean blnRefunded;
        private int iTakenBy;
        private int iRefundedBy;
        private int iDeletedBy;
        private string strTakenByName;
        private decimal decExpenseAmount;
        private Boolean blnExpenseExists;

        //private ClassError objError;


        public void initialize()
        {
            iExpenseID = 0;
            iBusinessID = 0;
            strPaidTo = string.Empty;
            strDescription = string.Empty;
            dtmExpenseDate = DateTime.MinValue;
            dtmDateEntered = DateTime.MinValue;
            blnRefunded = false;
            iTakenBy = 0;
            iRefundedBy = 0;
            iDeletedBy = 0;
            strTakenByName = string.Empty;
            decExpenseAmount = 0.0M;
            blnExpenseExists = false;

            //objError = new ClassError();
        }


        public Expense()
        {
            initialize();
        }


        public Expense(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnExpenseExists = true;
            }
            catch (Exception ex)
            {
                blnExpenseExists = false;
            }
        }

        public Expense(int ExpenseID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetExpenseByID(ExpenseID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnExpenseExists = true;
                }
                else
                {
                    blnExpenseExists = false;
                }
            }
            catch (Exception ex)
            {
                blnExpenseExists = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iExpenseID = Convert.ToInt32(dr["ExpenseID"] == Convert.DBNull ? 0 : dr["ExpenseID"]);
                iBusinessID = Convert.ToInt32(dr["BusinessID"] == Convert.DBNull ? 0 : dr["BusinessID"]);
                strPaidTo = Convert.ToString(dr["PaidTo"] == Convert.DBNull ? string.Empty : dr["PaidTo"]);
                strDescription = Convert.ToString(dr["Description"] == Convert.DBNull ? string.Empty : dr["Description"]);
                dtmExpenseDate = Convert.ToDateTime(dr["ExpenseDate"] == Convert.DBNull ? DateTime.MinValue : dr["ExpenseDate"]);
                dtmDateEntered = Convert.ToDateTime(dr["DateEntered"] == Convert.DBNull ? DateTime.MinValue : dr["DateEntered"]);
                blnRefunded = Convert.ToBoolean(dr["Refunded"] == Convert.DBNull ? false : dr["Refunded"]);
                iTakenBy = Convert.ToInt32(dr["TakenBy"] == Convert.DBNull ? 0 : dr["TakenBy"]);
                iRefundedBy = Convert.ToInt32(dr["RefundedBy"] == Convert.DBNull ? 0 : dr["RefundedBy"]);
                iDeletedBy = Convert.ToInt32(dr["DeletedBy"] == Convert.DBNull ? 0 : dr["DeletedBy"]);
                strTakenByName = Convert.ToString(dr["name"] == Convert.DBNull ? string.Empty : dr["name"]);
                decExpenseAmount = Convert.ToDecimal(dr["ExpenseAmount"] == Convert.DBNull ? 0.0 : dr["ExpenseAmount"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int ExpenseID
        {
            get { return iExpenseID; }
            set { iExpenseID = value; }
        }
        public int BusinessID
        {
            get { return iBusinessID; }
            set { iBusinessID = value; }
        }
        public string PaidTo
        {
            get { return strPaidTo; }
            set { strPaidTo = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        public DateTime ExpenseDate
        {
            get { return dtmExpenseDate; }
            set { dtmExpenseDate = value; }
        }
        public DateTime DateEntered
        {
            get { return dtmDateEntered; }
            set { dtmDateEntered = value; }
        }
        public Boolean Refunded
        {
            get { return blnRefunded; }
            set { blnRefunded = value; }
        }
        public int TakenBy
        {
            get { return iTakenBy; }
            set { iTakenBy = value; }
        }
        public int RefundedBy
        {
            get { return iRefundedBy; }
            set { iRefundedBy = value; }
        }
        public int DeletedBy
        {
            get { return iDeletedBy; }
            set { iDeletedBy = value; }
        }
        public string TakenByName
        {
            get { return strTakenByName; }
            set { strTakenByName = value; }
        }
        public decimal ExpenseAmount
        {
            get { return decExpenseAmount; }
            set { decExpenseAmount = value; }
        }
        public Boolean ExpenseExists
        {
            get { return blnExpenseExists; }
            set { blnExpenseExists = value; }
        }

        //public ClassError ErrorOccurred
        //{
        //    get { return objError; }
        //}

        public Boolean Update()
        {
            Data obj = new Data();
            int iRet = 0;

            try
            {
                iRet = obj.UpdateExpense(this);

                if (iRet == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //General.WriteToErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.UnderlyingSystemType.ToString, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message)

                return false;
            }
            finally
            {
                ExpenseID = iRet;
            }

        }

       
        public Boolean Delete(int DeletedBy)
        {
          Data obj = new Data();

          try
              {
                return obj.DeleteExpense(ExpenseID, DeletedBy);

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
      
    }











    
    public class Expenses : IEnumerable<Expense>
    {
        List<Expense> infoList = new List<Expense>();

        public Expenses()
        {
            infoList = new List<Expense>();
        }

        public Expenses(string StartDate, string EndDate, Boolean Refunded)
        {
            Data objData = new Data();
            DataTable dt;
            Expense objInfo;
            
            dt = objData.GetExpensesByDateRange(StartDate,EndDate, Refunded);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Expense(dt.Rows[i]);
                    if (objInfo.ExpenseExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

       

        public void Add(Expense Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Expense> IEnumerable<Expense>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }









}
