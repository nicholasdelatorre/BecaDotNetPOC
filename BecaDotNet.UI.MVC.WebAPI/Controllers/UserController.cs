using BecaDotNet.ApplicationService;
using BecaDotNet.Domain.Model;
using BecaDotNet.UI.MVC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BecaDotNet.UI.MVC.WebAPI.Controllers {

    /// <summary>
    /// Retornar mensagem "Hello, { name }"
    /// </summary>
    [EnableCors(origins:"http://localhost:4200", headers: "*", methods:"GET,POST,PATCH,DELETE")]
    public class UserController : ApiController {

        //[Route("SayHallo")]
        //[HttpGet]
        //public IHttpActionResult SayHello(string name) {
        //    if (string.IsNullOrEmpty(name)) {
        //        return BadRequest();
        //    }

        //    return Ok($"Hello, { name }");
        //}

        [HttpGet]
        public IHttpActionResult Get(int? id) {

            var result = new UserAppSvcGeneric().Get(id.Value);

            if (id < 0) {
                return BadRequest();
            }

            if(result.IsActive == false) {
                return BadRequest();
            }

            
            if (result == null) {
                return NotFound();
            }

          

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(UserViewModel model) {
            if (string.IsNullOrEmpty(model.name) ||
               string.IsNullOrEmpty(model.login) ||
               string.IsNullOrEmpty(model.email) ||
               string.IsNullOrEmpty(model.password)) {

                return BadRequest();
            }

            try {

                var svc = new UserAppSvcGeneric();
                var toCreate = model.GetUser();
                var result = svc.Create(toCreate);

                return Ok(result);
            }
            catch (Exception ex) {

                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id) {
            if(id < 0) {
                return BadRequest();
            }
            var svc = new UserAppSvcGeneric();
            var user = svc.Get(id);
            if(user == null) {
                return NotFound();
            }

            var result = svc.Delete(id);

            return result ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.InternalServerError);
        }

        [HttpPatch]
        public IHttpActionResult Patch(UserViewModel model) {
            if (!model.id.HasValue || model.id.Value < 0) {
                return BadRequest();
            }

            var svc = new UserAppSvcGeneric();
            var toUpdate = svc.Get(model.id.Value);
            if (toUpdate == null) {
                return NotFound();
            }

            try {
                toUpdate.Name = model.name;
                var result = svc.Update(toUpdate);

                return Ok(result);
            }
            catch (Exception ex) {

                return InternalServerError(ex);
            }
           
        }

        [HttpGet]
        [Route("api/user/list")]
        public IHttpActionResult List(string name, int? userTypeId) {
            var svc = new UserAppSvcGeneric();

            var filter = new User {
                Name = name,
                UserTypeId = userTypeId ?? 0 // ?? teste se o resultado é nulo
            };

            var result = svc.FindBy(filter);

            if(result == null || result.Count() == 0) {
                return NotFound();
            }

            return Ok(result);

        }
    }
}
