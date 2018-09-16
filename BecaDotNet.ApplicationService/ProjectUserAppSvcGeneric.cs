using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.ApplicationService {
    public class ProjectUserAppSvcGeneric : IGenericService<ProjetcUser> {

        ProjectUserRepository rep = new ProjectUserRepository();

        //public ProjetcUser StartProject(ProjetcUser project, ProjetcUser user) {

        //    var result = rep.StartProject(project, user);

        //    return Create(result);

        //}

        public ProjetcUser Create(ProjetcUser toCreate) {

            rep.Create(toCreate);
            rep.Save();

            return toCreate;

        }

        public bool Delete(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjetcUser> FindBy(ProjetcUser filter) {
            if (filter == null) {
                filter = new ProjetcUser { UserId = 0 };
                filter = new ProjetcUser { ProjectId = 0 };
            }
                
            try {
                var result = rep.FindBy(f => f.UserId ==
                (filter.UserId == 0 ? f.UserId : filter.UserId)
                ).ToList();
                return result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public ProjetcUser Get(int id) {
            try {
                return rep.GetSingle(id);
            }
            catch {
                return null;
            }
        }

        public ProjetcUser Update(ProjetcUser toUpdate) {
            try {
                var currentEntity = rep.GetSingle(toUpdate.Id);
                currentEntity.Responsavel = toUpdate.Responsavel;
                currentEntity.UserProjectEndDate = toUpdate.UserProjectEndDate;
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
