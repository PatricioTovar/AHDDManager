using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AHDDManager.Models
{
    public class AHDDSecurity : Controller
    {
        public AHDDManagerClass.Associate Associate { get; set; }
        public AHDDManagerClass.Business Business { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = filterContext.RequestContext.RouteData.Values["Controller"];
            var action = filterContext.RequestContext.RouteData.Values["Action"];

            if (Session["Associate"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 403;
                    var jsonResult = new JsonResult { Data = "LogOut" };
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = jsonResult;
                }
                else
                {
                    //filterContext.Result = new RedirectResult("/home/index/");
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "home",
                        action = "index"
                    }));
                }

            }
            else
            {
                this.Associate = (AHDDManagerClass.Associate)Session["Associate"];
                this.ViewBag.AssociateID = Associate.AssociateID;
                this.ViewBag.IsAdmin = Associate.IsAdmin;

                this.Business = ((AHDDManagerClass.Business)Session["Business"]);

                return;

            }

        }

    }
}