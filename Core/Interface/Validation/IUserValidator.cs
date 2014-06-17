using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Validation
{
    public interface IUserValidator
    {
        DbUser VName(DbUser user, IUserService _userService);
        DbUser VHasMaintenance (DbUser user, IMaintenanceService _maintenanceService);
        DbUser VCreateObject(DbUser user, IUserService _userService);
        DbUser VUpdateObject(DbUser user, IUserService _userService);
        DbUser VDeleteObject(DbUser user, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(DbUser user, IUserService _userService);
        bool ValidUpdateObject(DbUser user, IUserService _userService);
        bool ValidDeleteObject(DbUser user, IMaintenanceService _maintenanceService);
        bool isValid(DbUser user);
        string PrintError(DbUser user);
    }
}