using System.Web;
using System.Web.Optimization;

namespace FastCoinTrader
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //    "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap")
            //    .Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js")
            //    .IncludeDirectory("~/Scripts/BootstrapScripts", "*.js"));

            //bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css"));

            RegisterGlobalScripts(bundles);
            RegisterGlobalStyles(bundles);
            RegisterBuyDashboardBundles(bundles);
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

                // Directives folder must fall away when UI components are completely implemented system wide
                //.IncludeDirectory("~/Scripts/Directives", "*.js")

                // Load modules for injection into main app
                // Custom modules
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/auth", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/header", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/buyerIdentificationService", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/terminalStatusService", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/configurationService", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/contentService", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/keybinding", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/money", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/table-navigation", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/helpers", "*.js")

                // Custom UI modules
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/buttons", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/formControls", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/modal-ext", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/st-table-ext", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/templates", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/validation", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/structural", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/notifications", "*.js")
                //.IncludeDirectory("~/Scripts/angular-infrastructure/custom/ui/filters", "*.js")

                // Locale specific scripts
                //.Include("~/Scripts/angular-infrastructure/third-party/libphonenumber/angular-libphonenumber.js")

                // Third party angular modules
                //.Include("~/Scripts/angular-infrastructure/third-party/angular-ui-tree/angular-ui-tree.js")

                //Start local custodian scripts
                .IncludeDirectory("~/Areas/BuyDashboard/app", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/services", "*.js")
                //.IncludeDirectory("~/Areas/BuyDashboard/app/models", "*.js")
                .IncludeDirectory("~/Areas/BuyDashboard/app/controllers", "*.js")
                );
        }
    }
}
