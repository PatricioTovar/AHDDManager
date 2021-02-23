using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class ManhiemPostSale
    {
        private int iPostSaleID;
        private string strLocation;
        private DateTime dtmPostSaleDate;
        private int iYear;
        private int iYearSearchStart;
        private int iYearSearchEnd;
        private string strMake;
        private string strModel;
        private string strSubSeries;
        private string strColor;
        private string strDoors;
        private int iCylinder;
        private string strFuel;
        private string strTranny;
        private string strFourByFour;
        private string strEW;
        private string strRadio;
        private string strTopType;
        private string strIntType;
        private int iOdometer;
        private int iPrice;
        private Boolean blnManhiemPostSaleExists;

        //private ClassError objError;


        public void initialize()
        {
            iPostSaleID = 0;
            strLocation = string.Empty;
            dtmPostSaleDate = DateTime.MinValue;
            iYear = 0;
            iYearSearchStart = 0;
            iYearSearchEnd = 0;
            strMake = string.Empty;
            strModel = string.Empty;
            strSubSeries = string.Empty;
            strColor = string.Empty;
            strDoors = string.Empty;
            iCylinder = 0;
            strFuel = string.Empty;
            strTranny = string.Empty;
            strFourByFour = string.Empty;
            strEW = string.Empty;
            strRadio = string.Empty;
            strTopType = string.Empty;
            strIntType = string.Empty;
            iOdometer = 0;
            iPrice = 0;

            blnManhiemPostSaleExists = false;

            //objError = new ClassError();
        }


        public ManhiemPostSale()
        {
            initialize();
        }


        public ManhiemPostSale(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnManhiemPostSaleExists = true;
            }
            catch (Exception ex)
            {
                blnManhiemPostSaleExists = false;
            }
        }

        public ManhiemPostSale(int PostSaleID)
        {
            //Data obj = new Data();
            //DataTable dt;
            //try
            //{
            //    initialize();

            //    //dt = obj.(PostSaleID)

            //    if (dt != null && dt.Rows.Count > 0)
            //    {

            //        Load(dt.Rows[0]);
            //        blnManhiemPostSaleExists = true;
            //    }
            //    else
            //    {
            //        blnManhiemPostSaleExists = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    blnManhiemPostSaleExists = false;
            //}
        }



        public void Load(DataRow dr)
        {
            try
            {
                iPostSaleID = Convert.ToInt32(dr["PostSaleID"] == Convert.DBNull ? 0 : dr["PostSaleID"]);
                strLocation = Convert.ToString(dr["Location"] == Convert.DBNull ? string.Empty : dr["Location"]);
                dtmPostSaleDate = Convert.ToDateTime(dr["PostSaleDate"] == Convert.DBNull ? DateTime.MinValue : dr["PostSaleDate"]);
                iYear = Convert.ToInt32(dr["Year"] == Convert.DBNull ? 0 : dr["Year"]);
                strMake = Convert.ToString(dr["Make"] == Convert.DBNull ? string.Empty : dr["Make"]);
                strModel = Convert.ToString(dr["Model"] == Convert.DBNull ? string.Empty : dr["Model"]);
                strSubSeries = Convert.ToString(dr["SubSeries"] == Convert.DBNull ? string.Empty : dr["SubSeries"]);
                strColor = Convert.ToString(dr["Color"] == Convert.DBNull ? string.Empty : dr["Color"]);
                strDoors = Convert.ToString(dr["Doors"] == Convert.DBNull ? string.Empty : dr["Doors"]);
                iCylinder = Convert.ToInt16(dr["Cylinder"] == Convert.DBNull ? 0 : dr["Cylinder"]);
                strFuel = Convert.ToString(dr["Fuel"] == Convert.DBNull ? string.Empty : dr["Fuel"]);
                strTranny = Convert.ToString(dr["Tranny"] == Convert.DBNull ? string.Empty : dr["Tranny"]);
                strFourByFour = Convert.ToString(dr["FourByFour"] == Convert.DBNull ? string.Empty : dr["FourByFour"]);
                strEW = Convert.ToString(dr["EW"] == Convert.DBNull ? string.Empty : dr["EW"]);
                strRadio = Convert.ToString(dr["Radio"] == Convert.DBNull ? string.Empty : dr["Radio"]);
                strTopType = Convert.ToString(dr["TopType"] == Convert.DBNull ? string.Empty : dr["TopType"]);
                strIntType = Convert.ToString(dr["IntType"] == Convert.DBNull ? string.Empty : dr["IntType"]);
                iOdometer = Convert.ToInt32(dr["Odometer"] == Convert.DBNull ? 0 : dr["Odometer"]);
                iPrice = Convert.ToInt32(dr["Price"] == Convert.DBNull ? 0 : dr["Price"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int PostSaleID
        {
            get { return iPostSaleID; }
            set { iPostSaleID = value; }
        }
        public string Location
        {
            get { return strLocation; }
            set { strLocation = value; }
        }
        public DateTime PostSaleDate
        {
            get { return dtmPostSaleDate; }
            set { dtmPostSaleDate = value; }
        }
        public string PostSaleDateString
        {
            get { return dtmPostSaleDate.ToShortDateString(); }
        }
        public int Year
        {
            get { return iYear; }
            set { iYear = value; }
        }
        public int YearSearchStart
        {
            get { return iYearSearchStart; }
            set { iYearSearchStart = value; }
        }
        public int YearSearchEnd
        {
            get { return iYearSearchEnd; }
            set { iYearSearchEnd = value; }
        }
        public string Make
        {
            get { return strMake; }
            set { strMake = value; }
        }
        public string Model
        {
            get { return strModel; }
            set { strModel = value; }
        }
        public string SubSeries
        {
            get { return strSubSeries; }
            set { strSubSeries = value; }
        }
        public string Color
        {
            get { return strColor; }
            set { strColor = value; }
        }
        public string Doors
        {
            get { return strDoors; }
            set { strDoors = value; }
        }
        public int Cylinder
        {
            get { return iCylinder; }
            set { iCylinder = value; }
        }
        public string Fuel
        {
            get { return strFuel; }
            set { strFuel = value; }
        }
        public string Tranny
        {
            get { return strTranny; }
            set { strTranny = value; }
        }
        public string FourByFour
        {
            get { return strFourByFour; }
            set { strFourByFour = value; }
        }
        public string EW
        {
            get { return strEW; }
            set { strEW = value; }
        }
        public string Radio
        {
            get { return strRadio; }
            set { strRadio = value; }
        }
        public string TopType
        {
            get { return strTopType; }
            set { strTopType = value; }
        }
        public string IntType
        {
            get { return strIntType; }
            set { strIntType = value; }
        }
        public int Odometer
        {
            get { return iOdometer; }
            set { iOdometer = value; }
        }
        public string OdometerFormatted
        {
            get { return iOdometer.ToString("N0"); }
        }

        public int Price
        {
            get { return iPrice; }
            set { iPrice = value; }
        }
        public string PriceFormatted
        {
            get { return iPrice.ToString("c0"); }
        }

        public Boolean ManhiemPostSaleExists
        {
            get { return blnManhiemPostSaleExists; }
            set { blnManhiemPostSaleExists = value; }
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
        PostSaleID= iRet;
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
                  return obj.(PostSaleID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }






    public class ManhiemPostSales : IEnumerable<ManhiemPostSale>
    {
        List<ManhiemPostSale> infoList = new List<ManhiemPostSale>();

        public ManhiemPostSales()
        {
            infoList = new List<ManhiemPostSale>();
        }

        public ManhiemPostSales(ManhiemPostSale PostSale)
        {
            Data objData = new Data();
            DataTable dt;
            ManhiemPostSale objInfo;

            //infoList = new ArrayList();

            dt = objData.SearchManhiemPostsale(PostSale);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new ManhiemPostSale(dt.Rows[i]);
                    if (objInfo.ManhiemPostSaleExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }



        public List<string> GetPostsaleLocationsAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetLocationsALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }

        public List<string> GetPostsaleDatesAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetSaleDatesALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(Convert.ToDateTime(dt.Rows[i][0]).ToShortDateString());
                }
            }

            return objInfo;
        }

        public List<string> GetPostsaleMakesAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetMakesAll();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }



        public List<ManhiemPostSale> GetPostsalesHighOdo()
        {
            Data objData = new Data();
            DataTable dt;
            List<ManhiemPostSale> objInfo = new List<ManhiemPostSale>();
            ManhiemPostSale objPost;
            //infoList = new ArrayList();

            dt = objData.Man_Post_GetHighMileage();
            
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPost = new ManhiemPostSale(dt.Rows[i]);                    
                    objInfo.Add(objPost);
                }
            }

            return objInfo;
        }


        public List<string> GetPostsaleYearsALL()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetYearsALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }


        public List<string> GetPostSubseriesByMakeModel(string Make, string Model)
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetSubseriesByMakeModel(Make, Model);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }


        public List<ManhiemPostSale> GetSalesByOdometer(int Odometer)
        {
            Data objData = new Data();
            DataTable dt;
            ManhiemPostSale objPS = new ManhiemPostSale();
            List<ManhiemPostSale> objInfo = new List<ManhiemPostSale>();

            //infoList = new ArrayList();

            dt = objData.Man_Post_GetSalesByOdometer(Odometer);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPS = new ManhiemPostSale(dt.Rows[i]);
                    if (objPS.ManhiemPostSaleExists)
                    {
                        objInfo.Add(objPS);
                    }
                }
            }

            return objInfo;
        }

        public void Add(ManhiemPostSale Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<ManhiemPostSale> IEnumerable<ManhiemPostSale>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }












}
