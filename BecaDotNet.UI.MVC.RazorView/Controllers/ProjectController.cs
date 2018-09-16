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
    public class ProjectController : Controller
    {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult List() {

            var service = new ProjectAppSvcGeneric();
            var listProject = service.FindBy(null);

            ViewBag.listProject = listProject;


            return View();
        }

        [HttpGet]
        public ActionResult New() {
         

            List<SelectListItem> selectItens = new List<SelectListItem>();
            var service = new CustomerAppSvcGeneric();
            var listCustomer = service.FindBy(null).ToList();

           

            foreach (var item in listCustomer) {

                selectItens.Add(new SelectListItem {

                    Value = item.Id.ToString(),
                    Text = item.Name
                });
                
            }

            ViewBag.Clientes = selectItens;

            return View("ProjectControl");
        }

       

        [HttpPost]
        public ActionResult SaveProject(ProjectViewModel model) {
            if (!model.IsEdit)
                return CreateProjectAction(model);
            return EditProjectAction(model);
        }

        private ActionResult CreateProjectAction(ProjectViewModel model) {
            var createResult = DoCreateProject(model);
            if (createResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Criar o Projeto";
            return View("ProjectControl", model);
        }


       

        private bool DoCreateProject(ProjectViewModel model) {
            var svc = new ProjectAppSvcGeneric();
            var created = svc.Create(model.GetEntity());
            return created.Id > 0;


        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id.HasValue && id.Value > 0)
                return View("ProjectControl", GetViewModelForEdit(id.Value));
            return RedirectToAction("New");
        }

        private ActionResult EditProjectAction(ProjectViewModel model) {
            var updateResult = DoUpdateProject(model);
            if (updateResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Editar o projeto";
            return View("ProjectControl", model);
        }

        private bool DoUpdateProject(ProjectViewModel model) {
            var svc = new ProjectAppSvcGeneric();
            var updated = svc.Update(model.GetEntity());
            return updated != null;
        }

        private ProjectViewModel GetViewModelForEdit(int id) {

            var project = new ProjectAppSvcGeneric().Get(id);
            return new ProjectViewModel {

                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                IsEdit = true,
                Id = project.Id
                

            };
        }

        //private bool DoDeleteProject() {

        //    var service = new ProjectAppSvcGeneric();
        //    var delete = service.Delete();
        //    return View();
        //}

        public ActionResult Delete(int id) {



            var service = new ProjectAppSvcGeneric();
            var delete = service.Delete(id);

            return RedirectToAction("List");
        }

    }
    }