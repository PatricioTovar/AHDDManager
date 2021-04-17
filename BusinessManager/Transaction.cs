using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{


    public class TransactionSinglePayment : Transaction
    {
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }
        public string MethodDescription { get; set; }

        public TransactionSinglePayment()
        {
            Initialize();
        }

        public void Initialize()
        {
            base.initialize();
            PaymentAmount = 0.00M;
        }

        public TransactionSinglePayment(DataRow dr)
        {
            try
            {
                Initialize();
                Load(dr);
                this.PaymentAmount = Convert.ToDecimal((dr.Table.Columns["AmountPaid"] == null || dr["AmountPaid"] == Convert.DBNull) ? 0.0 : dr["AmountPaid"]);
                this.PaymentDate = Convert.ToDateTime((dr.Table.Columns["PaymentDate"] == null || dr["PaymentDate"] == Convert.DBNull) ? null : dr["PaymentDate"]);
                this.PaymentMethod = Convert.ToInt32((dr.Table.Columns["PaymentMethod"] == null || dr["PaymentMethod"] == Convert.DBNull) ? 0 : dr["PaymentMethod"]);
                this.MethodDescription = Convert.ToString((dr.Table.Columns["MethodDescription"] == null || dr["MethodDescription"] == Convert.DBNull) ? string.Empty : dr["MethodDescription"]);
                base.TransactionsExists = true;
            }
            catch (Exception ex)
            {
                base.TransactionsExists = false;
            }
        }



    }

    public class Transaction
    {
        private int iTransactionID;
        private int iBusinessID;
        private int iCustomerID;
        private string strCustomerName;
        private int iAssociateID;
        private string strTakenBy;
        private DateTime dtmTransactionDate;
        private decimal decTotalAmount;
        private int iTransactionStatusID;
        private string strTransactionStatus;
        private int iModifiedBy;
        private string strModifiedByName;
        private DateTime dtmModifiedDate;

        //private decimal decAmountPaid; //this should be replaced with TotalCollected!!!!!!!!!!!!!!!!!!!!
        //private decimal decAmountDue;

        private decimal decRefundedAmount;
        private decimal decTotalCollected;
        private decimal decNet;

        private Boolean blnTransactionsExist;

        //private Boolean blnLoadPayments;

        private Payments objPs;
        private Refunds objRs;
        private decimal decTotalOwed;
        //private decimal decTotalPaid;

        //private ClassError objError;


        public void initialize()
        {
            iTransactionID = 0;
            iBusinessID = 0;
            iCustomerID = 0;
            strCustomerName = string.Empty;
            strTakenBy = string.Empty;
            iAssociateID = 0;
            dtmTransactionDate = DateTime.MinValue;
            //decTotalAmount = 0.0M;
            iTransactionStatusID = 0;
            strTransactionStatus = string.Empty;
            iModifiedBy = 0;
            strModifiedByName = string.Empty; // PT - You should need the name
            dtmModifiedDate = DateTime.MinValue;
            //decAmountDue = 0.00M;

            decRefundedAmount = 0.0M;
            decTotalCollected = 0.0M;
            decNet = 0.0M;

            //objPs = new Payments();
            //decTotalPaid = 0;
            decTotalOwed = 0;

            blnTransactionsExist = false;

            ////objError = new ClassError();
        }

        public Transaction()
        {
            initialize();
        }

        public Transaction(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnTransactionsExist = true;
            }
            catch (Exception ex)
            {
                blnTransactionsExist = false;
            }
        }

        public Transaction(int TransactionID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetTransactionByID(TransactionID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnTransactionsExist = true;
                }
                else
                {
                    blnTransactionsExist = false;
                }
            }
            catch (Exception ex)
            {
                blnTransactionsExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iTransactionID = Convert.ToInt32(dr["TransactionID"] == Convert.DBNull ? 0 : dr["TransactionID"]);
                iBusinessID = Convert.ToInt32(dr["BusinessID"] == Convert.DBNull ? 0 : dr["BusinessID"]);
                iCustomerID = Convert.ToInt32(dr["CustomerID"] == Convert.DBNull ? 0 : dr["CustomerID"]);
                iAssociateID = Convert.ToInt32(dr["AssociateID"] == Convert.DBNull ? 0 : dr["AssociateID"]);

                dtmTransactionDate = Convert.ToDateTime(dr["TransactionDate"] == Convert.DBNull ? DateTime.MinValue : dr["TransactionDate"]);
                decTotalAmount = Convert.ToDecimal(dr["TotalAmount"] == Convert.DBNull ? 0.0 : dr["TotalAmount"]);
                iTransactionStatusID = Convert.ToInt16(dr["TransactionStatusID"] == Convert.DBNull ? 0 : dr["TransactionStatusID"]);
                strTransactionStatus = Convert.ToString(dr["TransactionStatus"] == Convert.DBNull ? string.Empty : dr["TransactionStatus"]);
                iModifiedBy = Convert.ToInt16(dr["ModifiedBy"] == Convert.DBNull ? 0 : dr["ModifiedBy"]);
                dtmModifiedDate = Convert.ToDateTime(dr["ModifiedDate"] == Convert.DBNull ? DateTime.MinValue : dr["ModifiedDate"]);

                //CHECK INTO THIS
                //decAmountDue = Convert.ToDecimal(dr["AmountDue"] == Convert.DBNull ? 0.0 : dr["AmountDue"]);

                decRefundedAmount = Convert.ToDecimal(dr["RefundedAmount"] == Convert.DBNull ? 0.0 : dr["RefundedAmount"]);
                decTotalCollected = Convert.ToDecimal(dr["TotalCollected"] == Convert.DBNull ? 0.0 : dr["TotalCollected"]);

                decNet = decTotalCollected - decRefundedAmount;

                if (iTransactionStatusID == 3)
                { decTotalOwed = 0; }
                else
                { decTotalOwed = (decTotalAmount - decTotalCollected); }


                strCustomerName = (dr.Table.Columns.Contains("CustomerName") && dr["CustomerName"] != Convert.DBNull) ? Convert.ToString(dr["CustomerName"]) : string.Empty;
                strTakenBy = (dr.Table.Columns.Contains("TakenBy") && dr["TakenBy"] != Convert.DBNull) ? Convert.ToString(dr["TakenBy"]) : string.Empty;
                strModifiedByName = (dr.Table.Columns.Contains("ModifiedByName") && dr["ModifiedByName"] != Convert.DBNull) ? Convert.ToString(dr["ModifiedByName"]) : string.Empty;

                objPs = new Payments(iTransactionID);
                objRs = new Refunds(iTransactionID);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int TransactionID
        {
            get { return iTransactionID; }
            set { iTransactionID = value; }
        }
        public int BusinessID
        {
            get { return iBusinessID; }
            set { iBusinessID = value; }
        }
        public int CustomerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }
        public string CustomerName
        {
            get { return strCustomerName; }
            set { strCustomerName = value; }
        }
        public int AssociateID
        {
            get { return iAssociateID; }
            set { iAssociateID = value; }
        }
        public string TakenBy
        {
            get { return strTakenBy; }
            set { strTakenBy = value; }
        }
        public DateTime TransactionDate
        {
            get { return dtmTransactionDate; }
            set { dtmTransactionDate = value; }
        }
        public decimal TotalAmount
        {
            get { return decTotalAmount; }
        }
        public int TransactionStatusID
        {
            get { return iTransactionStatusID; }
            set { iTransactionStatusID = value; }
        }
        public string TransactionStatus
        {
            get { return strTransactionStatus; }
            set { strTransactionStatus = value; }
        }
        public int ModifiedBy
        {
            get { return iModifiedBy; }
            set { iModifiedBy = value; }
        }
        public string ModifiedByName
        {
            get { return strModifiedByName; }
        }
        public DateTime ModifiedDate
        {
            get { return dtmModifiedDate; }
            set { dtmModifiedDate = value; }
        }
        //new properties
        //********************************************************************

        public decimal RefundedAmount
        {
            get { return decRefundedAmount; }
            set { decRefundedAmount = value; }
        }
        public decimal TotalCollected
        {
            get { return decTotalCollected; }
            set { decTotalCollected = value; }
        }

        public decimal Net
        {
            get { return decNet; }
            set { decNet = value; }
        }

        public Payments PaymentsCollected
        {
            get { return objPs; }
        }

        public Refunds RefundsPaid
        {
            get { return objRs; }
        }

        //********************************************************************


        public decimal TotalOwed
        {
            get { return decTotalOwed; }
        }



        public Boolean TransactionsExists
        {
            get { return blnTransactionsExist; }
            set { blnTransactionsExist = value; }
        }



        public virtual Boolean Update()
        {
            Data obj = new Data();
            int iRet = 0;

            try
            {
                iRet = obj.UpdateTransaction(this);

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
                TransactionID = iRet;
            }

        }



        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(TransactionID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }


    public class Transactions : IEnumerable<Transaction>
    {
        List<Transaction> infoList = new List<Transaction>();

        public Transactions()
        {
            infoList = new List<Transaction>();
        }

        public Transactions(int CustomerID)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            //infoList = new ArrayList();

            dt = objData.GetTransactionsByCustomerID(CustomerID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public Transactions(DateTime TransactionDate)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            //infoList = new ArrayList();

            dt = objData.GetTransactionsByDateRange(TransactionDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }


        public List<Transaction> GetTransactionsBtwDates(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            TransactionSinglePayment objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransactionBtwDates(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new TransactionSinglePayment(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {


                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }

        public List<Transaction> GetTransactionsReport(DateTime StartDate, DateTime EndDate, bool ReceivablesOnly)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransactionsReport(StartDate, EndDate, ReceivablesOnly);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        if (objInfo.PaymentsCollected != null)
                        {
                            objInfo.TotalCollected = objInfo.PaymentsCollected.Sum(x => x.PaymentAmount);
                        }
                        if (objInfo.RefundsPaid != null)
                        {
                            objInfo.RefundedAmount = objInfo.RefundsPaid.Sum(x => x.RefundAmount);

                        }

                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }


        public List<Transaction> GetTransactionPaymentsReport(DateTime StartDate, DateTime EndDate, int AssociateID = 0)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransactionPaymentsReport(StartDate, EndDate, AssociateID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new TransactionSinglePayment(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }

        public List<Transaction> GetTransactionsWithPaymentsByDate(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            TransactionSinglePayment objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransactionsWithPaymentsByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new TransactionSinglePayment(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }
            //retList = retList.OrderByDescending(x => x.TransactionID).ToList();
            return retList;
        }


        public List<Transaction> GetTransCompletedWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransCompletedWOPaymentByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }


        public List<Transaction> GetTransCancelledWORefundByDate(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransCancelledWORefundByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }


        public List<Transaction> GetTransCancelledWRefundByDate(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransCancelledWRefundByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }


        public List<Transaction> GetTransOpenWOPaymentByDate(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Transaction objInfo;

            List<Transaction> retList = new List<Transaction>();

            dt = objData.GetTransOpenWOPaymentByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Transaction(dt.Rows[i]);
                    if (objInfo.TransactionsExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;
        }




        public void Add(Transaction Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Transaction> IEnumerable<Transaction>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

    }


}
