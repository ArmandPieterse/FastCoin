using System.Web;
using System.Web.Optimization;

namespace FastCoinTrader
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterGlobalScripts(bundles);
            RegisterGlobalStyles(bundles);
            RegisterBuyDashboardBundles(bundles);
            RegisterSellDashboardBundles(bundles);
            RegisterTradeHistoryBundles(bundles);
        }

        private static void RegisterGlobalScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js")
                .Include("~/Scripts/toastr.min.js")
                .IncludeDirectory("~/Scripts/BootstrapScripts", "*.js"));
        }

        private static void RegisterGlobalStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css"));
        }

        private static void RegisterBuyDashboardBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/angular/buydashboard/scripts")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-animate.js")

                // 3rd party plugins
                .Include("~/Scripts/angular-spinners.min.js")
                //.Include("~/Scripts/confirm/angular-acknowledge.js")
                //.Include("~/Scripts/confirm/angular-confirm.js")
                .Include("~/Scripts/smart-table.min.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/underscore.js")
                .IncludeDirectory("~/Scripts/Custom", "*.js")
                .IncludeDirectory("~/Scripts/Custom/angular-ui", "*.js")
                .IncludeDirectory("~/Scripts/Custom/notificationService", "*.js")
                //Start local custodian scripts
                .IncludeDirectory("~/Areas/BuyDashboard/app", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/services", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/models", "*.js")
                .IncludeDirectory("~/Areas/BuyDashboard/app/controllers", "*.js")
                .IncludeDirectory("~/Areas/BuyDashboard/app/services", "*.js")
                .IncludeDirectory("~/Areas/BuyDashboard/app/models", "*.js")
                );
        }

        private static void RegisterSellDashboardBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/angular/selldashboard/scripts")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-animate.js")

                // 3rd party plugins
                .Include("~/Scripts/angular-spinners.min.js")
                //.Include("~/Scripts/confirm/angular-acknowledge.js")
                //.Include("~/Scripts/confirm/angular-confirm.js")
                .Include("~/Scripts/smart-table.min.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/underscore.js")
                .IncludeDirectory("~/Scripts/Custom", "*.js")
                .IncludeDirectory("~/Scripts/Custom/angular-ui", "*.js")
                .IncludeDirectory("~/Scripts/Custom/notificationService", "*.js")
                //Start local custodian scripts
                .IncludeDirectory("~/Areas/SellDashboard/app", "*.js")
                .IncludeDirectory("~/Areas/SellDashboard/app/services", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/models", "*.js")
                .IncludeDirectory("~/Areas/SellDashboard/app/controllers", "*.js")
                );
        }

        public static void RegisterTradeHistoryBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/angular/selldashboard/scripts")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-animate.js")

                // 3rd party plugins
                .Include("~/Scripts/angular-spinners.min.js")
                //.Include("~/Scripts/confirm/angular-acknowledge.js")
                //.Include("~/Scripts/confirm/angular-confirm.js")
                .Include("~/Scripts/smart-table.min.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/underscore.js")
                .IncludeDirectory("~/Scripts/Custom", "*.js")
                .IncludeDirectory("~/Scripts/Custom/angular-ui", "*.js")
                .IncludeDirectory("~/Scripts/Custom/notificationService", "*.js")
                //Start local custodian scripts
                .IncludeDirectory("~/Areas/SellDashboard/app", "*.js")
                //.IncludeDirectory("~/Areas/SellDashboard/app/services", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/models", "*.js")
                .IncludeDirectory("~/Areas/SellDashboard/app/controllers", "*.js"));
        }
    }
}
