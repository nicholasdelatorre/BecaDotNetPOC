using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.ApplicationService {

    public class ProjectAppSvcGeneric : IGenericService<Project> {


        private ProjectRepository rep = new ProjectRepository();

       

        public Project Create(Project project) {

            try {

                rep.Create(project);
                rep.Save();

                return project;

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

    

        public IEnumerable<Project> FindBy(Project filter) {
            if (filter == null)
                filter = new Project { CustomerId = 0 };
            try {
                var result = rep.FindBy(f => f.CustomerId ==
                (filter.CustomerId == 0 ? f.CustomerId : filter.CustomerId)
                ).ToList();
                return result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Project Get(int id) {
            try {
                return rep.GetSingle(id);
            }
            catch {
                return null;
            }
        }

        public Project Update(Project toUpdate) {
            try {
                var currentEntity = rep.GetSingle(toUpdate.Id);
                currentEntity.ProjectName = toUpdate.ProjectName;
                currentEntity.EndDate = toUpdate.EndDate;
                rep.Update(currentEntity);
                rep.Save();
                return currentEntity;
            }
            catch {
                return null;
            }
        }
    }
}
