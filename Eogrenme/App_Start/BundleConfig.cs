using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Eogrenme.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles")
                  .Include("~/content/css/bootstrap.css")
                  .Include("~/content/css/bootstrap.min.css")
                  .Include("~/content/vendor/perfect-scrollbar.css")
                  .Include("~/content/css/material-icons.css")
                  .Include("~/content/css/material-icons.rtl.css")
                  .Include("~/content/css/fontawesome.css")
                  .Include("~/content/css/fontawesome.rtl.css")
                  .Include("~/content/css/app.css")
                  .Include("~/content/css/app.rtl.css")
                    .Include("~/Areas/Admin/Scripts/Forms.js")
                  );

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/content/vendor/jquery.min.js")
                .Include("~/content/vendor/popper.min.js")
                .Include("~/content/vendor/bootstrap.min.js")
                .Include("~/content/vendor/perfect-scrollbar.min.js")
                .Include("~/content/vendor/dom-factory.js")
                .Include("~/content/vendor/material-design-kit.js")
                .Include("~/content/js/app.js")
                .Include("~/content/js/hljs.js")
                .Include("~/content/js/app-settings.js")
                .Include("~/content/js/bootstrap.js")
                .Include("~/content/js/bootstrap.min.js")
                  .Include("~/Areas/Admin/Scripts/Forms.js")
                 );

            bundles.Add(new ScriptBundle("~/admin")
              .Include("~/Areas/Admin/Scripts/Forms.js")
              
          );

        }
    }
}