using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHDDManager
{
    /// <summary>
    /// Extend AuthorizeAttribute to correctly handle AJAX authorization
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxSessionExpireActionFilter : ActionFilterAttribute
    {
        public bool Disable { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (!Disable)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    if (filterContext.HttpContext.Session.Contents["Associate"] == null)
                    {
                        if (filterContext.HttpContext.Request.FilePath.ToUpper() != "/Home/".ToUpper() & filterContext.HttpContext.Request.FilePath.ToUpper().IndexOf("/manhiem/".ToUpper()) > 0)
                        {
                            filterContext.HttpContext.Response.StatusCode = 901;
                            filterContext.Result = new JsonResult
                            {
                                Data = new
                                {
                                    Error = "Session has expired",
                                    LogOnUrl = "~/home/"
                                },
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                            filterContext.HttpContext.Response.End();
                            //filterContext.HttpContext.Response.Redirect("~/home/"); 

                        }


                    }
                }
                else
                {
                    // this is a standard request, let parent filter to handle it
                    base.OnActionExecuting(filterContext);
                }
            }



        }



    }
}