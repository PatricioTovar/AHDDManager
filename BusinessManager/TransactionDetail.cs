using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class TransactionDetail
    {
        private int iTransactionDetailID;
        private int iTransactionID;
        private int iFormID;
        private string strFormTitle;
        private decimal decUnitPrice;
        private decimal decDiscountPrice;
        private int iQuantity;
        private string strNotes;
        private decimal decTotal;
        private int iDeletedBy;
        private Boolean blnTransactionDetailsExist;

        //private ClassError objError;


        public void initialize()
        {
            iTransactionDetailID = 0;
            iTransactionID = 0;
            iFormID = 0;
            strFormTitle = string.Empty;
            decUnitPrice = 0.0M;
            decDiscountPrice = 0.0M;
            iQuantity = 0;
            strNotes = string.Empty;
            decTotal = 0.0M;
            iDeletedBy = 0;

            blnTransactionDetailsExist = false;

            //objError = new ClassError();
        }


        public TransactionDetail()
        {
            initialize();
        }


        public TransactionDetail(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnTransactionDetailsExist = true;
            }
            catch (Exception ex)
            {
                blnTransactionDetailsExist = false;
            }
        }

        public TransactionDetail(int TransactionDetailID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetTransactionDetailByID(TransactionDetailID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnTransactionDetailsExist = true;
                }
                else
                {
                    blnTransactionDetailsExist = false;
                }
            }
            catch (Exception ex)
            {
                blnTransactionDetailsExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iTransactionDetailID = Convert.ToInt32(dr["TransactionDetailID"] == Convert.DBNull ? 0 : dr["TransactionDetailID"]);
                iTransactionID = Convert.ToInt32(dr["TransactionID"] == Convert.DBNull ? 0 : dr["TransactionID"]);
                iFormID = Convert.ToInt32(dr["FormID"] == Convert.DBNull ? 0 : dr["FormID"]);
                strFormTitle = Convert.ToString(dr["FormTitle"] == Convert.DBNull ? string.Empty : dr["FormTitle"]);
                decUnitPrice = Convert.ToDecimal(dr["UnitPrice"] == Convert.DBNull ? 0.0 : dr["UnitPrice"]);
                decDiscountPrice = Convert.ToDecimal(dr["DiscountPrice"] == Convert.DBNull ? 0.0 : dr["DiscountPrice"]);
                iQuantity = Convert.ToInt32(dr["Quantity"] == Convert.DBNull ? 0 : dr["Quantity"]);
                strNotes = Convert.ToString(dr["Notes"] == Convert.DBNull ? string.Empty : dr["Notes"]);
                iDeletedBy = Convert.ToInt16(dr["DeletedBy"] == Convert.DBNull ? 0 : dr["DeletedBy"]);
                decTotal = Convert.ToDecimal(dr["Total"] == Convert.DBNull ? 0.0 : dr["Total"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int TransactionDetailID
        {
            get { return iTransactionDetailID; }
            set { iTransactionDetailID = value; }
        }
        public int TransactionID
        {
            get { return iTransactionID; }
            set { iTransactionID = value; }
        }
        public int FormID
        {
            get { return iFormID; }
            set { iFormID = value; }
        }
        public string FormTitle
        {
            get { return strFormTitle; }
            set { strFormTitle = value; }
        }
        public decimal UnitPrice
        {
            get { return decUnitPrice; }
            set { decUnitPrice = value; }
        }
        public decimal DiscountPrice
        {
            get { return decDiscountPrice; }
            set { decDiscountPrice = value; }
        }

        public decimal PriceCharged
        {
            get
            {
                if (decDiscountPrice == 0M)
                {
                    return UnitPrice;
                }
                else
                {
                    return DiscountPrice;
                }

            }
        }


        public int Quantity
        {
            get { return iQuantity; }
            set { iQuantity = value; }
        }
        public string Notes
        {
            get { return strNotes; }
            set { strNotes = value; }
        }
        public decimal Total
        {
            get { return decTotal; }
            set { decTotal = value; }
        }
        public int DeletedBy
        {
            get { return iDeletedBy; }
            set { iDeletedBy = value; }
        }
        public Boolean TransactionDetailsExist
        {
            get { return blnTransactionDetailsExist; }
            set { blnTransactionDetailsExist = value; }
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
                iRet = obj.UpdateTransactionDetail(this);

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
                TransactionDetailID = iRet;
            }

        }


        public Boolean Delete(int DeletedBy)
        {
            return Delete(iTransactionDetailID, DeletedBy);
        }

        public Boolean Delete(int transactionDetailID, int DeletedBy)
        {
            Data obj = new Data();

            try
            {
                return obj.DeleteTransactionDetail(transactionDetailID, DeletedBy);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }



    public class TransactionDetails : IEnumerable<TransactionDetail>
    {
        List<TransactionDetail> infoList = new List<TransactionDetail>();

        public TransactionDetails()
        {
            infoList = new List<TransactionDetail>();
        }

        public TransactionDetails(int TransactionID)
        {
            Data objData = new Data();
            DataTable dt;
            TransactionDetail objInfo;

            dt = objData.GetTransactionDetailsByTransactionID(TransactionID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new TransactionDetail(dt.Rows[i]);
                    if (objInfo.TransactionDetailsExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }
        }

        public void Add(TransactionDetail Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<TransactionDetail> IEnumerable<TransactionDetail>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }







}
