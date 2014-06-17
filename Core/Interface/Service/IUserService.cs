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
        IList<DbUser> GetAll();
        DbUser GetObjectById(int Id);
        DbUser GetObjectByName(string Name);
        DbUser CreateObject(DbUser user);
        DbUser CreateObject(string Name, string Description);
        DbUser UpdateObject(DbUser user);
        DbUser SoftDeleteObject(DbUser user, IMaintenanceService _maintenanceService);
        bool DeleteObject(int Id);
        bool IsNameDuplicated(DbUser user);
    }
}