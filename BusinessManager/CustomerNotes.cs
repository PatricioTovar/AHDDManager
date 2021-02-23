using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class CustomerNote
    {
        private int iCustomerNoteID;
        private int iCustomerID;
        private string strNote;
        private int iAddedBy;
        private string strAddedByName;
        private DateTime dtmDateAdded;
        private Boolean blnCustomerNoteExists;

        public void initialize()
        {
            iCustomerNoteID = 0;
            iCustomerID = 0;
            strNote = string.Empty;
            iAddedBy = 0;
            strAddedByName = string.Empty;
            dtmDateAdded = DateTime.MinValue;

            blnCustomerNoteExists = false;

            //objError = new ClassError();
        }


        public CustomerNote()
        {
            initialize();
        }


        public CustomerNote(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnCustomerNoteExists = true;
            }
            catch (Exception ex)
            {
                blnCustomerNoteExists = false;
            }
        }

        public CustomerNote(int CustomerNoteID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetCustomerNoteByID(CustomerNoteID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnCustomerNoteExists = true;
                }
                else
                {
                    blnCustomerNoteExists = false;
                }
            }
            catch (Exception ex)
            {
                blnCustomerNoteExists = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iCustomerNoteID = Convert.ToInt32(dr["CustomerNoteID"] == Convert.DBNull ? 0 : dr["CustomerNoteID"]);
                iCustomerID = Convert.ToInt32(dr["CustomerID"] == Convert.DBNull ? 0 : dr["CustomerID"]);
                strNote = Convert.ToString(dr["Note"] == Convert.DBNull ? string.Empty : dr["Note"]);
                iAddedBy = Convert.ToInt32(dr["AddedBy"] == Convert.DBNull ? 0 : dr["AddedBy"]);
                strAddedByName= Convert.ToString(dr["AddedByName"] == Convert.DBNull ? string.Empty : dr["AddedByName"]);
                dtmDateAdded = Convert.ToDateTime(dr["DateAdded"] == Convert.DBNull ? DateTime.MinValue : dr["DateAdded"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int CustomerNoteID
        {
            get { return iCustomerNoteID; }
            set { iCustomerNoteID = value; }
        }
        public int CustomerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }
        public string Note
        {
            get { return strNote; }
            set { strNote = value; }
        }
        public int AddedBy
        {
            get { return iAddedBy; }
            set { iAddedBy = value; }
        }
        public string AddedByName
        {
            get { return strAddedByName; }
        }

        public DateTime DateAdded
        {
            get { return dtmDateAdded; }
            set { dtmDateAdded = value; }
        }
        public Boolean CustomerNoteExists
        {
            get { return blnCustomerNoteExists; }
            set { blnCustomerNoteExists = value; }
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
                iRet = obj.UpdateCustomerNote(this);

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
                CustomerNoteID = iRet;
            }

        }

        public Boolean Delete(int customerNoteID)
        {
            Data obj = new Data();

            try
            {
                return obj.DeleteCustomerNote(customerNoteID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(CustomerNoteID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }




    public class CustomerNotes : IEnumerable<CustomerNote>
    {
        List<CustomerNote> infoList = new List<CustomerNote>();

        public CustomerNotes()
        {
            infoList = new List<CustomerNote>();
        }

        public CustomerNotes(int CustomerID)
        {
            Data objData = new Data();
            DataTable dt;
            CustomerNote objInfo;

            infoList = new List<CustomerNote>();

            dt = objData.GetCustomerNotesByCustomerID(CustomerID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new CustomerNote(dt.Rows[i]);
                    if (objInfo.CustomerNoteExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public void Add(CustomerNote Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<CustomerNote> IEnumerable<CustomerNote>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

    }




}
