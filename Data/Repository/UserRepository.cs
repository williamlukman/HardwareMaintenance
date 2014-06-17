using Core.DomainModel;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using System.Data;

namespace Data.Repository
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {

        private HardwareMaintenanceEntities entities;
        public UserRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<User> GetAll()
        {
            return FindAll().ToList();
        }

        public User GetObjectById(int Id)
        {
            User user = Find(x => x.Id == Id && !x.IsDeleted);
            if (user != null) { user.Errors = new Dictionary<string, string>(); }
            return user;
        }

        public User CreateObject(User user)
        {
            user.IsDeleted = false;
            user.CreatedAt = DateTime.Now;
            return Create(user);
        }

        public User UpdateObject(User user)
        {
            user.UpdatedAt = DateTime.Now;
            Update(user);
            return user;
        }

        public User SoftDeleteObject(User user)
        {
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            Update(user);
            return user;
        }

        public bool DeleteObject(int Id)
        {
            User user = Find(x => x.Id == Id);
            return (Delete(user) == 1) ? true : false;
        }
    }
}