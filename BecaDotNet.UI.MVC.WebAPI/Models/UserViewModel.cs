using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.WebAPI.Models {
    public class UserViewModel {

        public string name { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int? superiorId { get; set; }
        public int? id { get; set; }

        public User GetUser() {

            return new User {
                Name = name,
                Email = email,
                Login = login,
                Password = password,
                SuperiorId = superiorId,
               // Id = id
            };
        }
    }
}