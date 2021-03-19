using System.Web;
using System.Web.Optimization;

namespace AHDDManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-2.1.3.js",
                      "~/Scripts/jquery.formatCurrency-1.4.0.js",
                      "~/Scripts/jquery-ui-1.10.4.js",
                      "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/base/jquery-ui-1.10.4.css",
                        "~/Content/themes/Greentheme/jquery-ui-1.10.4.custom.css",
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/site.css",
                         "~/Content/Ajax.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
