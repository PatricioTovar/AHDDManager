using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AHDDManager.Models
{
    public class Logging
    {

        public static void LogEvent(string Message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/logs/log.txt"), true))
                {
                    TimeZoneInfo targetZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                    DateTime TodaytDT = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, targetZone);

                    writer.WriteLine(TodaytDT + "|" + Message);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static void LogClockIn(string Message, string Username)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/logs/" + Username + "-ClockIns.txt"), true))
                {
                    TimeZoneInfo targetZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                    DateTime TodaytDT = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, targetZone);

                    writer.WriteLine(TodaytDT + "|" + Message);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}