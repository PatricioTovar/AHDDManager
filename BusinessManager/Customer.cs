using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class Customer
    {
        private int iCustomerID;
        private string strFirstName;
        private string strLastName;
        private string strSecondaryFirstName;
        private string strSecondaryLastName;
        private string strAddress;
        private string strCity;
        private string strState;
        private string strZip;
        private DateTime dtmDateCreated;
        private string strPhone;
        private string strMobile;
        private string strFax;
        private string strEmail;
        private Boolean blnActive;
        private Boolean blnCitizen;
        private int iAssignedTo;
        private string strBackgroundColor;
        private string strAssociate;
        private Boolean blnDeleteable;
        private decimal decTotalOwed;

        private Boolean blnCustomersExist;

        //private ClassError objError;


        public void initialize()
        {
            iCustomerID = 0;
            strFirstName = string.Empty;
            strLastName = string.Empty;
            strAddress = string.Empty;
            strCity = string.Empty;
            strState = string.Empty;
            strZip = string.Empty;
            dtmDateCreated = DateTime.MinValue;
            strPhone = string.Empty;
            strMobile = string.Empty;
            strFax = string.Empty;
            strEmail = string.Empty;
            blnActive = false;
            blnCitizen = false;
            strSecondaryFirstName = string.Empty;
            strSecondaryLastName = string.Empty;
            iAssignedTo = 0;
            strBackgroundColor = string.Empty;
            strAssociate = string.Empty;
            blnDeleteable = false;
            decTotalOwed = 0.00M;

            blnCustomersExist = false;

            //objError = new ClassError();
        }


        public Customer()
        {
            initialize();
        }


        public Customer(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnCustomersExist = true;
            }
            catch (Exception ex)
            {
                blnCustomersExist = false;
            }
        }

        public Customer(int CustomerID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetCustomerByID(CustomerID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnCustomersExist = true;
                }
                else
                {
                    blnCustomersExist = false;
                }
            }
            catch (Exception ex)
            {
                blnCustomersExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iCustomerID = Convert.ToInt32(dr["CustomerID"] == Convert.DBNull ? 0 : dr["CustomerID"]);
                strFirstName = Convert.ToString(dr["FirstName"] == Convert.DBNull ? string.Empty : dr["FirstName"]);
                strLastName = Convert.ToString(dr["LastName"] == Convert.DBNull ? string.Empty : dr["LastName"]);
                strSecondaryFirstName = Convert.ToString(dr["SecondaryFirstName"] == Convert.DBNull ? string.Empty : dr["SecondaryFirstName"]);
                strSecondaryLastName = Convert.ToString(dr["SecondaryLastName"] == Convert.DBNull ? string.Empty : dr["SecondaryLastName"]);
                strAddress = Convert.ToString(dr["Address"] == Convert.DBNull ? string.Empty : dr["Address"]);
                strCity = Convert.ToString(dr["City"] == Convert.DBNull ? string.Empty : dr["City"]);
                strState = Convert.ToString(dr["State"] == Convert.DBNull ? string.Empty : dr["State"]);
                strZip = Convert.ToString(dr["Zip"] == Convert.DBNull ? string.Empty : dr["Zip"]);
                dtmDateCreated = Convert.ToDateTime(dr["DateCreated"] == Convert.DBNull ? DateTime.MinValue : dr["DateCreated"]);
                strPhone = Convert.ToString(dr["Phone"] == Convert.DBNull ? string.Empty : dr["Phone"]);
                strMobile = Convert.ToString(dr["Mobile"] == Convert.DBNull ? string.Empty : dr["Mobile"]);
                strFax = Convert.ToString(dr["Fax"] == Convert.DBNull ? string.Empty : dr["Fax"]);
                strEmail = Convert.ToString(dr["Email"] == Convert.DBNull ? string.Empty : dr["Email"]);
                blnActive = Convert.ToBoolean(dr["Active"] == Convert.DBNull ? false : dr["Active"]);
                blnCitizen = Convert.ToBoolean(dr["Citizen"] == Convert.DBNull ? false : dr["Citizen"]);
                iAssignedTo = Convert.ToInt32(dr["AssignedTo"] == Convert.DBNull ? 0 : dr["AssignedTo"]);
                strBackgroundColor = Convert.ToString(dr["BackgroundColor"] == Convert.DBNull ? string.Empty : dr["BackgroundColor"]);
                strAssociate = Convert.ToString(dr["Associate"] == Convert.DBNull ? string.Empty : dr["Associate"]);

                try
                { blnDeleteable = Convert.ToBoolean(dr["Deleteable"] == Convert.DBNull ? false : dr["Deleteable"]); }
                catch
                { blnDeleteable = false; }

                try
                { decTotalOwed = Convert.ToDecimal(dr["TotalOwed"] == Convert.DBNull ? false : dr["TotalOwed"]); }
                catch
                { decTotalOwed = 0.00M; }


            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int CustomerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }
        public string FullName
        {
            get { return strFirstName + " " + strLastName; }
        }
        public string FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }
        public string LastName
        {
            get { return strLastName; }
            set { strLastName = value; }
        }
        public string SecondaryFirstName
        {
            get { return strSecondaryFirstName; }
            set { strSecondaryFirstName = value; }
        }
        public string SecondaryLastName
        {
            get { return strSecondaryLastName; }
            set { strSecondaryLastName = value; }
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
        public string Phone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }

        public string MobileFormatted
        {
            get
            {
                long formated = 0;
                if (Int64.TryParse(strMobile, out formated))
                {
                    return formated.ToString("(###) ###-####");
                }
                else
                {
                    return strMobile;
                }

            }
        }
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
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
        public string Fax
        {
            get { return strFax; }
            set { strFax = value; }
        }
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public Boolean Active
        {
            get { return blnActive; }
            set { blnActive = value; }
        }
        public Boolean Citizen
        {
            get { return blnCitizen; }
            set { blnCitizen = value; }
        }
        public int AssignedTo
        {
            get { return iAssignedTo; }
            set { iAssignedTo = value; }
        }

        public string BackgroundColor
        {
            get { return strBackgroundColor; }
        }
        public string Associate
        {
            get { return strAssociate; }
        }
        public Boolean Deleteable
        {
            get { return blnDeleteable; }
            set { blnDeleteable = value; }
        }

        public decimal TotalOwed
        {
            get { return decTotalOwed; }
            set { decTotalOwed = value; }
        }

        public Boolean CustomersExist
        {
            get { return blnCustomersExist; }
            set { blnCustomersExist = value; }
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
                iRet = obj.UpdateCustomer(this);

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
                CustomerID = iRet;
            }

        }



      
        public Boolean Delete()
        {
          Data obj = new Data();

          try
              {
                return obj.DeleteCustomer(CustomerID);
              }
              catch (Exception ex)
              {
                  return false;
              }
        }
       


    }


    public class Customers : IEnumerable<Customer>
    {
        List<Customer> infoList = new List<Customer>();

        public Customers()
        {
            infoList = new List<Customer>();
        }

        public Customers(string SearchCriteria)
        {
            Data objData = new Data();
            DataTable dt;
            Customer objInfo;

            //infoList = new ArrayList();

            dt = objData.SearchCustomers(SearchCriteria);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Customer(dt.Rows[i]);
                    if (objInfo.CustomersExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public List<Customer> GetCustomerAccountReceivables()
        {
            Data objData = new Data();
            DataTable dt;
            Customer objInfo;            

            dt = objData.GetCustomerAccountReceivables();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Customer(dt.Rows[i]);
                    if (objInfo.CustomersExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

            return infoList;
        }


        public void Add(Customer Info)
        {
            infoList.Add(Info);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<Customer> IEnumerable<Customer>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }





}
