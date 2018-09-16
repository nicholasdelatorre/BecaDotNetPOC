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
    public class CustomerAppSvcGenericTests {



        [TestMethod()]
        public void CreateTestValido() {

            var objCustomer = new Customer {

                Name = "Boteco do Zé - ME",
                ContactName = "Zézim",
                Cnpj = 32191161000110,
                IsActive = true,
                Projects = null

            };

            var srv = new CustomerAppSvcGeneric();
            var result = srv.Create(objCustomer);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
        }


        [TestMethod()]
        public void CreateTestInvalido() {

            var objCustomer = new Customer {

                Name = null,
                ContactName = "Zézim",
                Cnpj = 32191161000110,
                IsActive = true,
                Projects = null

            };

            var srv = new CustomerAppSvcGeneric();
            var result = srv.Create(objCustomer);
            Assert.IsNull(result);
            //Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod()]
        public void DeleteTestValido() {

            CustomerAppSvcGeneric rep = new CustomerAppSvcGeneric();
            
            Customer objCustomer = new Customer {

                    Id = 3
                    
                };

            var result = rep.Delete(objCustomer.Id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            

        }


        [TestMethod()]
        public void DeleteTestInvalido() {

            CustomerAppSvcGeneric rep = new CustomerAppSvcGeneric();

            Customer objCustomer = new Customer {

                Id = 4

            };

            var result = rep.Delete(objCustomer.Id);

            Assert.IsNotNull(result);
            Assert.IsFalse(result);


        }

        [TestMethod()]
        public void FindByTestGetByName() {
            var svc = new CustomerAppSvcGeneric();
            var result = svc.FindBy(new Customer { Name = "boteco" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void FindByTestGetAll()
        {
            var svc = new CustomerAppSvcGeneric();
            var result = svc.FindBy(null);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void GetTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest() {


            var objCustomer = new Customer() {

                Id = 2,
                ContactName = "Florisvaldo"

            };

            var svc = new CustomerAppSvcGeneric();
            var customerUpdated = svc.Update(objCustomer);

            Assert.IsNotNull(customerUpdated);
            Assert.IsTrue(customerUpdated.Id > 0);

        }
    }
}