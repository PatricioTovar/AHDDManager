using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager.Models
{
    public class Security : Controller
    {
        public AHDDManagerClass.Associate Associate;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = filterContext.RequestContext.RouteData.Values["Controller"];
            var action = filterContext.RequestContext.RouteData.Values["Action"];

            if (Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("/home/index/");
            }
            else
            {
                //VaporStores.Classes.Logging.WriteToLog(controller.ToString() + ":" + action.ToString(), Session["SessionGUID"].ToString(),
                //                            ((VaporStoresData.PersonStoreRole)Session["User"]).Person.UserName.ToLower(),
                //                            ((VaporStoresData.PersonStoreRole)Session["User"]).Store.StoreID);


                if (Session["User"] != null && Session["Business"] != null)
                {
                    this.Associate = (AHDDManagerClass.Associate)Session["User"];
                    this.Associate.AssociateBusiness = (AHDDManagerClass.Business)Session["Business"];
                    
                    return;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/home/index/");
                    return;
                }


            }

        }


    }


    

}