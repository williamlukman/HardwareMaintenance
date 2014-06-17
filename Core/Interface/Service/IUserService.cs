using Core.DomainModel;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface IUserService
    {
        IUserValidator GetValidator();
        IList<User> GetAll();
        User GetObjectById(int Id);
        User GetObjectByName(string Name);
        User CreateObject(User user);
        User CreateObject(string Name, string Description);
        User UpdateObject(User user);
        User SoftDeleteObject(User user, IMaintenanceService _maintenanceService);
        bool DeleteObject(int Id);
    }
}