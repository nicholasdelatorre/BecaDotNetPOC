using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.RazorView.Models.Filter;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers
{
    [CustomAuthorize]
    public class ProjectUserController : Controller
    {

        [HttpGet]
        public ActionResult New(int? id) {
      
            var viewModelParaPagina = new ProjectUserViewModel();
            if (id.HasValue)
                viewModelParaPagina = new ProjectUserViewModel(id.Value);
            return View("ProjectUserControl",viewModelParaPagina);
        }

        [HttpGet]
        public ActionResult List() {

            var service = new ProjectUserAppSvcGeneric();
            var listProjectUser = service.FindBy(null);

            ViewBag.listProjectUser = listProjectUser;


            return View();


        }

        [HttpPost]
        public ActionResult SaveProjectUser(ProjectUserViewModel model) {
            if (!model.IsEdit)
                return CreateProjectUserAction(model);
            return EditProjectUserAction(model);
        }

        private ActionResult CreateProjectUserAction(ProjectUserViewModel model) {
            var createResult = DoCreateProjectUser(model);
            if (createResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Criar o Projeto";
            return View("ProjectUserControl", model);
        }




        private bool DoCreateProjectUser(ProjectUserViewModel model) {
            var svc = new ProjectUserAppSvcGeneric();
            var created = svc.Create(model.GetEntity());
            return created.Id > 0;


        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id.HasValue && id.Value > 0)
                return View("ProjectUserControl", GetViewModelForEdit(id.Value));
            return RedirectToAction("New");
        }

        private ActionResult EditProjectUserAction(ProjectUserViewModel model) {
            var updateResult = DoUpdateProjectUser(model);
            if (updateResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Editar o projeto";
            return View("ProjectUserControl", model);
        }

        private bool DoUpdateProjectUser(ProjectUserViewModel model) {
            var svc = new ProjectUserAppSvcGeneric();
            var updated = svc.Update(model.GetEntity());
            return updated != null;
        }

        private ProjectUserViewModel GetViewModelForEdit(int id) {

            var projectUser = new ProjectUserAppSvcGeneric().Get(id);
            return new ProjectUserViewModel {

                ProjectId = projectUser.ProjectId,
                UserId = projectUser.UserId,
                UserProjectStartDate = DateTime.Now,
                UserProjectEndDate = projectUser.UserProjectEndDate,
                Responsavel = projectUser.Responsavel,
                Id = projectUser.Id,
                IsEdit = true

            };
        }
    }
}