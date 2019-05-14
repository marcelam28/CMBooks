using System.Web;
using System.Web.Optimization;

namespace CMBooks.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/AjaxHelper").Include(
                        "~/Scripts/AjaxHelper.js"));
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/login.js"));
            bundles.Add(new ScriptBundle("~/bundles/login-f").Include(
                        "~/Scripts/login-f.js"));
            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                        "~/Scripts/register.js"));
            bundles.Add(new ScriptBundle("~/bundles/loading").Include(
                       "~/Scripts/easy-loading.js",
                       "~/Scripts/easy-loading.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/books-gallery").Include(
                        "~/Scripts/books-gallery.js"));
            bundles.Add(new ScriptBundle("~/bundles/rating").Include(
                        "~/Scripts/jquery.star-rating-svg.js"));
            bundles.Add(new ScriptBundle("~/bundles/pagination").Include(
                        "~/Scripts/jquery.simplePagination.js"));
            bundles.Add(new ScriptBundle("~/bundles/add-book").Include(
                        "~/Scripts/add-book.js"));
            #endregion

            #region StyleBundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/login").Include(
                       "~/Content/login.css"));
            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                       "~/Content/toastr.css"));
            bundles.Add(new StyleBundle("~/Content/loading").Include(
                       "~/Content/easy-loading.css",
                       "~/Content/easy-loading.min.css"));
            bundles.Add(new StyleBundle("~/Content/books-gallery").Include(
                       "~/Content/books-gallery.css"));
            bundles.Add(new StyleBundle("~/Content/rating").Include(
                       "~/Content/star-rating-svg.css"));
            bundles.Add(new StyleBundle("~/Content/tabs").Include(
                       "~/Content/tabs.css"));
            bundles.Add(new StyleBundle("~/Content/pagination").Include(
                       "~/Content/simplePagination.css"));
            bundles.Add(new StyleBundle("~/Content/add-book").Include(
                       "~/Content/add-book.css"));
            #endregion

        }
    }
}
