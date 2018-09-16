using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.RazorView.Models.Filter;
using BecaDotNet.UI.MVC.RazorView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BecaDotNet.UI.MVC.RazorView.Controllers {

    [CustomAuthorize]
    public class CustomerController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult List() {

            var service = new CustomerAppSvcGeneric();
            var listCustomer = service.FindBy(null);

            ViewBag.listCustomer = listCustomer;

            return View();
        }

        [HttpGet]
        public ActionResult New() {
            var vm = new CustomerViewModel();
            return View("CustomerControl", vm);
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id.HasValue && id.Value > 0)
                return View("CustomerControl", GetViewModelForEdit(id.Value));
            return RedirectToAction("New");
        }

        [HttpPost]
        public ActionResult SaveCustomer(CustomerViewModel model) {
            if (!model.IsEdit)
                return CreateCustomerAction(model);
            return EditCustomerAction(model);
        }

        private ActionResult CreateCustomerAction(CustomerViewModel model) {
            var createResult = DoCreateCustomer(model);
            if (createResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Criar o cliente";
            return View("CustomerControl", model);
        }


        private ActionResult EditCustomerAction(CustomerViewModel model) {
            var updateResult = DoUpdateCustomer(model);
            if (updateResult)
                return RedirectToAction("List");
            ViewBag.ErrorMessage = "Erro ao Editar o cliente";
            return View("CustomerControl", model);
        }

        private bool DoCreateCustomer(CustomerViewModel model) {
            var svc = new CustomerAppSvcGeneric();
            var created = svc.Create(model.GetEntity());
            return created.Id > 0;
        }

        private bool DoUpdateCustomer(CustomerViewModel model) {
            var svc = new CustomerAppSvcGeneric();
            var updated = svc.Update(model.GetEntity());
            return updated != null;
        }

        private CustomerViewModel GetViewModelForEdit(int id) {

            var customer = new CustomerAppSvcGeneric().Get(id);
            return new CustomerViewModel {
                CustomerName = customer.Name,
                Cnpj = customer.Cnpj,
                ContactName = customer.ContactName,
                IsEdit = true,
                Id = id
            };
        }

        public ActionResult Delete(int id) {



            var service = new CustomerAppSvcGeneric();
            var delete = service.Delete(id);

            return RedirectToAction("List");
        }
    }
}