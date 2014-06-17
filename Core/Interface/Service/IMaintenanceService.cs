using Core.DomainModel;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface IMaintenanceService
    {
        IMaintenanceValidator GetValidator();
        IList<Maintenance> GetAll();
        Maintenance GetObjectById(int Id);
        Maintenance GetObjectByName(string Name);
        Maintenance CreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService);
        Maintenance UpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, IMaintenanceService _maintenanceService);
        Maintenance SoftDeleteObject(Maintenance maintenance);
        Maintenance DiagnoseAndSolutionObject(Maintenance maintenance);
        Maintenance ConfirmObject(Maintenance maintenance);
        Maintenance UnconfirmObject(Maintenance maintenance);
        Maintenance CancelDiagnoseAndSolutionObject(Maintenance maintenace);
        bool DeleteObject(int Id);
    }
}