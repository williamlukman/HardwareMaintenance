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
        IList<Maintenance> GetObjectsByItemId(int ItemId);
        IList<Maintenance> GetObjectsByCustomerId(int CustomerId);
        IList<Maintenance> GetObjectsByItemTypeId(int ItemTypeId);
        IList<Maintenance> GetObjectsByUserId(int UserId);
        Maintenance GetObjectById(int Id);
        Maintenance GetObjectByCode(string Code);
        Maintenance CreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService);
        Maintenance CreateObject(int ItemId, int CustomerId, int UserId, DateTime RequestDate, string Complaint, int MaintenanceCase,
                                  IItemService _itemService, IItemTypeService _itemTypeService, IUserService _userService, ICustomerService _customerService);
        Maintenance UpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService);
        Maintenance SoftDeleteObject(Maintenance maintenance);
        Maintenance DiagnoseAndSolutionObject(Maintenance maintenance);
        Maintenance DiagnoseAndSolutionObject(Maintenance maintenance, string Diagnosis, int DiagnosisCase, DateTime DiagnosisDate, string Solution, int SolutionCase);
        Maintenance ConfirmObject(Maintenance maintenance);
        Maintenance UnconfirmObject(Maintenance maintenance);
        Maintenance CancelDiagnoseAndSolutionObject(Maintenance maintenace);
        bool DeleteObject(int Id);
    }
}