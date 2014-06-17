using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Validation
{
    public interface IMaintenanceValidator
    {
        Maintenance VHasItem(Maintenance maintenance, IItemService _itemService);
        Maintenance VHasCustomer(Maintenance maintenance, ICustomerService _customerService);
        Maintenance VHasItemType(Maintenance maintenance, IItemTypeService _itemTypeService);
        Maintenance VHasUser (Maintenance maintenance, IUserService _userService);
        Maintenance VHasRequestDate(Maintenance maintenance);
        Maintenance VHasComplaint(Maintenance maintenance);
        Maintenance VHasCase(Maintenance maintenance);

        Maintenance VNotFinished(Maintenance maintenance);
        Maintenance VUpdateCustomer(Maintenance maintenance, IMaintenanceService _maintenanceService);

        Maintenance VNotDiagnosed(Maintenance maintenance);
        Maintenance VIsDiagnosed(Maintenance maintenance);
        Maintenance VHasDiagnosis(Maintenance maintenance);
        Maintenance VHasDiagnosisCase(Maintenance maintenance);
        Maintenance VHasDiagnosisDate(Maintenance maintenance);
        Maintenance VHasSolution(Maintenance maintenance);
        Maintenance VHasSolutionCase(Maintenance maintenance);

        Maintenance VCreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService);
        Maintenance VUpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService);
        Maintenance VDeleteObject(Maintenance maintenance);
        Maintenance VDiagnoseAndSolutionObject(Maintenance maintenance);
        Maintenance VConfirmObject(Maintenance maintenance);
        Maintenance VUnconfirmObject(Maintenance maintenance);
        Maintenance VCancelDiagnoseAndSolutionObject(Maintenance maintenance);

        bool ValidCreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService);
        bool ValidUpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService);
        bool ValidDeleteObject(Maintenance maintenance);
        bool ValidDiagnoseAndSolutionObject(Maintenance maintenance);
        bool ValidConfirmObject(Maintenance maintenance);
        bool ValidUnconfirmObject(Maintenance maintenance);
        bool ValidCancelDiagnoseAndSolutionObject(Maintenance maintenance);
        bool isValid(Maintenance maintenance);
        string PrintError(Maintenance maintenance);
    }
}

    }
}
