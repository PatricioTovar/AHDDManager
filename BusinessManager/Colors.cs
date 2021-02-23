using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class Color
    {
        private int iColorID;
        private string strColorName;
        private string strTextColor;
        private Boolean blnColorExists;

       // private ClassError objError;


        public void initialize()
        {
            iColorID = 0;
            strColorName = string.Empty;
            strTextColor = string.Empty;

            blnColorExists = false;

           // objError = new ClassError();
        }


        public Color()
        {
            initialize();
        }


        public Color(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnColorExists = true;
            }
            catch (Exception ex)
            {
                blnColorExists = false;
            }
        }

        //public Color(int ColorID)
        //{
        //    Data obj = new Data();
        //    DataTable dt;
        //    try
        //    {
        //        initialize();

        //        //dt = obj.(ColorID)

        //        if (dt != null && dt.Rows.Count > 0)
        //        {

        //            Load(dt.Rows[0]);
        //            blnColorExists = true;
        //        }
        //        else
        //        {
        //            blnColorExists = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        blnColorExists = false;
        //    }
        //}



        public void Load(DataRow dr)
        {
            try
            {
                iColorID = Convert.ToInt32(dr["ColorID"] == Convert.DBNull ? 0 : dr["ColorID"]);
                strColorName = Convert.ToString(dr["ColorName"] == Convert.DBNull ? string.Empty : dr["ColorName"]);
                strTextColor = Convert.ToString(dr["TextColor"] == Convert.DBNull ? string.Empty : dr["TextColor"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int ColorID
        {
            get { return iColorID; }
            set { iColorID = value; }
        }
        public string ColorName
        {
            get { return strColorName; }
            set { strColorName = value; }
        }
        public string TextColor
        {
            get { return strTextColor; }
            set { strTextColor = value; }
        }
        public Boolean ColorsExists
        {
            get { return blnColorExists; }
            set { blnColorExists = value; }
        }

        //public ClassError ErrorOccurred
        //{
        //    get { return objError; }
        //}



        /*
        public Boolean Update() 
        { 
            Data obj = new Data(); 
            int iRet = 0;

            try
            { 
             iRet = obj.(this);

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
                General.WriteToErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.UnderlyingSystemType.ToString, System.Reflection.MethodBase.GetCurrentMethod.Name, ex.Message)

                return false;
            } 
            finally
            { 
        ColorID= iRet;
            }

        }

        */


        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(ColorID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }



    public class Colors : IEnumerable<Color>
    {
        List<Color> infoList = new List<Color>();

        public Colors()
        {
            infoList = new List<Color>();
        }

        public List<Color> GetAvailableColors()
        {
            Data objData = new Data();
            DataTable dt;
            Color objInfo;

            dt = objData.GetColorsAvailable();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Color(dt.Rows[i]);
                    if (objInfo.ColorsExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

            return infoList;
        }
      
        public void Add(Color Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Color> IEnumerable<Color>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }



}
