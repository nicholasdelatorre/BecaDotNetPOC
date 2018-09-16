using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.WebAPI.Models {
    public class CustomerViewModel {

        public string customerName { get; set; }
        public long cnpj { get; set; }
        public string contactName { get; set; }
        public int? id { get; set; }

        public Customer GetCustomer() {
            return new Customer {

                Name = customerName,
                Cnpj = cnpj,
                ContactName = contactName,
            
            };
        }

    }
}