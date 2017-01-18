using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DNAMais.Site.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                "~/vendor/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/jquery").Include(
                "~/vendor/jquery/jquery-ui.css",
                "~/vendor/jquery/jquery-ui.structure.css",
                "~/vendor/jquery/jquery-ui.theme.css"));

            //bundles.Add(new StyleBundle("~/css/fontawesome").Include(
            //    "~/vendor/font-awesome/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/css/simplelineicons").Include(
                "~/vendor/simple-line-icons/css/simple-line-icons.css"));

            bundles.Add(new StyleBundle("~/css/carousel").Include(
                "~/vendor/owl.carousel/assets/owl.carousel.css",
                "~/vendor/owl.carousel/assets/owl.theme.default.css"));

            bundles.Add(new StyleBundle("~/css/magnificpopup").Include(
                "~/vendor/magnific-popup/magnific-popup.css"));

            bundles.Add(new StyleBundle("~/css/theme").Include(
                "~/css/theme.css",
                "~/css/theme-elements.css",
                "~/css/theme-blog.css",
                "~/css/theme-shop.css",
                "~/css/jquery.dataTables.css",
                "~/css/bootstrap-fileinput-master/css/fileinput.css",
                "~/css/theme-animate.css"));

            bundles.Add(new StyleBundle("~/css/rsplugin").Include(
                "~/vendor/rs-plugin/css/settings.css",
                "~/vendor/rs-plugin/css/layers.css",
                "~/vendor/rs-plugin/css/navigation.css"));

            bundles.Add(new StyleBundle("~/css/circleflipslideshow").Include(
                "~/vendor/circle-flip-slideshow/css/component.css"));

            //bundles.Add(new StyleBundle("~/css/skins").Include(
            //    "~/css/skins/default.css"));

            bundles.Add(new StyleBundle("~/css/custom").Include(
                "~/css/custom.css"));


            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                "~/vendor/modernizr/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/vendor/jquery.appear/jquery.appear.js",
                "~/vendor/jquery.easing/jquery.easing.js",
                "~/vendor/jquery-cookie/jquery-cookie.js",
                "~/vendor/jquery.validation/jquery.validation.js",
                "~/vendor/jquery.stellar/jquery.stellar.js",
                "~/vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.js",
                "~/vendor/jquery.gmap/jquery.gmap.js",
                "~/vendor/jquery.lazyload/jquery.lazyload.js",
                "~/vendor/magnific-popup/jquery.magnific-popup.js",
                "~/vendor/isotope/jquery.isotope.min.js",
                "~/js/jquery.mask.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/vendor/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/common").Include(
                "~/vendor/common/common.js"));

            bundles.Add(new ScriptBundle("~/Scripts/carousel").Include(
                "~/vendor/owl.carousel/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/Scripts/vide").Include(
                "~/vendor/vide/vide.js"));

            bundles.Add(new ScriptBundle("~/Scripts/theme").Include(
                "~/js/theme.js",
                "~/js/theme.init.js"));

            bundles.Add(new ScriptBundle("~/Scripts/rsplugin").Include(
                "~/vendor/rs-plugin/js/jquery.themepunch.tools.min.js",
                "~/vendor/rs-plugin/js/jquery.themepunch.revolution.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/circleflipslideshow").Include(
                "~/vendor/circle-flip-slideshow/js/jquery.flipshow.js"));

            bundles.Add(new ScriptBundle("~/Scripts/views").Include(
                "~/js/views/view.home.js"));

            bundles.Add(new ScriptBundle("~/Scripts/custom").Include(
                "~/js/custom.js"));

            bundles.Add(new ScriptBundle("~/Scripts/contractServices").Include(
                "~/js/contractServicesPf.js",
                "~/js/contractServicesPj.js",
                "~/js/contractServicesVehicle.js",
                "~/js/contractServicesFtp.js",
                "~/js/functionsPf.js",
                "~/js/functionsPj.js",
                "~/js/functionsVehicle.js",
                "~/js/functionsFtp.js",
                "~/js/jquery.dataTables.min.js",
                "~/js/fileinput.min.js"
                ));
        }
    }
}