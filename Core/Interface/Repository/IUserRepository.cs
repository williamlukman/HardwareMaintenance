using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IUserRepository : IRepository<DbUser>
    {
        IList<DbUser> GetAll();
        DbUser GetObjectById(int Id);
        DbUser CreateObject(DbUser user);
        DbUser UpdateObject(DbUser user);
        DbUser SoftDeleteObject(DbUser user);
        bool DeleteObject(int Id);
    }
}