using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{


    public class ManhiemPreSale
    {
        private int iPreSaleID;
        private Boolean blnSelected;
        private DateTime dtmPreSaleDate;
        private string strLocation;
        private int iLane;
        private int iRun;
        private int iYear;
        private int iYearSearchStart;
        private int iYearSearchEnd;
        private string strMake;
        private string strModel;
        private string strCondition;
        private string strEngine;
        private string strTranny;
        private string strTopType;
        private int iOdometer;
        private string strColor;
        private string strVin;
        private string strLow;
        private string strAverage;
        private string strHigh;
        private Boolean blnManhiemPreSaleExists;

        //private ClassError objError;


        public void initialize()
        {
            iPreSaleID = 0;
            blnSelected = false;
            dtmPreSaleDate = DateTime.MinValue;
            strLocation = string.Empty;
            iLane = 0;
            iRun = 0;
            iYear = 0;
            iYearSearchStart = 0;
            iYearSearchEnd = 0;
            strMake = string.Empty;
            strModel = string.Empty;
            strCondition = string.Empty;
            strEngine = string.Empty;
            strTranny = string.Empty;
            strTopType = string.Empty;
            iOdometer = 0;
            strColor = string.Empty;
            strVin = string.Empty;
            strLow = string.Empty;
            strAverage = string.Empty;
            strHigh = string.Empty;

            blnManhiemPreSaleExists = false;

            //objError = new ClassError();
        }


        public ManhiemPreSale()
        {
            initialize();
        }


        public ManhiemPreSale(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnManhiemPreSaleExists = true;
            }
            catch (Exception ex)
            {
                blnManhiemPreSaleExists = false;
            }
        }

        public ManhiemPreSale(int PreSaleID)
        {
            //Data obj = new Data();
            //DataTable dt;
            //try
            //{
            //    initialize();

            //    //dt = obj.(PreSaleID)

            //    if (dt != null && dt.Rows.Count > 0)
            //    {

            //        Load(dt.Rows[0]);
            //        blnManhiemPreSaleExists = true;
            //    }
            //    else
            //    {
            //        blnManhiemPreSaleExists = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    blnManhiemPreSaleExists = false;
            //}
        }



        public void Load(DataRow dr)
        {
            try
            {
                iPreSaleID = Convert.ToInt32(dr["PreSaleID"] == Convert.DBNull ? 0 : dr["PreSaleID"]);
                blnSelected = Convert.ToBoolean(dr["selected"]);
                dtmPreSaleDate = Convert.ToDateTime(dr["PreSaleDate"] == Convert.DBNull ? DateTime.MinValue : dr["PreSaleDate"]);
                strLocation = Convert.ToString(dr["Location"] == Convert.DBNull ? string.Empty : dr["Location"]);
                iLane = Convert.ToInt16(dr["Lane"] == Convert.DBNull ? 0 : dr["Lane"]);
                iRun = Convert.ToInt16(dr["Run"] == Convert.DBNull ? 0 : dr["Run"]);
                iYear = Convert.ToInt16(dr["Year"] == Convert.DBNull ? 0 : dr["Year"]);
                strMake = Convert.ToString(dr["Make"] == Convert.DBNull ? string.Empty : dr["Make"]);
                strModel = Convert.ToString(dr["Model"] == Convert.DBNull ? string.Empty : dr["Model"]);
                strCondition = Convert.ToString(dr["Condition"] == Convert.DBNull ? string.Empty : dr["Condition"]);
                strEngine = Convert.ToString(dr["Engine"] == Convert.DBNull ? string.Empty : dr["Engine"]);
                strTranny = Convert.ToString(dr["Tranny"] == Convert.DBNull ? string.Empty : dr["Tranny"]);
                strTopType = Convert.ToString(dr["TopType"] == Convert.DBNull ? string.Empty : dr["TopType"]);
                iOdometer = Convert.ToInt32(dr["Odometer"] == Convert.DBNull ? 0 : dr["Odometer"]);
                strColor = Convert.ToString(dr["Color"] == Convert.DBNull ? string.Empty : dr["Color"]);
                strVin = Convert.ToString(dr["Vin"] == Convert.DBNull ? string.Empty : dr["Vin"]);

                strLow = Convert.ToString(dr["Low"] == Convert.DBNull ? string.Empty : dr["Low"]);
                strAverage = Convert.ToString(dr["Average"] == Convert.DBNull ? string.Empty : dr["Average"]);
                strHigh = Convert.ToString(dr["High"] == Convert.DBNull ? string.Empty : dr["High"]);
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int PreSaleID
        {
            get { return iPreSaleID; }
            set { iPreSaleID = value; }
        }
        public Boolean Selected
        {
            get { return blnSelected; }
            set { blnSelected = value; }
        }
        public DateTime PreSaleDate
        {
            get { return dtmPreSaleDate; }
            set { dtmPreSaleDate = value; }
        }
        public string PreSaleDateString
        {
            get { return dtmPreSaleDate.ToShortDateString(); }
        }
        public string Location
        {
            get { return strLocation; }
            set { strLocation = value; }
        }
        public int Lane
        {
            get { return iLane; }
            set { iLane = value; }
        }
        public int Run
        {
            get { return iRun; }
            set { iRun = value; }
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
        public string Condition
        {
            get { return strCondition; }
            set { strCondition = value; }
        }
        public string Engine
        {
            get { return strEngine; }
            set { strEngine = value; }
        }
        public string Tranny
        {
            get { return strTranny; }
            set { strTranny = value; }
        }
        public string TopType
        {
            get { return strTopType; }
            set { strTopType = value; }
        }
        public int Odometer
        {
            get { return iOdometer; }
            set { iOdometer = value; }
        }
        public string Color
        {
            get { return strColor; }
            set { strColor = value; }
        }
        public string Vin
        {
            get { return strVin; }
            set { strVin = value; }
        }

        public string Low
        {
            get { return strLow == string.Empty ? "---" : strLow; }
            set { strLow = value; }
        }
        public string Average
        {
            get { return strAverage == string.Empty ? "---" : strAverage; }
            set { strAverage = value; }
        }
        public string High
        {
            get { return strHigh == string.Empty ? "---" : strHigh; }
            set { strLow = strHigh; }
        }

        public Boolean ManhiemPreSaleExists
        {
            get { return blnManhiemPreSaleExists; }
            set { blnManhiemPreSaleExists = value; }
        }

        //public ClassError ErrorOccurred
        //{
        //    get { return objError; }
        //}



        public void InsertSelected(int PresaleID, string Low, string Average, string High)
        {
            Data obj = new Data();
            obj.Man_Pre_InsertSelected(PresaleID, Low, Average, High);
        }

        public void DeleteSelected(int PresaleID)
        {
            Data obj = new Data();
            obj.Man_Pre_DeleteSelected(PresaleID);
        }
        public void DeleteSelectedALL()
        {
            Data obj = new Data();
            obj.Man_Pre_DeleteSelectedALL();
        }


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
        PreSaleID= iRet;
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
                  return obj.(PreSaleID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }







    public class ManhiemPreSales : IEnumerable<ManhiemPreSale>
    {
        List<ManhiemPreSale> infoList = new List<ManhiemPreSale>();
        public ManhiemPreSales()
        {
            infoList = new List<ManhiemPreSale>();
        }


        public ManhiemPreSales(ManhiemPreSale PreSale)
        {
            Data objData = new Data();
            DataTable dt;
            ManhiemPreSale objInfo;

            //infoList = new ArrayList();

            dt = objData.SearchManhiemPresale(PreSale);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new ManhiemPreSale(dt.Rows[i]);
                    if (objInfo.ManhiemPreSaleExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }



        public List<string> GetPresaleLocationsAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetLocationsALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }

        public List<string> GetPresaleDatesAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetSaleDatesALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(Convert.ToDateTime(dt.Rows[i][0]).ToShortDateString());
                }
            }

            return objInfo;
        }

        public List<string> GetPresaleMakesAll()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetMakesAll();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }


        public List<string> GetPresaleYearsALL()
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetYearsALL();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }



        public List<string> GetPrePresaleRunsByLocDate(string Location, DateTime PresaleDate)
        {
            Data objData = new Data();
            DataTable dt;
            List<string> objInfo = new List<string>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetRunsByLocDate(Location, PresaleDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo.Add(dt.Rows[i][0].ToString());
                }
            }

            return objInfo;
        }


        public List<ManhiemPreSale> GetPreSalesSelected()
        {
            Data objData = new Data();
            DataTable dt;
            ManhiemPreSale objPS;
            List<ManhiemPreSale> objInfo = new List<ManhiemPreSale>();

            //infoList = new ArrayList();

            dt = objData.Man_Pre_GetSelected();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPS = new ManhiemPreSale(dt.Rows[i]);

                    if (objPS.ManhiemPreSaleExists)
                    {
                        objInfo.Add(objPS);
                    }
                }
            }

            return objInfo;
        }


        public void Add(ManhiemPreSale Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<ManhiemPreSale> IEnumerable<ManhiemPreSale>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }





}
