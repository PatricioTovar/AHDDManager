using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AHDDManagerClass
{

    public class AssociateClockInHistory
    {
        private int iAssociateClockInHistoryID;
        private int iAssociateID;
        public string strFirstName;
        public string strLastName;
        private DateTime dtmLoginDatetime;
        private DateTime dtmLogoutDatetime;
        private Boolean blnIsLunch;
        private int iHoursWorked;
        private int iMinutesWorked;
        private Boolean blnAssociateClockInHistoryExists;

        //private ClassError objError;


        public void initialize()
        {
            iAssociateClockInHistoryID = 0;
            iAssociateID = 0;
            strFirstName = string.Empty;
            strLastName = string.Empty;
            dtmLoginDatetime = DateTime.MinValue;
            dtmLogoutDatetime = DateTime.MinValue;
            blnIsLunch = false;
            iHoursWorked = 0;
            iMinutesWorked = 0;

            blnAssociateClockInHistoryExists = false;

            //objError = new ClassError();
        }


        public AssociateClockInHistory()
        {
            initialize();
        }


        public AssociateClockInHistory(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnAssociateClockInHistoryExists = true;
            }
            catch (Exception ex)
            {
                blnAssociateClockInHistoryExists = false;
            }
        }

        public AssociateClockInHistory(int AssociateClockInHistoryID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetAsociateClockInHistoryByID(AssociateClockInHistoryID);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Load(dt.Rows[0]);
                    blnAssociateClockInHistoryExists = true;
                }
                else
                {
                    blnAssociateClockInHistoryExists = false;
                }
            }
            catch (Exception ex)
            {
                blnAssociateClockInHistoryExists = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                try
                {
                    iAssociateClockInHistoryID = Convert.ToInt32(dr["AssociateClockInHistoryID"] == Convert.DBNull ? 0 : dr["AssociateClockInHistoryID"]);
                }
                catch
                { }

                iAssociateID = Convert.ToInt32(dr["AssociateID"] == Convert.DBNull ? 0 : dr["AssociateID"]);

                try
                {
                    blnIsLunch = Convert.ToBoolean(dr["IsLunch"] == Convert.DBNull ? false : dr["IsLunch"]);
                }
                catch
                { }



                try
                {
                    strFirstName = Convert.ToString(dr["FirstName"] == Convert.DBNull ? 0 : dr["FirstName"]);
                    strLastName = Convert.ToString(dr["LastName"] == Convert.DBNull ? 0 : dr["LastName"]);
                }
                catch
                { }

                try
                {
                    dtmLoginDatetime = Convert.ToDateTime(dr["LoginDatetime"] == Convert.DBNull ? DateTime.MinValue : dr["LoginDatetime"]);
                    dtmLogoutDatetime = Convert.ToDateTime(dr["LogoutDatetime"] == Convert.DBNull ? DateTime.MinValue : dr["LogoutDatetime"]);
                }
                catch
                { }

                iHoursWorked = Convert.ToInt32(dr["HoursWorked"] == Convert.DBNull ? 0 : dr["HoursWorked"]);

                int iTempMin = Convert.ToInt32(dr["MinutesWorked"] == Convert.DBNull ? 0 : dr["MinutesWorked"]);
                int iHoursToAdd = iTempMin / 60;
                iHoursWorked += iHoursToAdd;

                iMinutesWorked = iTempMin % 60;


            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int AssociateClockInHistoryID
        {
            get { return iAssociateClockInHistoryID; }
            set { iAssociateClockInHistoryID = value; }
        }
        public int AssociateID
        {
            get { return iAssociateID; }
            set { iAssociateID = value; }
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
        public DateTime LoginDatetime
        {
            get { return dtmLoginDatetime; }
            set { dtmLoginDatetime = value; }
        }
        public string LoginDatetimeString
        {
            get { return dtmLoginDatetime.ToString(); }
        }
        

        public DateTime LogoutDatetime
        {
            get { return dtmLogoutDatetime; }
            set { dtmLogoutDatetime = value; }
        }
        public string LogoutDatetimeString
        {
            get { return dtmLogoutDatetime.ToString(); }
        }


        public Boolean IsLunch
        {
            get { return blnIsLunch; }
            set { blnIsLunch = value; }
        }
        public int HoursWorked
        {
            get { return iHoursWorked; }
            set { iHoursWorked = value; }
        }
        public int MinutesWorked
        {
            get { return iMinutesWorked; }
            set { iMinutesWorked = value; }
        }

        public Boolean AssociateClockInHistoryExists
        {
            get { return blnAssociateClockInHistoryExists; }
            set { blnAssociateClockInHistoryExists = value; }
        }


        //public void CheckClockins(int AssociateID)
        //{
        //    Data obj = new Data();

        //    try
        //    {
        //        obj.CheckClockIns(AssociateID, DateTime.Now);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}


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
                iRet = obj.UpdateAssociateClockInHistory(this);

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
                AssociateClockInHistoryID = iRet;
            }

        }




        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(AssociateClockInHistoryID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }




    public class AssociateClockInHistories : IEnumerable<AssociateClockInHistory>
    {
        List<AssociateClockInHistory> infoList = new List<AssociateClockInHistory>();

        public AssociateClockInHistories(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            AssociateClockInHistory objInfo;

            //infoList = new ArrayList();

            dt = objData.GetAssociatesAllClockInsByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new AssociateClockInHistory(dt.Rows[i]);
                    if (objInfo.AssociateClockInHistoryExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }
        }

        public AssociateClockInHistories(string StartDate, string EndDate, int AssociateID)
        {
            Data objData = new Data();
            DataTable dt;
            AssociateClockInHistory objInfo;

            //infoList = new ArrayList();

            dt = objData.GetAssociateClockInsByDateRange(StartDate, EndDate, AssociateID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new AssociateClockInHistory(dt.Rows[i]);
                    if (objInfo.AssociateClockInHistoryExists)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }
        }

        public AssociateClockInHistories()
        {
            infoList = new List<AssociateClockInHistory>();
        }


        public List<AssociateClockInHistory> GetAllClockinsUnfiltered(string StartDate, string EndDate, int AssociateID)
        {
            Data objData = new Data();
            DataTable dt;
            AssociateClockInHistory objInfo;

            List<AssociateClockInHistory> retList = new List<AssociateClockInHistory>();

            dt = objData.GetAssociateClockInsAllByDateRange(StartDate, EndDate, AssociateID);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new AssociateClockInHistory(dt.Rows[i]);
                    if (objInfo.AssociateClockInHistoryExists)
                    {
                        retList.Add(objInfo);
                    }
                }
            }

            return retList;

        }

        public void Add(AssociateClockInHistory Info)
        {
            infoList.Add(Info);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
        IEnumerator<AssociateClockInHistory> IEnumerable<AssociateClockInHistory>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }





    //create this to get accumulated hours over a date range for an assoc
    //call AssociateClockInHistories(DateTime StartDate, DateTime EndDate, int AssociateID) and do calculations
    //this will be used in "MY HOURS"
    //and possibly in admin assoc hours
    public class AssociateHoursWorked
    {
        private int iTotalHoursWorked;
        private int iTotalMinutesWorked;
        private int iTotalLunchMinutes;
        private AssociateClockInHistories objACHs;
        private string strAssociateName;
        private int iAssociateID;

        public AssociateHoursWorked(string StartDate, string EndDate, int AssociateID)
        {
            TimeSpan span;
            int minutes = 0;

            initialize();

            //StartDate = "4/1/2019";
            //EndDate = "4/6/2019";

            objACHs = new AssociateClockInHistories(StartDate, EndDate, AssociateID);

            foreach (AssociateClockInHistory item in objACHs)
            {
                strAssociateName = item.FirstName + " " + item.LastName;
                iAssociateID = item.AssociateID;

                if (!item.IsLunch)
                { // calculate work time
                    span = item.LogoutDatetime - item.LoginDatetime;

                    iTotalHoursWorked += Convert.ToInt16(Math.Floor(span.TotalMinutes / 60));

                    minutes = Convert.ToInt16(Math.Floor(span.TotalMinutes % 60));
                    iTotalMinutesWorked += minutes;

                    //Debug.WriteLine(iTotalHoursWorked.ToString() + " :: " + item.AssociateClockInHistoryID + ": " + span.Hours.ToString() + " - " + span.Minutes.ToString());
                }
            }

            var lunches = from x in objACHs.Where(t => t.IsLunch == true)
                          group x by x.LoginDatetime.Date into xy
                          select new
                          {
                              Day = xy.Key,
                              LunchDuration = xy.Sum(y => (y.MinutesWorked))

                              //LunchDuration = xy.Sum(y => (y.LogoutDatetime - y.LoginDatetime).Minutes)
                          };

            foreach (var group in lunches)
            {
                if (group.LunchDuration > 30)
                { iTotalLunchMinutes += 30; }
                else
                { iTotalLunchMinutes += group.LunchDuration; }
            }

            iTotalMinutesWorked += iTotalLunchMinutes;

            iTotalHoursWorked += Convert.ToInt16(iTotalMinutesWorked / 60);
            iTotalMinutesWorked = iTotalMinutesWorked % 60;


        }

        private void initialize()
        {
            iTotalHoursWorked = 0;
            iTotalMinutesWorked = 0;
            iTotalLunchMinutes = 0;
            strAssociateName = string.Empty;
            iAssociateID = 0;
        }

        public int AssociateID
        {
            get { return iAssociateID; }
        }

        public string AssociateName
        {
            get { return strAssociateName; }
        }

        public int TotalHoursWorked
        {
            get { return iTotalHoursWorked; }
        }

        public int TotalMinutesWorked
        {
            get { return iTotalMinutesWorked; }
        }

        public AssociateClockInHistories ClockInHistory
        {
            get { return objACHs; }
        }

        public string HoursWorkedString
        {
            get { return iTotalHoursWorked + "h " + iTotalMinutesWorked + "m"; }
        }

    }



    public class AssociatesHoursWorked //: IEnumerable<AssociateHoursWorked>
    {

        private int iTotalHoursWorked = 0;
        private int iTotalMinutesWorked = 0;

        List<AssociateHoursWorked> infoList = new List<AssociateHoursWorked>();

        public AssociatesHoursWorked(string StartDate, string EndDate)
        {
            Data objData = new Data();
            AssociateHoursWorked objInfo;
            Associates objA = new Associates();

            iTotalMinutesWorked = 0;

            List<int> AssocsWithHours = objA.GetAssociateIdsWithHoursByDate(StartDate, EndDate);

            foreach (int associd in AssocsWithHours)
            {
                objInfo = new AssociateHoursWorked(StartDate, EndDate, associd);

                iTotalMinutesWorked += (objInfo.TotalHoursWorked * 60) + objInfo.TotalMinutesWorked;

                infoList.Add(objInfo);
            }

            iTotalHoursWorked += Convert.ToInt16(iTotalMinutesWorked / 60);
            iTotalMinutesWorked = iTotalMinutesWorked % 60;

        }

        public AssociatesHoursWorked()
        {
            infoList = new List<AssociateHoursWorked>();
        }



        public List<AssociateHoursWorked> HoursWorked
        {
            get { return infoList; }
        }

        public string test
        { get { return "test"; } }

        public int TotalHoursWorked
        { get { return iTotalHoursWorked; } }

        public int TotalMinutesWorked
        { get { return iTotalMinutesWorked; } }

        public string TotalWorkTimeString
        { get { return iTotalHoursWorked + "h " + iTotalMinutesWorked + "m"; } }


        public void Add(AssociateHoursWorked Info)
        {
            infoList.Add(Info);
        }
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return infoList.GetEnumerator();
        //}
        //IEnumerator<AssociateHoursWorked> IEnumerable<AssociateHoursWorked>.GetEnumerator()
        //{
        //    return infoList.GetEnumerator();
        //}
    }





}
