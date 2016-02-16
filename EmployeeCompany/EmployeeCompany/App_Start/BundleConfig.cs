using System.Web.Optimization;

namespace EmployeeCompany.App_Start {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.2.0.min.js",
                                                                        "~/Scripts/jquery-ui-1.11.4.min.js",
                                                                        "~/Scripts/jquery.validate.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryvalidation").Include("~/Script/jquery.validate.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/ajax").Include("~/Scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new ScriptBundle("~/bundles/script").Include("~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/jquery.ui").Include("~/Content/themes/base/all.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css",
                                                                "~/Content/bootstrap.min.css",
                                                                "~/Content/bootstrap-theme.css",
                                                                "~/Content/bootstrap-theme.min.css"));
            bundles.Add(new StyleBundle("~/MyContent/css").Include("~/Content/style.css"));
        }

    }
}