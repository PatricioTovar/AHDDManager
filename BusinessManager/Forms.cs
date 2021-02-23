using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class Form
    {
        private int iFormID;
        private string strTitle;
        private string strFormName;
        private Boolean blnActive;
        private decimal decPrice;
        private Boolean blnDeleteable;

        private Boolean blnFormsExist;

        //private ClassError objError;


        public void initialize()
        {
            iFormID = 0;
            strTitle = string.Empty;
            strFormName = string.Empty;
            blnActive = false;
            decPrice = 0.0M;
            blnDeleteable = false;

            blnFormsExist = false;

            //objError = new ClassError();
        }


        public Form()
        {
            initialize();
        }


        public Form(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnFormsExist = true;
            }
            catch (Exception ex)
            {
                blnFormsExist = false;
            }
        }

        public Form(int FormID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetFormByID(FormID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Load(dt.Rows[0]);
                    blnFormsExist = true;
                }
                else
                {
                    blnFormsExist = false;
                }
            }
            catch (Exception ex)
            {
                blnFormsExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iFormID = Convert.ToInt32(dr["FormID"] == Convert.DBNull ? 0 : dr["FormID"]);
                strTitle = Convert.ToString(dr["Title"] == Convert.DBNull ? string.Empty : dr["Title"]);
                strFormName = Convert.ToString(dr["FormName"] == Convert.DBNull ? string.Empty : dr["FormName"]);
                blnActive = Convert.ToBoolean(dr["Active"] == Convert.DBNull ? false : dr["Active"]);
                decPrice = Convert.ToDecimal(dr["Price"] == Convert.DBNull ? 0.0 : dr["Price"]);

                try
                { blnDeleteable = Convert.ToBoolean(dr["Deleteable"] == Convert.DBNull ? false : dr["Deleteable"]); }
                catch
                { blnDeleteable = false; }
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int FormID
        {
            get { return iFormID; }
            set { iFormID = value; }
        }
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }
        public string FormName
        {
            get { return strFormName; }
            set { strFormName = value; }
        }
        public Boolean Active
        {
            get { return blnActive; }
            set { blnActive = value; }
        }
        public decimal Price
        {
            get { return decPrice; }
            set { decPrice = value; }
        }
        public Boolean Deleteable
        {
            get { return blnDeleteable; }
            set { blnDeleteable = value; }
        }
        public Boolean FormsExists
        {
            get { return blnFormsExist; }
            set { blnFormsExist = value; }
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
                iRet = obj.UpdateForm(this);

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
                FormID = iRet;
            }

        }



        
        public Boolean Delete()
        {
          Data obj = new Data();
            
          try
              {
                return obj.DeleteForm(FormID);

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
      


    }




    public class Forms : IEnumerable<Form>
    {
        List<Form> infoList = new List<Form>();

        public Forms()
        {
            Data objData = new Data();
            DataTable dt;
            Form objInfo;

            //infoList = new ArrayList();

            dt = objData.GetFormsAllActive();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Form(dt.Rows[i]);
                    if (objInfo.FormsExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public Forms(string SearchCriteria)
        {
            Data objData = new Data();
            DataTable dt;
            Form objInfo;

            //infoList = new ArrayList();

            dt = objData.SearchForms(SearchCriteria);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Form(dt.Rows[i]);
                    if (objInfo.FormsExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public void Add(Form Info)
        {
            infoList.Add(Info);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<Form> IEnumerable<Form>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }








}
