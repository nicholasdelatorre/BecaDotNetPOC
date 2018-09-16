using System;
using System.Collections.Generic;
using System.Linq;
using BecaDotNet.Domain.Model;
using BecaDotNet.Domain.Service;
using BecaDotNet.Repository;

namespace BecaDotNet.ApplicationService
{
    public class UserAppSvcGeneric : IGenericService<User>
    {
        private UserRepositoryGeneric rep = new UserRepositoryGeneric();

        private void CreateUserTypeUser(User user)
        {
            var userTypeUser = new UserTypeUserAppSvcGeneric().
                Create(new UserTypeUser
                {
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    StartDate = DateTime.Now,
                    UserId = user.Id,
                    UserTypeId = user.UserTypeId
                });
        }

        public User Create(User toCreate)
        {
            try
            {
                rep.Create(toCreate);
                rep.Save();
                CreateUserTypeUser(toCreate);
                return toCreate;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
                try
                {
                    rep.Delete(id);
                    rep.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
        }

        public IEnumerable<User> FindBy(User filter)
        {
            if (filter == null)
                filter = new User { UserTypeId = 0, IsActive = true };

            try {
                var result = rep.FindBy(
                    item =>
                    item.IsActive == filter.IsActive &&
                    item.Name.Contains(

                        string.IsNullOrEmpty(filter.Name) ?
                            item.Name : filter.Name) &&
                    item.UserTypeId == (
                    filter.UserTypeId > 0 ?
                    filter.UserTypeId : item.UserTypeId)
                    , a => a.UserType, a => a.Superior
                    ).ToList();
                return result;
            }
            catch (Exception exs) {
                return null;
            }
        }

        public User Get(int id)
        {
            try
            {
                return rep.GetSingle(id);
            }
            catch
            {
                return null;
            }
        }

        public User Update(User toUpdate)
        {
            try
            {
                var currentEntity = rep.GetSingle(toUpdate.Id);
                currentEntity.Name = toUpdate.Name;
                rep.Update(currentEntity);
                rep.Save();
                return currentEntity;
            }
            catch
            {
                return null;
            }
        }

        public User Authenticate(string login, string password)
        {
            return rep.Authenticate(login, password);
        }
    }
}
