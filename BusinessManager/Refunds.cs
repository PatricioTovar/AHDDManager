using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{


    public class Refund
    {
        private int iRefundID;
        private int iTransactionID;
        private decimal decRefundAmount;
        private DateTime dtmRefundDate;
        private int iRefundedBy;
        private string strRefundedByName;
        private string strNote;
        private Boolean blnRefundExists;
        
        public void initialize()
        {
            iRefundID = 0;
            iTransactionID = 0;
            decRefundAmount = 0.0M;
            dtmRefundDate = DateTime.MinValue;
            iRefundedBy = 0;
            strRefundedByName = string.Empty;
            strNote = string.Empty;

            blnRefundExists = false;

            //objError = new ClassError();
        }


        public Refund()
        {
            initialize();
        }


        public Refund(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnRefundExists = true;
            }
            catch (Exception ex)
            {
                blnRefundExists = false;
            }
        }

        public Refund(int RefundID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetRefundByID(RefundID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Load(dt.Rows[0]);
                    blnRefundExists = true;
                }
                else
                {
                    blnRefundExists = false;
                }
            }
            catch (Exception ex)
            {
                blnRefundExists = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iRefundID = Convert.ToInt16(dr["RefundID"] == Convert.DBNull ? 0 : dr["RefundID"]);
                iTransactionID = Convert.ToInt16(dr["TransactionID"] == Convert.DBNull ? 0 : dr["TransactionID"]);
                decRefundAmount = Convert.ToDecimal(dr["RefundAmount"] == Convert.DBNull ? 0.0 : dr["RefundAmount"]);
                dtmRefundDate = Convert.ToDateTime(dr["RefundDate"] == Convert.DBNull ? DateTime.MinValue : dr["RefundDate"]);
                iRefundedBy = Convert.ToInt16(dr["RefundedBy"] == Convert.DBNull ? 0 : dr["RefundedBy"]);
                strNote = Convert.ToString(dr["Note"] == Convert.DBNull ? string.Empty : dr["Note"]);

                try
                { strRefundedByName = Convert.ToString(dr["RefundedByName"]); }
                catch
                { strRefundedByName = string.Empty; }
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int RefundID
        {
            get { return iRefundID; }
            set { iRefundID = value; }
        }
        public int TransactionID
        {
            get { return iTransactionID; }
            set { iTransactionID = value; }
        }
        public decimal RefundAmount
        {
            get { return decRefundAmount; }
            set { decRefundAmount = value; }
        }
        public DateTime RefundDate
        {
            get { return dtmRefundDate; }
            set { dtmRefundDate = value; }
        }
        public int RefundedBy
        {
            get { return iRefundedBy; }
            set { iRefundedBy = value; }
        }
        public string RefundedByName
        {
            get { return strRefundedByName; }
        }
        public string Note
        {
            get { return strNote; }
            set { strNote = value; }
        }
        public Boolean RefundExists
        {
            get { return blnRefundExists; }
            set { blnRefundExists = value; }
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
                iRet = obj.UpdateRefund(this);

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
                RefundID = iRet;
            }

        }



        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(RefundID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }


    public class Refunds : IEnumerable<Refund>
    {
        List<Refund> infoList = new List<Refund>();

        public Refunds()
        {
            infoList = new List<Refund>();
        }


        public Refunds(int TransactionID)
        {
            Data objData = new Data();
            DataTable dt;
            Refund objInfo;

            dt = objData.GetRefundsByTransactionID(TransactionID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Refund(dt.Rows[i]);
                    if (objInfo.RefundExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }



        public void Add(Refund Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Refund> IEnumerable<Refund>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }





}
