using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class Associate
    {
        private int iAssociateID;
        private int iBusinessID;
        private string strFirstName;
        private string strLastName;
        private string strAddress;
        private string strCity;
        private string strState;
        private string strZip;
        private string strPhone;
        private string strAltPhone;
        private string strEmail;
        private string strUserName;
        private string strPassword;
        private DateTime dtmDateCreated;
        private Boolean blnActive;
        private string strBackgroundColor;
        private string strTextColor;
        private Boolean blnIsAdmin;
        private Boolean blnClockedIn;
        private Boolean blnTrackHours;
        private Boolean blnAssociatesExist;

        //private ClassError objError;


        public void initialize()
        {
            iAssociateID = 0;
            iBusinessID = 0;
            strFirstName = string.Empty;
            strLastName = string.Empty;
            strAddress = string.Empty;
            strCity = string.Empty;
            strState = string.Empty;
            strZip = string.Empty;
            strPhone = string.Empty;
            strAltPhone = string.Empty;
            strEmail = string.Empty;
            strUserName = string.Empty;
            strPassword = string.Empty;
            dtmDateCreated = DateTime.MinValue;
            blnActive = false;
            strBackgroundColor = string.Empty;
            strTextColor = string.Empty;
            blnIsAdmin = false;
            blnClockedIn = false;
            blnTrackHours = false;

            blnAssociatesExist = false;

            //objError = new ClassError();
        }


        public Associate()
        {
            initialize();
        }


        public Associate(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnAssociatesExist = true;
            }
            catch (Exception ex)
            {
                blnAssociatesExist = false;
            }
        }

        public Associate(int AssociateID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetAssociateByID(AssociateID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Load(dt.Rows[0]);
                    blnAssociatesExist = true;
                }
                else
                {
                    blnAssociatesExist = false;
                }
            }
            catch (Exception ex)
            {
                blnAssociatesExist = false;
            }
        }

        public Associate(string UserName, string Password)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.LoginAssociate(UserName, Password);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Load(dt.Rows[0]);
                    blnAssociatesExist = true;

                    //*********************************************************************
                    //DO CLOCK IN CHECK HERE
                    //*********************************************************************
                    if (this.TrackHours)
                    { // only add records to clockin history table if associate track hours is true
                        ClockIn();
                    }
                }
                else
                {
                    blnAssociatesExist = false;
                }
            }
            catch (Exception ex)
            {
                blnAssociatesExist = false;
            }
        }

        public void Load(DataRow dr)
        {
            try
            {
                iAssociateID = Convert.ToInt32(dr["AssociateID"] == Convert.DBNull ? 0 : dr["AssociateID"]);
                iBusinessID = Convert.ToInt32(dr["BusinessID"] == Convert.DBNull ? 0 : dr["BusinessID"]);
                strFirstName = Convert.ToString(dr["FirstName"] == Convert.DBNull ? string.Empty : dr["FirstName"]);
                strLastName = Convert.ToString(dr["LastName"] == Convert.DBNull ? string.Empty : dr["LastName"]);
                strAddress = Convert.ToString(dr["Address"] == Convert.DBNull ? string.Empty : dr["Address"]);
                strCity = Convert.ToString(dr["City"] == Convert.DBNull ? string.Empty : dr["City"]);
                strState = Convert.ToString(dr["State"] == Convert.DBNull ? string.Empty : dr["State"]);
                strZip = Convert.ToString(dr["Zip"] == Convert.DBNull ? string.Empty : dr["Zip"]);
                strPhone = Convert.ToString(dr["Phone"] == Convert.DBNull ? string.Empty : dr["Phone"]);
                strAltPhone = Convert.ToString(dr["AltPhone"] == Convert.DBNull ? string.Empty : dr["AltPhone"]);
                strEmail = Convert.ToString(dr["Email"] == Convert.DBNull ? string.Empty : dr["Email"]);
                strUserName = Convert.ToString(dr["UserName"] == Convert.DBNull ? string.Empty : dr["UserName"]);
                strPassword = Convert.ToString(dr["Password"] == Convert.DBNull ? string.Empty : dr["Password"]);
                dtmDateCreated = Convert.ToDateTime(dr["DateCreated"] == Convert.DBNull ? DateTime.MinValue : dr["DateCreated"]);
                blnActive = Convert.ToBoolean(dr["Active"] == Convert.DBNull ? false : dr["Active"]);
                strBackgroundColor = Convert.ToString(dr["BackgroundColor"] == Convert.DBNull ? string.Empty : dr["BackgroundColor"]);
                strTextColor = Convert.ToString(dr["TextColor"] == Convert.DBNull ? string.Empty : dr["TextColor"]);
                blnIsAdmin = Convert.ToBoolean(dr["IsAdmin"] == Convert.DBNull ? false : dr["IsAdmin"]);
                blnClockedIn = Convert.ToBoolean(dr["ClockedIn"] == Convert.DBNull ? false : dr["ClockedIn"]);
                blnTrackHours = Convert.ToBoolean(dr["TrackHours"] == Convert.DBNull ? false : dr["TrackHours"]);

                this.AssociateBusiness = new Business(Convert.ToInt32(dr["BusinessID"]));

            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int AssociateID
        {
            get { return iAssociateID; }
            set { iAssociateID = value; }
        }
        public int BusinessID
        {
            get { return iBusinessID; }
            set { iBusinessID = value; }
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
        public string Phone
        {
            get { return strPhone; }
            set { strPhone = value; }
        }
        public string PhoneFormatted
        {
            get
            {
                try
                {
                    return strPhone.Insert(3, ".").Insert(7, ".");
                }
                catch
                {
                    return string.Empty;
                }
            }

        }
        public string AltPhone
        {
            get { return strAltPhone; }
            set { strAltPhone = value; }
        }
        public string AltPhoneFormatted
        {
            get
            {
                try
                {
                    return strAltPhone.Insert(3, ".").Insert(7, ".");
                }
                catch
                {
                    return string.Empty;
                }
            }

        }
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
        public DateTime DateCreated
        {
            get { return dtmDateCreated; }
            set { dtmDateCreated = value; }
        }
        public Boolean Active
        {
            get { return blnActive; }
            set { blnActive = value; }
        }
        public string BackgroundColor
        {
            get { return strBackgroundColor; }
            set { strBackgroundColor = value; }
        }
        public string TextColor
        {
            get { return strTextColor; }
            set { strTextColor = value; }
        }
        public Boolean AssociatesExist
        {
            get { return blnAssociatesExist; }
            set { blnAssociatesExist = value; }
        }
        public Boolean IsAdmin
        {
            get { return blnIsAdmin; }
            set { blnIsAdmin = value; }
        }
        public Boolean ClockedIn
        {
            get { return blnClockedIn; }
            set { blnClockedIn = value; }
        }
        public Boolean TrackHours
        {
            get { return blnTrackHours; }
            set { blnTrackHours = value; }
        }

        public Business AssociateBusiness { get; set; }

        //public ClassError ErrorOccurred
        //{
        //    get { return objError; }
        //}
        public void ChangeClockInStatus()
        {
            if (this.TrackHours)
            {
                if (blnClockedIn)
                {
                    ClockOut();
                }
                else
                {
                    ClockIn();
                }
            }
        }

        //the user just logged in. checking to see if they are clocked in. if 
        private void ClockIn()
        {
            AHDDManagerClass.AssociateClockInHistories ClockinHist = new AssociateClockInHistories();
            List<AHDDManagerClass.AssociateClockInHistory> objACHs = ClockinHist.GetAllClockinsUnfiltered(DateTime.Now.AddDays(-90).ToShortDateString(), DateTime.Now.ToShortDateString(), AssociateID);

            AHDDManagerClass.AssociateClockInHistory objACH = null;

            TimeZoneInfo targetZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime targeTodaytDT = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, targetZone);



            // regardless if first time for the day clocking in or returning log in, check to see if there is an open CIH, meaning they did not clock out, and close it
            // get yesterday's cihs
            //var today = objACHs.OrderByDescending(r => r.LoginDatetime).Where(t => t.LoginDatetime.ToShortDateString() == DateTime.Now.ToShortDateString()); // see if there are any today


            //if (today == null) // no records for today, now check yeaterday and earlier
            //{

            // ********************************************************************************************************
            // CHECK FOR PREVIOUS OPEN CIH.  IF FOUND, CLOSE IT OUT.
            // THIS CHECK IS DONE EVERTIME, JUST IN CASE

            // see if there are any CIH before today
            var lastNotToday = objACHs.OrderByDescending(r => r.LoginDatetime).Where(t => t.LoginDatetime.ToShortDateString() != DateTime.Now.ToShortDateString());


            if (lastNotToday.ToList().Count > 0 && lastNotToday.First().LogoutDatetime == DateTime.MinValue)
            {//if the lastest cih from yesterday does not have a log out it means they did not logout.
                var cih_yest = lastNotToday.First();

                //auto log yesterday's cih out
                cih_yest.LogoutDatetime = Convert.ToDateTime(cih_yest.LoginDatetime.ToShortDateString() + " 5:30:00 PM");
                cih_yest.Update();

            }
            //}

            // ********************************************************************************************************


            // ********************************************************************************************************
            // CHECK TODAY'S CIH
            
            //today's CIH
            var achs = objACHs.OrderByDescending(r => r.LoginDatetime).Where(t => t.LoginDatetime.ToShortDateString() == DateTime.Now.ToShortDateString());

            if (achs.Count() == 0)
            {// there are NO CIH entries for today

                //create a new CIH entry
                objACH = new AssociateClockInHistory();

                objACH.AssociateID = AssociateID;
                objACH.LoginDatetime = targeTodaytDT;
                objACH.IsLunch = false;

                objACH.Update();
            }
            else
            {// there are CIH event
             //get todays latest CIH entry
                var todayCIH = achs.First();

                //check to see if the last entry has a logout date
                if (todayCIH.LogoutDatetime != DateTime.MinValue)
                {//DOES have a logout date

                    //do lunch check and insert if needed

                    //check to see any today's CIH has a lunch
                    var lunch = achs.Where(w => w.IsLunch == true);

                    if (lunch.ToList().Count == 0)
                    {// there was no lunch CIH  today
                     //create a new CIH lunch entry
                        objACH = new AssociateClockInHistory();

                        objACH.AssociateID = AssociateID;
                        objACH.LoginDatetime = todayCIH.LogoutDatetime;
                        objACH.LogoutDatetime = targeTodaytDT;
                        objACH.IsLunch = true;

                        objACH.Update();
                    }

                    //create a new CIH entry
                    objACH = new AssociateClockInHistory();

                    objACH.AssociateID = AssociateID;
                    objACH.LoginDatetime = targeTodaytDT;
                    objACH.IsLunch = false;

                    objACH.Update();
                }
                else
                {
                    //this should not happen
                }
            }


            // are they clocked in? IF NO, THEN SET CLOCKED IN FIELD TO TRUE IN DB
            if (!blnClockedIn) // user is clocked OUT
            {
                blnClockedIn = true;
                Update();             
            }
        }


        private void ClockOut()
        {
            try
            {
                AHDDManagerClass.AssociateClockInHistories ClockinHist = new AssociateClockInHistories();
                List<AHDDManagerClass.AssociateClockInHistory> objACHs = ClockinHist.GetAllClockinsUnfiltered(DateTime.Now.AddDays(-1).ToShortDateString(), DateTime.Now.ToShortDateString(), AssociateID);


                TimeZoneInfo targetZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime targeTodaytDT = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, targetZone);


                var achs = objACHs.OrderByDescending(r => r.LoginDatetime).Where(t => t.LoginDatetime.ToShortDateString() == DateTime.Now.ToShortDateString());


                blnClockedIn = false; //clock in the associate automatically and update to fire the trigger
                Update();

                if (achs != null)
                {
                    var todayCIH = achs.First();

                    //check to see if the last entry has a logout date
                    if (todayCIH != null && todayCIH.LogoutDatetime == DateTime.MinValue)
                    {//DOES have a logout date

                        todayCIH.LogoutDatetime = targeTodaytDT;

                        todayCIH.Update();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




        public Boolean Update()
        {
            Data obj = new Data();
            int iRet = 0;

            try
            {
                iRet = obj.UpdateAssociate(this);

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
                AssociateID = iRet;
            }

        }



        /*
        public Boolean Delete()
        {
          Data obj = New Data();
          int iRet = 0;

          try
              {
                  return obj.(AssociateID)

              }
              catch (Exception ex)
              {
                  return false;
              }
        }
        */


    }



    public class Associates : IEnumerable<Associate>
    {
        List<Associate> infoList = new List<Associate>();

        public Associates()
        {
            infoList = new List<Associate>();
        }

        public Associates(int BusinessID, bool? Active = null)
        {
            Data objData = new Data();
            DataTable dt;
            Associate objInfo;

            dt = objData.GetAssociatesByBusinessID(BusinessID, Active);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Associate(dt.Rows[i]);
                    if (objInfo.AssociatesExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }


        public List<int> GetAssociateIdsWithHoursByDate(string StartDate, string EndDate)
        {
            List<int> ret = new List<int>();
            DataTable dt;
            Data objD = new Data();

            dt = objD.GetAssociateIdsWithHoursByDate(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ret.Add(Convert.ToInt16(dt.Rows[i]["AssociateID"]));
                }
            }

            return ret;
        }


        public void Add(Associate Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Associate> IEnumerable<Associate>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }


}
