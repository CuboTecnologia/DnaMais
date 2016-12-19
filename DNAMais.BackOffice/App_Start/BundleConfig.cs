using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DNAMais.BackOffice.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                "~/assets/vendor/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/magnificpopup").Include(
                "~/assets/vendor/magnific-popup/magnific-popup.css"));

            bundles.Add(new StyleBundle("~/css/datepicker").Include(
                "~/assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css"));

            bundles.Add(new StyleBundle("~/css/jquery").Include(
                "~/assets/vendor/jquery-ui/jquery-ui.css",
                "~/assets/vendor/jquery-ui/jquery-ui.theme.css"));

            bundles.Add(new StyleBundle("~/css/multiselect").Include(
                "~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.css"));

            bundles.Add(new StyleBundle("~/css/morris").Include(
                "~/assets/vendor/morris.js/morris.css"));

            bundles.Add(new StyleBundle("~/css/select2").Include(
                "~/assets/vendor/select2/css/select2.css",
                "~/assets/vendor/select2-bootstrap-theme/select2-bootstrap.css"));

            //bundles.Add(new StyleBundle("~/css/datatables").Include(
            //    "~/assets/vendor/jquery-datatables-bs3/assets/css/datatables.css"));

            bundles.Add(new StyleBundle("~/css/theme").Include(
                "~/assets/stylesheets/theme.css"));

            bundles.Add(new StyleBundle("~/css/default").Include(
                "~/assets/stylesheets/skins/default.css"));

            bundles.Add(new StyleBundle("~/css/themecustom").Include(
                "~/assets/stylesheets/theme-custom.css"));

            //bundles.Add(new StyleBundle("~/css/dataTable").Include(
            //   "~/assets/stylesheets/jquery.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/assets/vendor/modernizr/modernizr.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/assets/vendor/jquery/jquery.js",
                "~/assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js",
                "~/assets/vendor/magnific-popup/jquery.magnific-popup.js",
                "~/assets/vendor/jquery-placeholder/jquery-placeholder.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/assets/vendor/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/nanoscroller").Include(
                "~/assets/vendor/nanoscroller/nanoscroller.js"));

            bundles.Add(new ScriptBundle("~/Scripts/select2").Include(
                "~/assets/vendor/select2/js/select2.js"));

            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/assets/vendor/jquery-datatables/media/js/jquery.dataTables.js",
                "~/assets/vendor/jquery-datatables/extras/TableTools/js/dataTables.tableTools.js",
                "~/assets/vendor/jquery-datatables-bs3/assets/js/datatables.js",
                "~/assets/javascripts/tables/examples.datatables.default.js",
                "~/assets/javascripts/tables/examples.datatables.row.with.details.js",
                "~/assets/javascripts/tables/examples.datatables.tabletools.js"));

            bundles.Add(new ScriptBundle("~/Scripts/theme").Include(
                "~/assets/javascripts/theme.js",
                "~/assets/javascripts/theme.custom.js",
                "~/assets/javascripts/theme.init.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryvalidation").Include(
                        "~/assets/javascripts/jquery-validation/dist/jquery.validate.js",
                        "~/assets/javascripts/form_validator.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*")); 
            
            bundles.Add(new ScriptBundle("~/Scripts/"));
        }

    }
}