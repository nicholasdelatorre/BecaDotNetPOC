using Microsoft.VisualStudio.TestTools.UnitTesting;
using BecaDotNet.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecaDotNet.Domain.Model;
using BecaDotNet.Repository;

namespace BecaDotNet.ApplicationService.Tests {
    [TestClass()]
    public class ProjectUserAppSvcGenericTests {

        [TestMethod()]
        public void StartProjectTest() {

            var projectUser = new ProjetcUser {
                IsActive = true,
                ProjectId = 1,
                UserId = 1,
                UserProjectStartDate = DateTime.Now,
                Responsavel = "Fred Mercury Prateado",
                

            };
          
            var svc = new ProjectUserAppSvcGeneric();

            var result = svc.Create(projectUser);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);


        }

        [TestMethod()]
        public void CreateTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void FindByTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest() {
            throw new NotImplementedException();
        }
    }
}