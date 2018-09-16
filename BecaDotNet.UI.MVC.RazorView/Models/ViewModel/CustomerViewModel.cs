using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel {

    public class CustomerViewModel {

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [Display(Name = "CNPJ")]
        public long Cnpj { get; set; }

        [Required(ErrorMessage = "Informe o nome do contato")]
        [Display(Name = "Nome do Contato")]
        public string ContactName { get; set; }

        [Display(Name = "Projetos")]
        public ICollection<Project> Projects { get; set; }


        public bool IsEdit { get; set; }
        public int Id { get; set; }

        public Customer GetEntity() {
            return new Customer {

                Name = CustomerName,
                Cnpj = this.Cnpj,
                ContactName = this.ContactName,
                Id = this.Id
            };
        }




    }
}