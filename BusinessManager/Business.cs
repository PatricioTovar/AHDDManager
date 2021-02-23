using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class Business
    {
        private int iBusinessID;
        private string strBusinessName;
        private string strAddress;
        private string strCity;
        private string strState;
        private string strZip;
        private DateTime dtmDateCreated;
        private DateTime dtmDatePaidThru;
        private Boolean blnActive;
        private string strConatctFirstName;
        private string strContactLastName;
        private string strContactMobile;
        private string strPhone;
        private string strFax;
        private string strPassword;
        private Boolean blnBusinessesExist;

        //private ClassError objError;


        public void initialize()
        {
            iBusinessID = 0;
            strBusinessName = string.Empty;
            strAddress = string.Empty;
            strCity = string.Empty;
            strState = string.Empty;
            strZip = string.Empty;
            dtmDateCreated = DateTime.MinValue;
            dtmDatePaidThru = DateTime.MinValue;
            blnActive = false;
            strConatctFirstName = string.Empty;
            strContactLastName = string.Empty;
            strContactMobile = string.Empty;
            strPhone = string.Empty;
            strFax = string.Empty;
            strPassword = string.Empty;

            blnBusinessesExist = false;

            //objError = new ClassError();
        }


        public Business()
        {
            initialize();
        }


        public Business(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnBusinessesExist = true;
            }
            catch (Exception ex)
            {
                blnBusinessesExist = false;
            }
        }

        public Business(int BusinessID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetBusinessByID(BusinessID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnBusinessesExist = true;
                }
                else
                {
                    blnBusinessesExist = false;
                }
            }
            catch (Exception ex)
            {
                blnBusinessesExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iBusinessID = Convert.ToInt32(dr["BusinessID"] == Convert.DBNull ? 0 : dr["BusinessID"]);
                strBusinessName = Convert.ToString(dr["BusinessName"] == Convert.DBNull ? string.Empty : dr["BusinessName"]);
                strAddress = Convert.ToString(dr["Address"] == Convert.DBNull ? string.Empty : dr["Address"]);
                strCity = Convert.ToString(dr["City"] == Convert.DBNull ? string.Empty : dr["City"]);
                strState = Convert.ToString(dr["State"] == Convert.DBNull ? string.Empty : dr["State"]);
                strZip = Convert.ToString(dr["Zip"] == Convert.DBNull ? string.Empty : dr["Zip"]);
                dtmDateCreated = Convert.ToDateTime(dr["DateCreated"] == Convert.DBNull ? DateTime.MinValue : dr["DateCreated"]);
                dtmDatePaidThru = Convert.ToDateTime(dr["DatePaidThru"] == Convert.DBNull ? DateTime.MinValue : dr["DatePaidThru"]);
                blnActive = Convert.ToBoolean(dr["Active"] == Convert.DBNull ? false : dr["Active"]);
                strConatctFirstName = Convert.ToString(dr["ConatctFirstName"] == Convert.DBNull ? string.Empty : dr["ConatctFirstName"]);
                strContactLastName = Convert.ToString(dr["ContactLastName"] == Convert.DBNull ? string.Empty : dr["ContactLastName"]);
                strContactMobile = Convert.ToString(dr["ContactMobile"] == Convert.DBNull ? string.Empty : dr["ContactMobile"]);
                strPhone = Convert.ToString(dr["Phone"] == Convert.DBNull ? string.Empty : dr["Phone"]);
                strFax = Convert.ToString(dr["Fax"] == Convert.DBNull ? string.Empty : dr["Fax"]);
                strPassword = Convert.ToString(dr["Password"] == Convert.DBNull ? string.Empty : dr["Password"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int BusinessID
        {
            get { return iBusinessID; }
            set { iBusinessID = value; }
        }
        public string BusinessName
        {
            get { return strBusinessName; }
            set { strBusinessName = value; }
        }
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }
        public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }
        public string State
        {
            get { return strState; }
            set { strState = value; }
        }
        public string Zip
        {
            get { return strZip; }
            set { strZip = value; }
        }
        public DateTime DateCreated
        {
            get { return dtmDateCreated; }
            set { dtmDateCreated = value; }
        }
        public DateTime DatePaidThru
        {
            get { return dtmDatePaidThru; }
            set { dtmDatePaidThru = value; }
        }
        public Boolean Active
        {
            get { return blnActive; }
            set { blnActive = value; }
        }
        public string ConatctFirstName
        {
            get { return strConatctFirstName; }
            set { strConatctFirstName = value; }
        }
        public string ContactLastName
        {
            get { return strContactLastName; }
            set { strContactLastName = value; }
        }
        public string ContactMobile
        {
            get { return strContactMobile; }
            set { strContactMobile = value; }
        }
        public string ContactMobileFormatted
        {
            get
            {
                long formated = 0;
                if (Int64.TryParse(strContactMobile, out formated))
                {
                    return formated.ToString("(###) ###-####");
                }
                else
                {
                    return strContactMobile;
                }
            }
        }
        public string Phone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }
        public string PhoneFomatted
        {
            get
            {
                long formated = 0;
                if (Int64.TryParse(strPhone, out formated))
                {
                    return formated.ToString("(###) ###-####");
                }
                else
                {
                    return strPhone;
                }
            }
        }

        public string Fax
        {
            get { return strFax; }
            set { strFax = value; }
        }
        public string FaxFormatted
        {
            get
            {
                long formated = 0;
                if (Int64.TryParse(strFax, out formated))
                {
                    return formated.ToString("(###) ###-####");
                }
                else
                {
                    return strFax;
                }
            }
        }
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
        public Boolean BusinessesExist
        {
            get { return blnBusinessesExist; }
            set { blnBusinessesExist = value; }
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
                iRet = obj.UpdateBusiness(this);

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
                BusinessID = iRet;
            }

        }



        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(BusinessID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }



    public class Businesses : IEnumerable<Business>
    {
        List<Business> infoList = new List<Business>();
        public Businesses()
        {
            infoList = new List<Business>();
        }
        public void Add(Business Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<Business> IEnumerable<Business>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }






}
