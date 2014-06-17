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
        User VName(User user, IUserService _userService);
        User VHasMaintenance (User user, IMaintenanceService _maintenanceService);
        User VCreateObject(User user, IUserService _userService);
        User VUpdateObject(User user, IUserService _userService);
        User VDeleteObject(User user, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(User user, IUserService _userService);
        bool ValidUpdateObject(User user, IUserService _userService);
        bool ValidDeleteObject(User user, IMaintenanceService _maintenanceService);
        bool isValid(User user);
        string PrintError(User user);
    }
}

    }
}
