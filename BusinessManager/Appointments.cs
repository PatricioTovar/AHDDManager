using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{

    public class Appointment
    {
        private int iAppointmentID;
        private int iBusinessID;
        private DateTime dtmStartDate;
        private DateTime dtmEndDate;
        private string strAppointmentName;
        private int iAssignedTo;
        private Boolean blnActive;
        private string strDescription;
        private string strBackGroundColor;
        private string strTextColor;

        private DateTime dtmCreatedDate;
        private int iCreatedBy;
        private string strCreatedByName;


        private Boolean blnAppointmentsExist;

        //private ClassError objError;


        public void initialize()
        {
            iAppointmentID = 0;
            iBusinessID = 0;
            dtmStartDate = DateTime.MinValue;
            dtmEndDate = DateTime.MinValue;
            strAppointmentName = string.Empty;
            strBackGroundColor = string.Empty;
            strTextColor = string.Empty;
            strDescription = string.Empty;
            dtmCreatedDate = DateTime.MinValue;
            iCreatedBy = 0;
            strCreatedByName = string.Empty;

            iAssignedTo = 0;
            blnActive = false;

            blnAppointmentsExist = false;

            //objError = new ClassError();
        }


        public Appointment()
        {
            initialize();
        }


        public Appointment(DataRow dr)
        {
            try
            {
                initialize();
                Load(dr);
                blnAppointmentsExist = true;
            }
            catch (Exception ex)
            {
                blnAppointmentsExist = false;
            }
        }

        public Appointment(int AppointmentID)
        {
            Data obj = new Data();
            DataTable dt;
            try
            {
                initialize();

                dt = obj.GetAppointmentByID(AppointmentID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Load(dt.Rows[0]);
                    blnAppointmentsExist = true;
                }
                else
                {
                    blnAppointmentsExist = false;
                }
            }
            catch (Exception ex)
            {
                blnAppointmentsExist = false;
            }
        }



        public void Load(DataRow dr)
        {
            try
            {
                iAppointmentID = Convert.ToInt32(dr["AppointmentID"] == Convert.DBNull ? 0 : dr["AppointmentID"]);
                iBusinessID = Convert.ToInt32(dr["BusinessID"] == Convert.DBNull ? 0 : dr["BusinessID"]);
                dtmStartDate = Convert.ToDateTime(dr["StartDate"] == Convert.DBNull ? DateTime.MinValue : dr["StartDate"]);
                dtmEndDate = Convert.ToDateTime(dr["EndDate"] == Convert.DBNull ? DateTime.MinValue : dr["EndDate"]);
                strAppointmentName = Convert.ToString(dr["AppointmentName"] == Convert.DBNull ? string.Empty : dr["AppointmentName"]);
                strDescription = Convert.ToString(dr["Description"] == Convert.DBNull ? string.Empty : dr["Description"]);

                dtmCreatedDate = Convert.ToDateTime(dr["CreatedDate"] == Convert.DBNull ? DateTime.MinValue : dr["CreatedDate"]);
                iCreatedBy = Convert.ToInt16(dr["CreatedBy"] == Convert.DBNull ? 0 : dr["CreatedBy"]);
                strCreatedByName = Convert.ToString(dr["CreatedByName"] == Convert.DBNull ? string.Empty : dr["CreatedByName"]);

                strBackGroundColor = Convert.ToString(dr["BackgroundColor"] == Convert.DBNull ? string.Empty : dr["BackGroundColor"]);
                strTextColor = Convert.ToString(dr["TextColor"] == Convert.DBNull ? string.Empty : dr["TextColor"]);
                iAssignedTo = Convert.ToInt32(dr["AssignedTo"] == Convert.DBNull ? 0 : dr["AssignedTo"]);
                blnActive = Convert.ToBoolean(dr["Active"] == Convert.DBNull ? false : dr["Active"]);

                TimeSpan varTime = dtmEndDate - dtmStartDate;
                double fractionalMinutes = varTime.TotalMinutes;
                int wholeMinutes = (int)fractionalMinutes;

                if (wholeMinutes > 1410)
                { AllDay = true; }
                else
                { AllDay = false; }
            }
            catch (Exception ex)
            {
                //objError.ClassName = this.GetType().ToString();
                //objError.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //objError.ErrorOccurred = true;
                //objError.ErrorMsg = ex.Message;
            }
        }

        public int AppointmentID
        {
            get { return iAppointmentID; }
            set { iAppointmentID = value; }
        }
        public int BusinessID
        {
            get { return iBusinessID; }
            set { iBusinessID = value; }
        }
        public DateTime StartDate
        {
            get { return dtmStartDate; }
            set { dtmStartDate = value; }
        }
        public string StartDateString
        {
            get { return dtmStartDate.ToString(); }
            set { dtmStartDate = Convert.ToDateTime(value); }
        }
        public DateTime EndDate
        {
            get { return dtmEndDate; }
            set { dtmEndDate = value; }
        }
        public string EndDateString
        {
            get { return dtmEndDate.ToString(); }
            set { dtmEndDate = Convert.ToDateTime(value); }
        }
        public string AppointmentName
        {
            get { return strAppointmentName; }
            set { strAppointmentName = value; }
        }
        public string BackGroundColor
        {
            get { return strBackGroundColor; }
            set { strBackGroundColor = value; }
        }
        public string TextColor
        {
            get { return strTextColor; }
            set { strTextColor = value; }
        }

        public int AssignedTo
        {
            get { return iAssignedTo; }
            set { iAssignedTo = value; }
        }
        public Boolean Active
        {
            get { return blnActive; }
            set { blnActive = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        public int CreatedBy
        {
            get { return iCreatedBy; }
            set { iCreatedBy = value; }
        }

        public string CreatedByName
        {
            get { return strCreatedByName; }
            set { strCreatedByName = value; }
        }

        public Boolean AllDay { get; private set; }

        public Boolean AppointmentsExist
        {
            get { return blnAppointmentsExist; }
            set { blnAppointmentsExist = value; }
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
                iRet = obj.UpdateAppointment(this);

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
                Logging.LogEvent("Event to Add Failed: " + ex.Message);
                return false;
            }
            finally
            {
                AppointmentID = iRet;
            }

        }


        public Boolean Delete(int AppointmentID)
        {
            Data obj = new Data();

            try
            {
                return obj.DeleteAppointment(AppointmentID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Boolean UpdateTimes(int AppointmentID, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                AHDDManagerClass.Data objD = new Data();

                return objD.UpdateAppointmentTimes(AppointmentID, StartDate, EndDate);
            }
            catch (Exception ex)
            {
                Logging.LogEvent("Event Update Failed: " + ex.Message);
                return false;
            }
        }


    }





    public class Appointments : IEnumerable<Appointment>
    {
        List<Appointment> infoList = new List<Appointment>();

        public Appointments()
        {
            infoList = new List<Appointment>();
        }


        public Appointments(int Month, int Year)
        {
            Data objData = new Data();
            DataTable dt;
            Appointment objInfo;

            dt = objData.GetAppointmentsByMonthYear(Month, Year);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Appointment(dt.Rows[i]);
                    if (objInfo.AppointmentsExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }

        public Appointments(DateTime StartDate, DateTime EndDate)
        {
            Data objData = new Data();
            DataTable dt;
            Appointment objInfo;

            dt = objData.GetAppointmentsByDateRange(StartDate, EndDate);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objInfo = new Appointment(dt.Rows[i]);
                    if (objInfo.AppointmentsExist)
                    {
                        infoList.Add(objInfo);
                    }
                }
            }

        }


        public void Add(Appointment Info)
        {
            infoList.Add(Info);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }

        IEnumerator<Appointment> IEnumerable<Appointment>.GetEnumerator()
        {
            return infoList.GetEnumerator();
        }
    }






}
