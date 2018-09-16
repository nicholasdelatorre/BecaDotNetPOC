using BecaDotNet.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BecaDotNet.ApplicationService.Tests
{
    [TestClass()]
    public class UserAppSvcGenericTests
    {
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        [TestMethod()]
        public void CreateTest()
        {
            var usr = new User
            {
                Email = "newusermail@mail.com",
                IsActive = true,
                Login = "newUser",
                Name = "New User",
                RegisterDate = DateTime.Now,
                Password = "dwp321",
                UserTypeId = 1
            };
            var svc = new UserAppSvcGeneric();
            var res = svc.Create(usr);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Id > 0);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void FindByTestGetAll()
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(null);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void FindByTestGetByName()
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(new User { Name="common"});
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
        
        [TestMethod()]
        public void FindByTestGetByUserType()
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(new User { UserTypeId = 1 });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod()]
        public void FindByTestGetByUserTypeNameInvalido()
        {
            var svc = new UserAppSvcGeneric();
            var result = svc.FindBy(new User { UserTypeId = 1,Name="common" });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod()]
        public void GetTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var svc = new UserAppSvcGeneric();
            var toUpdate = new User { Id = 2, Name = "New Name For Common" };
            var updated = svc.Update(toUpdate);
            Assert.IsNotNull(updated);
            Assert.AreEqual(toUpdate.Id, updated.Id);
            Assert.AreEqual(toUpdate.Name, updated.Name);
        }
    }
}