using BecaDotNet.ApplicationService;
using BecaDotNet.UI.MVC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BecaDotNet.UI.MVC.WebAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {


        [HttpGet]
        public IHttpActionResult Get(int id) {

            if(id < 0) {
                return BadRequest();
            }

            var svc = new CustomerAppSvcGeneric();
            var customer = svc.Get(id);

            if (customer == null) {
                return NotFound();
            }

            return Ok(customer);

        }

        [HttpPost]
        public IHttpActionResult Create(CustomerViewModel model) {

            if(
                string.IsNullOrEmpty(model.customerName) ||
                string.IsNullOrEmpty(model.contactName) ||
                (model.cnpj == 0 || model.cnpj.ToString().Length < 14) 
                ) {

                return BadRequest();
            }

            try {
                var svc = new CustomerAppSvcGeneric();
                var newCustomer = svc.Create(model.GetCustomer());

                return Ok(newCustomer);
            }
            catch (Exception e) {

                return InternalServerError(e); 
            }

           
        }



        [HttpDelete]
        public IHttpActionResult Delete(int id) {

            if(id < 0) {
                return BadRequest();
            }

            var svc = new CustomerAppSvcGeneric();
            var customer = svc.Get(id);

            if (customer == null) {

                return NotFound();

            }

            var result = svc.Delete(id);

            return result ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.InternalServerError);

        }


        [HttpPatch]
        public IHttpActionResult Patch(CustomerViewModel model) {
            if (!model.id.HasValue || model.id.Value < 0) {
                return BadRequest();
            }

            var svc = new CustomerAppSvcGeneric();
            var toUpdate = svc.Get(model.id.Value);
            if (toUpdate == null) {
                return NotFound();
            }

            try {
                toUpdate.Name = model.customerName;
                toUpdate.ContactName = model.contactName;
                var result = svc.Update(toUpdate);

                return Ok(result);
            }
            catch (Exception ex) {

                return InternalServerError(ex);
            }

        }

    }

   

}
