using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Controllers
{
    public class ManhiemController : Controller
    {
        // GET: Manhiem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LaneRun()
        {
            AHDDManagerClass.ManhiemPreSales objPSs = new AHDDManagerClass.ManhiemPreSales();

            var dates = objPSs.GetPresaleDatesAll();

            var selectDateList = new List<SelectListItem>();

            foreach (var element in dates)
            {
                selectDateList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.SaleDates = selectDateList;




            var locations = objPSs.GetPresaleLocationsAll();

            var selectLocList = new List<SelectListItem>();

            foreach (var element in locations)
            {
                selectLocList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Locations = selectLocList;



            return View();
        }


        public ActionResult PresaleSearch()
        {
            AHDDManagerClass.ManhiemPreSales objPSs = new AHDDManagerClass.ManhiemPreSales();

            var dates = objPSs.GetPresaleDatesAll();

            var selectDateList = new List<SelectListItem>();

            foreach (var element in dates)
            {
                selectDateList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.SaleDates = selectDateList;




            var locations = objPSs.GetPresaleLocationsAll();

            var selectLocList = new List<SelectListItem>();

            foreach (var element in locations)
            {
                selectLocList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Locations = selectLocList;



            var years = objPSs.GetPresaleYearsALL();

            var selectYearList = new List<SelectListItem>();

            foreach (var element in years)
            {
                selectYearList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Years = selectYearList;


            var makes = objPSs.GetPresaleMakesAll();

            var selectMakeList = new List<SelectListItem>();

            foreach (var element in makes)
            {
                selectMakeList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Makes = selectMakeList;




            return View();
        }

        public ActionResult PostSaleSearch()
        {
            AHDDManagerClass.ManhiemPostSales objPSs = new AHDDManagerClass.ManhiemPostSales();

            var dates = objPSs.GetPostsaleDatesAll();

            var selectDateList = new List<SelectListItem>();

            foreach (var element in dates)
            {
                selectDateList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.SaleDates = selectDateList;




            var locations = objPSs.GetPostsaleLocationsAll();

            var selectLocList = new List<SelectListItem>();

            foreach (var element in locations)
            {
                selectLocList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Locations = selectLocList;



            var years = objPSs.GetPostsaleYearsALL();

            var selectYearList = new List<SelectListItem>();

            foreach (var element in years)
            {
                selectYearList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Years = selectYearList;


            var makes = objPSs.GetPostsaleMakesAll();

            var selectMakeList = new List<SelectListItem>();

            foreach (var element in makes)
            {
                selectMakeList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            ViewBag.Makes = selectMakeList;




            return View();
        }



        public ActionResult Selected()
        {
            AHDDManagerClass.ManhiemPreSales objPre = new AHDDManagerClass.ManhiemPreSales();

            var ret = objPre.GetPreSalesSelected().OrderBy(x => x.Location).ThenBy(c => c.Lane).ThenBy(d => d.Run);


            return View(ret);
        }

        public ActionResult HighMileage()
        {
            AHDDManagerClass.ManhiemPostSales objPost = new AHDDManagerClass.ManhiemPostSales();

            var ret = objPost.GetPostsalesHighOdo();

            return View(ret);
        }

        public ActionResult VinLookup()
        {
            return View();
        }



        //-------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------

        public ActionResult InsertSelected(int PresaleID, string Vin, string Miles)
        {
            try
            {
                AHDDManagerClass.ManhiemPreSale objPS = new AHDDManagerClass.ManhiemPreSale();
                CarValue objCV = new CarValue();

                objCV = GetVehicleValues(Vin, Miles);

                objPS.InsertSelected(PresaleID, objCV.Low, objCV.Average, objCV.High);

                return Json("");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }


        }


        public ActionResult DeleteSelected(int PresaleID)
        {
            AHDDManagerClass.ManhiemPreSale objPS = new AHDDManagerClass.ManhiemPreSale();
            objPS.DeleteSelected(PresaleID);

            return Json("");
        }

        public ActionResult DeleteSelectedALL()
        {
            AHDDManagerClass.ManhiemPreSale objPS = new AHDDManagerClass.ManhiemPreSale();
            objPS.DeleteSelectedALL();

            return Json("");
        }


        [HttpPost]
        public ActionResult GetRuns(string Location, DateTime PresaleDate)
        {
            AHDDManagerClass.ManhiemPreSales objPSs = new AHDDManagerClass.ManhiemPreSales();

            var runs = objPSs.GetPrePresaleRunsByLocDate(Location, PresaleDate);

            return Json(runs);
        }

        public ActionResult GetSubseries(string Make, string Model)
        {
            AHDDManagerClass.ManhiemPostSales objPSs = new AHDDManagerClass.ManhiemPostSales();

            var runs = objPSs.GetPostSubseriesByMakeModel(Make, Model);

            return Json(runs);
        }



        public ActionResult SearchPresales(AHDDManagerClass.ManhiemPreSale PreSale)
        {
            if (PreSale.Make == string.Empty) { PreSale.Make = null; }
            if (PreSale.Model == string.Empty) { PreSale.Model = null; };

            AHDDManagerClass.ManhiemPreSales objPSs = new AHDDManagerClass.ManhiemPreSales(PreSale);

            return Json(objPSs);
        }

        public ActionResult SearchPostsales(AHDDManagerClass.ManhiemPostSale PostSale)
        {
            //if (PostSale.PostSaleDate == DateTime.MinValue) { PostSale.PostSaleDate = null; }

            if (PostSale.Make == string.Empty) { PostSale.Make = null; }
            if (PostSale.Model == string.Empty) { PostSale.Model = null; };

            AHDDManagerClass.ManhiemPostSales objPSs = new AHDDManagerClass.ManhiemPostSales(PostSale);

            return Json(objPSs);
        }


        public ActionResult SearchPostsalesByOdometer(int Odometer)
        {
            //if (PostSale.PostSaleDate == DateTime.MinValue) { PostSale.PostSaleDate = null; }

            AHDDManagerClass.ManhiemPostSales objPSs = new AHDDManagerClass.ManhiemPostSales();

            var ret = objPSs.GetSalesByOdometer(Odometer);

            return Json(ret);
        }

        public ActionResult GetCarValue(string Vin, string Miles)
        {
            CarValue ret = GetVehicleValues(Vin, Miles);

            return Json(ret);

        }


        private CarValue GetVehicleValues(string Vin, string Miles)
        {
            CarValue ret = new CarValue();

            var client = new WebClient();
            //client.Headers.Add(Request.UserAgent, "c# app");

            Request.Headers["UserAgent"] = "appname";

            var response = client.DownloadString("http://marketvalue.vinaudit.com/getmarketvalue.php?key=VA_DEMO_KEY&format=json&period=360&mileage=" + Miles + "&vin=" + Vin);

            dynamic data = JObject.Parse(response);
            ret.Vehicle = data.vehicle;
            ret.Miles = Miles;
            ret.Success = data.success;

            if (ret.Success)
            {
                ret.Low = String.Format("{0:C}", data.prices.below);
                ret.Average = String.Format("{0:C}", data.prices.average);
                ret.High = String.Format("{0:C}", data.prices.above);
            }
            else
            {
                ret.Low = string.Empty;
                ret.Average = string.Empty;
                ret.High = string.Empty;
            }

            return ret;
        }

    }

    public class CarValue
    {
        public string Vehicle { get; set; }
        public string Miles { get; set; }
        public Boolean Success { get; set; }
        public string Low { get; set; }
        public string Average { get; set; }
        public string High { get; set; }
    }



}