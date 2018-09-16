using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.RazorView.Models.Filter;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List() {

            var service = new UserAppSvcGeneric();
            var listUser = service.FindBy(null);

            ViewBag.listUser = listUser;

            return View();
        }

        //[HttpGet]
        //public ActionResult List() {
        //    var model = GetViewModelForList(new UserAppSvcGeneric().FindBy(null));
        //    return View(model);
        //}

        //[HttpGet]
        //public PartialViewResult ListUser() {
        //    var model = GetViewModelForList(new UserAppSvcGeneric().FindBy(new User { UserTypeId = 0 }));
        //    return PartialView("UserListGrid", model);
        //}

        //private IEnumerable<UserListViewModel> GetViewModelForList(IEnumerable<User> list) {
        //    var result = new List<UserListViewModel>();
        //    foreach (var i in list)
        //        result.Add(new UserListViewModel {
        //            DataCadastro = i.RegisterDate,
        //            EmailUsuario = i.Email,
        //            Id = i.Id,
        //            DescTipoUsuario = i.UserType != null ? i.UserType.Description : "N/A",
        //            LoginUsuario = i.Login,
        //            NomeSuperior = i.Superior != null ? i.Superior.Name : "N/A",
        //            NomeUsuario = i.Name,
        //            UsuarioAtivo = i.IsActive
        //        });
        //    return result;
        //}

        [HttpGet]
        public ActionResult New()
        {
            var vm = new UserAccountViewModel();
            return View("UserControl", vm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return View("UserControl", GetViewModelForEdit(id.Value));
            return RedirectToAction("New");
        }

        [HttpPost]
        public ActionResult SaveUser(UserAccountViewModel model)
        {
            if (!model.IsEdit)
                return CreateUserAction(model);
            return EditUserAction(model);
        }

        private ActionResult CreateUserAction(UserAccountViewModel model)
        {
            var createResult = DoCreateUser(model);
            if (createResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Criar o usuário";
            return View("UserControl",model);
        }


        private ActionResult EditUserAction(UserAccountViewModel model)
        {
            var updateResult = DoUpdateUser(model);
            if (updateResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Editar o usuário";
            return View("UserControl",model);
        }

        private bool DoCreateUser(UserAccountViewModel model)
        {
            var svc = new UserAppSvcGeneric();
            var created = svc.Create(model.GetEntity());
            return created.Id > 0;
        }

        private bool DoUpdateUser(UserAccountViewModel model)
        {
            var svc = new UserAppSvcGeneric();
            var updated = svc.Update(model.GetEntity());
            return updated != null;
        }

        private UserAccountViewModel GetViewModelForEdit(int id)
        {
            var user = new UserAppSvcGeneric().Get(id);
            return new UserAccountViewModel
            {
                EmailUsuario = user.Email,
                LoginUsuario = user.Login,
                NomeUsuario = user.Name,
                IsEdit = true,
                Id = id
            };
        }

        [HttpGet]
        public ActionResult Delete(int id) {



            var service = new UserAppSvcGeneric();
            var delete = service.Delete(id);

            return RedirectToAction("List");
        }


    }
}