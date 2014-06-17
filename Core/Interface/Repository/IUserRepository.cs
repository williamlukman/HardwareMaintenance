using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetAll();
        User GetObjectById(int Id);
        User CreateObject(User user);
        User UpdateObject(User user);
        User SoftDeleteObject(User user);
        bool DeleteObject(int Id);
    }
}