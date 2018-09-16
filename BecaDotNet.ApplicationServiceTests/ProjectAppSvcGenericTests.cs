using Microsoft.VisualStudio.TestTools.UnitTesting;
using BecaDotNet.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecaDotNet.Domain.Model;

namespace BecaDotNet.ApplicationService.Tests {
    [TestClass()]
    public class ProjectAppSvcGenericTests {

        [TestMethod()]
        public void CreateTest() {

            var objProject = new Project {

                ProjectName = "Lixo para teste",
                StartDate = DateTime.Now,
                IsActive = true,
                CustomerId = 1

            };

            var svc = new ProjectAppSvcGeneric();
            var result = svc.Create(objProject);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);

        }

        [TestMethod()]
        public void DeleteTest() {

            var svc = new ProjectAppSvcGeneric();

            var objProject = new Project {

                Id = 2

            };

            var result = svc.Delete(objProject.Id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void FindByTestGetAll() {
            var svc = new ProjectAppSvcGeneric();
            var result = svc.FindBy(null);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void FindByTestGetByName() {
            var svc = new ProjectAppSvcGeneric();
            var result = svc.FindBy(new Project { ProjectName = "fusca" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void GetTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest() {
            var objCustomer = new Project() {

                Id = 1,
                ProjectName = "Fusca Voador Falante com farol de raio lazer e bazuca"

            };

            var svc = new ProjectAppSvcGeneric();
            var projectUpdated = svc.Update(objCustomer);

            Assert.IsNotNull(projectUpdated);
            Assert.IsTrue(projectUpdated.Id > 0);
        }
    }
}