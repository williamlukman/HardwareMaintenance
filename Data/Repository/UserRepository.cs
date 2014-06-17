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
    public class UserRepository : EfRepository<DbUser>, IUserRepository
    {

        private HardwareMaintenanceEntities entities;
        public UserRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<DbUser> GetAll()
        {
            return FindAll().ToList();
        }

        public DbUser GetObjectById(int Id)
        {
            DbUser user = Find(x => x.Id == Id && !x.IsDeleted);
            if (user != null) { user.Errors = new Dictionary<string, string>(); }
            return user;
        }

        public DbUser CreateObject(DbUser user)
        {
            user.IsDeleted = false;
            user.CreatedAt = DateTime.Now;
            return Create(user);
        }

        public DbUser UpdateObject(DbUser user)
        {
            user.UpdatedAt = DateTime.Now;
            Update(user);
            return user;
        }

        public DbUser SoftDeleteObject(DbUser user)
        {
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            Update(user);
            return user;
        }

        public bool DeleteObject(int Id)
        {
            DbUser user = Find(x => x.Id == Id);
            return (Delete(user) == 1) ? true : false;
        }
    }
}