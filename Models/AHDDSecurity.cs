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
                //filterContext.Result = new RedirectResult("/home/index/");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "home",
                    action = "index"
                }));
            }
            else
            {
                this.Associate = (AHDDManagerClass.Associate)Session["Associate"];
                this.ViewBag.AssociateID = Associate.AssociateID;
                this.ViewBag.IsAdmin = Associate.IsAdmin;

                this.Business = ((AHDDManagerClass.Business)Session["Business"]);

                

                return;



                //VaporStores.Classes.Logging.WriteToLog(controller.ToString() + ":" + action.ToString(), Session["SessionGUID"].ToString(),
                //                            ((VaporStoresData.PersonStoreRole)Session["User"]).Person.UserName.ToLower(),
                //                            ((VaporStoresData.PersonStoreRole)Session["User"]).Store.StoreID);

                //switch ((VaporStores.DAL.enumUserType.enumUsertypes)Session["UserType"])
                //{
                //    case enumUserType.enumUsertypes.SALES:
                //        filterContext.Result = new RedirectResult("/sale/");

                //        return;

                //    case enumUserType.enumUsertypes.QUEUE:
                //        filterContext.Result = new RedirectResult("/queue/");
                //        return;

                //    case enumUserType.enumUsertypes.USER:


                //        if (Session["User"] != null)
                //        {
                //            this.User = (VaporStoresData.PersonStoreRole)Session["User"];
                //            this.Person = ((VaporStoresData.PersonStoreRole)Session["User"]).Person;
                //            this.Store = ((VaporStoresData.PersonStoreRole)Session["User"]).Store;
                //            this.StoreAssociates = ((VaporStoresData.PersonStoreRole)Session["User"]).StoreAssociates;
                //            this.AssociateStores = ((VaporStoresData.PersonStoreRole)Session["User"]).AssociateStores;

                //            ViewBag.Role = ((VaporStoresData.PersonStoreRole)Session["User"]).PersonRole;

                //            return;
                //        }
                //        else
                //        {
                //            filterContext.Result = new RedirectResult("/home/index/");
                //            return;
                //        }
                //    default:
                //        filterContext.Result = new RedirectResult("/home/index/");
                //        return;

                //}

            }

        }

    }
}