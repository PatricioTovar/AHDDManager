using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class Payment
    {
        private int iPaymentID;
        private int iCustomerID;
        private string strTakenBy;
        private int iTransactionID;
        private int iAssociateID;
        private string strAssociateName;
        private decimal decPaymentAmount;
        private DateTime dtmPaymentDate;
        private int iPaymentMethod;
        private string strMethodDescription;
        private int iCheckNumber;
        private int iDeletedBy;
        private Boolean blnPaymentsExist;

        //private ClassError objError;


        public void initialize()
        {
            iPaymentID = 0;
            iCustomerID = 0;
            strTakenBy = string.Empty;
            iTransactionID = 0;
            iAssociateID = 0;
            strAssociateName = string.Empty;
            decPaymentAmount = 0.0M;
            dtmPaymentDate = DateTime.MinValue;
            iPaymentMethod = 0;
            strMethodDescription = string.Empty;
            iCheckNumber = 0;
            iDeletedBy = 0;

            blnPaymentsExist = false;

            //objError = new ClassError();
        }


        public Payment()
        {
            initialize();
        }


        public Payment(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnPaymentsExist = true;
            }
            catch (Exception ex)
            {
                blnPaymentsExist = false;
            }
        }

        public Payment(int PaymentID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetPaymentByID(PaymentID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnPaymentsExist = true;
                }
                else
                {
                    blnPaymentsExist = false;
                }
            }
            catch (Exception ex)
            {
                blnPaymentsExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iPaymentID = Convert.ToInt32(dr["PaymentID"] == Convert.DBNull ? 0 : dr["PaymentID"]);
                iCustomerID = Convert.ToInt32(dr["CustomerID"] == Convert.DBNull ? 0 : dr["CustomerID"]);
                strTakenBy = Convert.ToString(dr["Name"] == Convert.DBNull ? string.Empty : dr["Name"]);
                iTransactionID = Convert.ToInt32(dr["TransactionID"] == Convert.DBNull ? 0 : dr["TransactionID"]);
                iAssociateID = Convert.ToInt32(dr["AssociateID"] == Convert.DBNull ? 0 : dr["AssociateID"]);

                decPaymentAmount = Convert.ToDecimal(dr["PaymentAmount"] == Convert.DBNull ? 0.0 : dr["PaymentAmount"]);
                dtmPaymentDate = Convert.ToDateTime(dr["PaymentDate"] == Convert.DBNull ? DateTime.MinValue : dr["PaymentDate"]);
                iPaymentMethod = Convert.ToInt32(dr["PaymentMethod"] == Convert.DBNull ? 0 : dr["PaymentMethod"]);
                strMethodDescription = Convert.ToString(dr["MethodDescription"] == Convert.DBNull ? string.Empty : dr["MethodDescription"]);
                iCheckNumber = Convert.ToInt32(dr["CheckNumber"] == Convert.DBNull ? 0 : dr["CheckNumber"]);
                iDeletedBy = Convert.ToInt16(dr["DeletedBy"] == Convert.DBNull ? 0 : dr["DeletedBy"]);

                try { strAssociateName = Convert.ToString(dr["AssociateName"] == Convert.DBNull ? string.Empty : dr["AssociateName"]); }
                catch { strAssociateName = string.Empty; }


            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int PaymentID
        {
            get { return iPaymentID; }
            set { iPaymentID = value; }
        }
        public int CustomerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }
        public int TransactionID
        {
            get { return iTransactionID; }
            set { iTransactionID = value; }
        }
        public int AssociateID
        {
            get { return iAssociateID; }
            set { iAssociateID = value; }
        }
        public string AssociateName
        {
            get { return strAssociateName; }
            set { strAssociateName = value; }
        }
        public string TakenBy
        {
            get { return strTakenBy; }
        }

        public decimal PaymentAmount
        {
            get { return decPaymentAmount; }
            set { decPaymentAmount = value; }
        }
        public DateTime PaymentDate
        {
            get { return dtmPaymentDate; }
            set { dtmPaymentDate = value; }
        }
        public int PaymentMethod
        {
            get { return iPaymentMethod; }
            set { iPaymentMethod = value; }
        }



        public string PaymentMethodDescription
        {
            get { return strMethodDescription; }
        }


        public int CheckNumber
        {
            get { return iCheckNumber; }
            set { iCheckNumber = value; }
        }

        public int DeletedBy
        {
            get { return iDeletedBy; }
            set { iDeletedBy = value; }
        }

        public Boolean PaymentExist
        {
            get { return blnPaymentsExist; }
            set { blnPaymentsExist = value; }
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
                iRet = obj.UpdatePayment(this);

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
                PaymentID = iRet;
            }

        }


        public Customer GetCustomerByPaymentID(int PaymentID)
        {
            Data obj = new Data();
            DataTable dt;
            AHDDManagerClass.Customer objC = new Customer();

            try
            {
                dt = obj.GetCustomerInfoByPaymentID(PaymentID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    objC = new Customer(dt.Rows[0]);
                    if (objC.CustomersExist)
                    {
                        return objC;
                    }
                    else
                    {
                        throw new Exception("Error getting Customer info.");
                    }
                }
                else
                {
                    throw new Exception("Error getting Customer info.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Customer info.");
            }
        }

        public Transaction GetTransactionByPaymentID(int PaymentID)
        {
            Data obj = new Data();
            DataTable dt;
            AHDDManagerClass.Transaction obT = new Transaction();

            try
            {
                dt = obj.GetTransactionByPaymentID(PaymentID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obT = new Transaction(dt.Rows[0]);
                    if (obT.TransactionsExists)
                    {
                        return obT;
                    }
                    else
                    {
                        throw new Exception("Error getting transaction info.");
                    }
                }
                else
                {
                    throw new Exception("Error getting transaction info.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting transaction info.");
            }
        }


        public List<TransactionDetail> GetTransactionDetailsByPaymentID(int PaymentID)
        {
            Data objData = new Data();
            DataTable dt;
            TransactionDetail objInfo;
            List<TransactionDetail> retList = new List<TransactionDetail>();

            dt = objData.GetTransactionDetailsByPaymentID(PaymentID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new TransactionDetail(dt.Rows[i]);
                    if (objInfo.TransactionDetailsExist)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;

        }

        public Boolean Delete(int DeletedBy)
        {
            return Delete(iPaymentID, DeletedBy);
        }

        public Boolean Delete(int paymentID, int DeletedBy)
        {
            Data obj = new Data();

            try
            {
                return obj.DeletePayment(paymentID, DeletedBy);

            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }

    public class Payments : IEnumerable<Payment>
    {
        List<Payment> infoList = new List<Payment>();

        decimal decCashTotal = 0.00M;
        decimal decCardTotal = 0.00M;
        decimal decCheckTotal = 0.00M;

        public Payments()
        {
            infoList = new List<Payment>();
        }

        public Payments(int TransactionID)
        {
            Data objData = new Data();
            DataTable dt;
            Payment objInfo;

            decCashTotal = 0.00M;
            decCardTotal = 0.00M;
            decCheckTotal = 0.00M;

            dt = objData.GetPaymentsByTransactionID(TransactionID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Payment(dt.Rows[i]);
                    if (objInfo.PaymentExist)
                    {
                        infoList.Add(objInfo);


                        switch (objInfo.PaymentMethod)
                        {
                            case 1:
                                decCashTotal += objInfo.PaymentAmount;
                                break;
                            case 2:
                                decCheckTotal += objInfo.PaymentAmount;
                                break;
                            case 3:
                                decCardTotal += objInfo.PaymentAmount;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

        }


        public Payments(int AssociateID, DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Payment objInfo;

            decCashTotal = 0.00M;
            decCardTotal = 0.00M;
            decCheckTotal = 0.00M;

            dt = objData.GetPaymentsCollectedByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Payment(dt.Rows[i]);
                    if (objInfo.PaymentExist)
                    {
                        infoList.Add(objInfo);

                        switch (objInfo.PaymentMethod)
                        {
                            case 1:
                                decCashTotal += objInfo.PaymentAmount;
                                break;
                            case 2:
                                decCheckTotal += objInfo.PaymentAmount;
                                break;
                            case 3:
                                decCardTotal += objInfo.PaymentAmount;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

        }

        public decimal CashTotal { get { return decCashTotal; } }
        public decimal CardTotal { get { return decCardTotal; } }
        public decimal CheckTotal { get { return decCheckTotal; } }

        public List<PaymentCollected> GetPaymentsCollectedByDateRange(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            PaymentCollected objPC;
            List<PaymentCollected> RetList = new List<PaymentCollected>();

            decCashTotal = 0.00M;
            decCardTotal = 0.00M;
            decCheckTotal = 0.00M;

            dt = objData.GetPaymentsCollectedByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPC = new PaymentCollected(Convert.ToInt32(dt.Rows[i]["AssociateID"]), dt.Rows[i]["AssociateName"].ToString(), Convert.ToDecimal(dt.Rows[i]["TotalCollected"]));

                    RetList.Add(objPC);
                }
            }

            return RetList;
        }


        public List<Payment> GetPaymentsCollectedByAsscociateID(int AssociateID, DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Payment objInfo;

            decCashTotal = 0.00M;
            decCardTotal = 0.00M;
            decCheckTotal = 0.00M;

            dt = objData.GetPaymentsCollectedByAsscociateID(AssociateID, StartDate, EndDate);

            infoList = new List<Payment>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Payment(dt.Rows[i]);
                    if (objInfo.PaymentExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

            return infoList;
        }


        public List<Payment> GetCustomerPayments(int CustomerID)
        {
            Data objData = new Data();
            DataTable dt;
            Payment objInfo;

            decCashTotal = 0.00M;
            decCardTotal = 0.00M;
            decCheckTotal = 0.00M;

            dt = objData.GetPaymentsByCustomerID(CustomerID);

            infoList = new List<Payment>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Payment(dt.Rows[i]);
                    if (objInfo.PaymentExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

            return infoList;
        }


        public PaymentMethodCounts GetPayMethodCountsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            PaymentMethodCounts ret = new PaymentMethodCounts(StartDate, EndDate);

            return ret;
        }


        public PaymentMethodCounts GetPayMethodCountsByDateRangeAssocID(DateTime StartDate, DateTime EndDate, int AssociateID)
        {
            PaymentMethodCounts ret = new PaymentMethodCounts(StartDate, EndDate, AssociateID);

            return ret;
        }



        public void Add(Payment Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Payment> IEnumerable<Payment>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }

    public class PaymentMethodCount
    {
        public string PaymentMethod { get; set; }
        public int MethodCount { get; set; }
        public decimal TotalAmount { get; set; }


        public PaymentMethodCount(string paymentmethod, int methodcount, decimal total)
        {
            PaymentMethod = paymentmethod;
            MethodCount = methodcount;
            TotalAmount = total;
        }
    }


    public class PaymentMethodCounts : IEnumerable<PaymentMethodCount>
    {
        public List<PaymentMethodCount> infoList = new List<PaymentMethodCount>();


        public decimal OverallTotal { get; set; }




        public PaymentMethodCounts()
        {
            infoList = new List<PaymentMethodCount>();
        }


        public PaymentMethodCounts(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            PaymentMethodCount objInfo;

            OverallTotal = 0.00M;

            infoList = new List<PaymentMethodCount>();

            dt = objData.GetPayMethodCountsByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PaymentMethod"].ToString().ToUpper() == "TOTAL")
                    {
                        OverallTotal = Convert.ToDecimal(dt.Rows[i]["TotalCollected"]);
                    }
                    else
                    {
                        objInfo = new PaymentMethodCount(dt.Rows[i]["PaymentMethod"].ToString(), Convert.ToInt16(dt.Rows[i]["MethodCount"]), Convert.ToDecimal(dt.Rows[i]["TotalCollected"]));

                        infoList.Add(objInfo);
                    }
                }
            }

        }


        public PaymentMethodCounts(DateTime StartDate, DateTime EndDate, int AssociateID)
        {

            Data objData = new Data();
            DataTable dt;
            PaymentMethodCount objInfo;

            infoList = new List<PaymentMethodCount>();

            OverallTotal = 0.00M;

            dt = objData.GetPayMethodCountsByDateRangeAssocID(StartDate, EndDate, AssociateID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PaymentMethod"].ToString().ToUpper() == "TOTAL")
                    {
                        OverallTotal = dt.Rows[i]["TotalCollected"] == System.DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[i]["TotalCollected"]);
                    }
                    else
                    {
                        objInfo = new PaymentMethodCount(dt.Rows[i]["PaymentMethod"].ToString(), Convert.ToInt16(dt.Rows[i]["MethodCount"]), Convert.ToDecimal(dt.Rows[i]["TotalCollected"]));

                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public void Add(PaymentMethodCount Info)
        {
            infoList.Add(Info);
        }

        public IEnumerator<PaymentMethodCount> GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }


    public class PaymentDetail
    {
        private int iPaymentID;
        private int iCustomerID;
        private string strCustomerName;
        private int iTransactionID;
        private int iAssociateID;
        private string strAssociateName;
        private decimal dPaymentAmount;
        private DateTime dtPaymentDate;
        private int iPaymentMethod;
        private string strMethodDescription;
        private int iCheckNumber;
        private int iDeletedBy;

        public void initialize()
        {
            iPaymentID = 0;
            iCustomerID = 0;
            strCustomerName = string.Empty;
            iTransactionID = 0;
            iAssociateID = 0;
            strAssociateName = string.Empty;
            dPaymentAmount = 0;
            dtPaymentDate = DateTime.MinValue;
            iPaymentMethod = 0;
            strMethodDescription = string.Empty;
            iCheckNumber = 0;
            iDeletedBy = 0;

        }

        public PaymentDetail()
        {
            initialize();
        }

        public PaymentDetail(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
            }
            catch (Exception ex)
            {
            }
        }

        public void Load(DataRow dr)
        {
            try
            {
                iPaymentID = Convert.ToInt32(dr["PaymentID"] == Convert.DBNull ? 0 : dr["PaymentID"]);
                iCustomerID = Convert.ToInt32(dr["CustomerID"] == Convert.DBNull ? 0 : dr["CustomerID"]);
                strCustomerName = Convert.ToString(dr["CustomerName"] == Convert.DBNull ? string.Empty : dr["CustomerName"]);
                iTransactionID = Convert.ToInt32(dr["TransactionID"] == Convert.DBNull ? 0 : dr["TransactionID"]);
                iAssociateID = Convert.ToInt32(dr["AssociateID"] == Convert.DBNull ? 0 : dr["AssociateID"]);
                strAssociateName = Convert.ToString(dr["AssociateName"] == Convert.DBNull ? string.Empty : dr["AssociateName"]);

                dPaymentAmount = Convert.ToDecimal(dr["PaymentAmount"] == Convert.DBNull ? 0.0 : dr["PaymentAmount"]);
                dtPaymentDate = Convert.ToDateTime(dr["PaymentDate"] == Convert.DBNull ? DateTime.MinValue : dr["PaymentDate"]);
                iPaymentMethod = Convert.ToInt32(dr["PaymentMethod"] == Convert.DBNull ? 0 : dr["PaymentMethod"]);
                strMethodDescription = Convert.ToString(dr["MethodDescription"] == Convert.DBNull ? string.Empty : dr["MethodDescription"]);
                iCheckNumber = Convert.ToInt32(dr["CheckNumber"] == Convert.DBNull ? 0 : dr["CheckNumber"]);
                iDeletedBy = Convert.ToInt16(dr["DeletedBy"] == Convert.DBNull ? 0 : dr["DeletedBy"]);



            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int PaymentID
        {
            get { return iPaymentID; }
            set { iPaymentID = value; }
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
        public int TransactionID
        {
            get { return iTransactionID; }
            set { iTransactionID = value; }
        }
        public int AssociateID
        {
            get { return iAssociateID; }
            set { iAssociateID = value; }
        }
        public string AssociateName
        {
            get { return strAssociateName; }
            set { strAssociateName = value; }
        }

        public decimal PaymentAmount
        {
            get { return dPaymentAmount; }
            set { dPaymentAmount = value; }
        }
        public DateTime PaymentDate
        {
            get { return dtPaymentDate; }
            set { dtPaymentDate = value; }
        }
        public int PaymentMethod
        {
            get { return iPaymentMethod; }
            set { iPaymentMethod = value; }
        }

        public string MethodDescription
        {
            get { return strMethodDescription; }
            set { strMethodDescription = value; }
        }
        public int CheckNumber
        {
            get { return iCheckNumber; }
            set { iCheckNumber = value; }
        }
        public int DeletedBy
        {
            get { return iDeletedBy; }
            set { iDeletedBy = value; }
        }



        public List<PaymentDetail> GetPaymentDetailsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            List<PaymentDetail> retList = new List<PaymentDetail>();

            dt = objData.GetPaymentDetailsByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PaymentDetail objInfo = new PaymentDetail(dt.Rows[i]);
                    retList.Add(objInfo);
                }
            }

            return retList;

        }
    }
}
