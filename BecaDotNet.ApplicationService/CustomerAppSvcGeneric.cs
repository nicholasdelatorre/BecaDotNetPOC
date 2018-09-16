using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.ApplicationService {
    public class CustomerAppSvcGeneric : IGenericService<Customer> {


        private CustomerRepository rep = new CustomerRepository();

        public Customer Create(Customer toCreate) {


            try {
                rep.Create(toCreate);
                rep.Save();

                return toCreate;
            }
            catch (Exception) {

                return null;
            }


        }

        public bool Delete(int id) {

            try {
                rep.Delete(id);
                rep.Save();
                return true;
            }
            catch {
                return false;
            }
        }

        public IEnumerable<Customer> FindBy(Customer filter) {
            try {
                if (filter == null)
                    filter = new Customer();

                var result = rep.FindBy(f =>
               f.Cnpj.ToString().Contains(filter.Cnpj == 0 ? f.Cnpj.ToString() : filter.Cnpj.ToString()) &&
               f.Name.Contains(string.IsNullOrEmpty(filter.Name) ? f.Name : filter.Name));
                return result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Customer Get(int id) {

            try {
                return rep.GetSingle(id);
            }
            catch {
                return null;
            }
        }

        public Customer Update(Customer toUpdate) {

            

            try {
                var currentEntity = rep.GetSingle(toUpdate.Id);
                currentEntity.ContactName = toUpdate.ContactName;
                rep.Update(currentEntity);
                rep.Save();

                return currentEntity;
            }
            catch (Exception) {

                return null;
            }

        }
    }
}
