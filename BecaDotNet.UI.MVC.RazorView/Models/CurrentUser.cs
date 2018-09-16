using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel {
    public class CurrentUser {

        public static User UserData {
            get =>
                HttpContext.Current.Session["CurrentUser"] == null ?
                    new User() :
                (User)HttpContext.Current.Session["CurrentUser"];
        }

    }
}