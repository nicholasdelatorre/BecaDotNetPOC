using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.RazorView.Models {
    public static class UrlToActionHelper {


        public static Dictionary<string, string> GetRouteFromUrl(string url) {
            var urlSplit = url.Split('/');
            return new Dictionary<string, string>
                   {
                        {"Controller",urlSplit[1]},
                         { "Action",urlSplit[2]}
                   };
        }

    }
}