using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel {
    public class UserAccountViewModel {
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        [Display(Name = "Login")]
        public string LoginUsuario { get; set; }

        [Required(ErrorMessage = "Informe o E-Mail")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail inválido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string SenhaUsuario { get; set; }

        public bool IsEdit { get; set; }
        public int Id { get; set; }
        public int? IdSuperior { get; set; }

        public IEnumerable<SelectListItem> DdlUser { get; set; }

        public UserAccountViewModel() {
            DdlUser = HelperForDropdown<User>.GetDropDownListFrom(
                new UserAppSvcGeneric().FindBy(
                    new User { UserTypeId = 0 }).Where(w => w.Id != Id),
                "Name");
        }


        public User GetEntity() {
            return new User {
                Email = EmailUsuario,
                Name = NomeUsuario,
                Login = LoginUsuario,
                Password = SenhaUsuario,
                Id = Id,
                SuperiorId = IdSuperior.HasValue && IdSuperior.Value == -1 ? null : IdSuperior
            };
        }


    }
}