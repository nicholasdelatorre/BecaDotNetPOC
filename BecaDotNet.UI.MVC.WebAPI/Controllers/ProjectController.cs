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
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {


        [HttpGet]
        public IHttpActionResult Get(int id) {

            if (id < 0) {
                return BadRequest();
            }

            var svc = new ProjectAppSvcGeneric();
            var customer = svc.Get(id);

            if (customer == null) {
                return NotFound();
            }

            return Ok(customer);

        }

        [HttpPost]
        public IHttpActionResult Create(ProjectViewModel model) {

            if (
                string.IsNullOrEmpty(model.projectName) ||
                (model.customerId <= 0)
                ) {

                return BadRequest();
            }

            try {
                var svc = new ProjectAppSvcGeneric();
                var newProject = svc.Create(model.GetProject());

                return Ok(newProject);
            }
            catch (Exception e) {

                return InternalServerError(e);
            }


        }



        [HttpDelete]
        public IHttpActionResult Delete(int id) {

            if (id < 0) {
                return BadRequest();
            }

            var svc = new ProjectAppSvcGeneric();
            var project = svc.Get(id);

            if (project == null) {

                return NotFound();

            }

            var result = svc.Delete(id);

            return result ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.InternalServerError);

        }


        [HttpPatch]
        public IHttpActionResult Patch(ProjectViewModel model) {
            if (model.id < 0) {
                return BadRequest();
            }

            var svc = new ProjectAppSvcGeneric();
            var toUpdate = svc.Get(model.id.Value);
            if (toUpdate == null) {
                return NotFound();
            }

            try {
                toUpdate.ProjectName = model.projectName;
                
                var result = svc.Update(toUpdate);

                return Ok(result);
            }
            catch (Exception ex) {

                return InternalServerError(ex);
            }

        }

    }
}
