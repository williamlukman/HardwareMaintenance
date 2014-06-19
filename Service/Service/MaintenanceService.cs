using Core.DomainModel;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MaintenanceService : IMaintenanceService
    {
        private IMaintenanceRepository _repository;
        private IMaintenanceValidator _validator;
        public MaintenanceService(IMaintenanceRepository _maintenanceRepository, IMaintenanceValidator _maintenanceValidator)
        {
            _repository = _maintenanceRepository;
            _validator = _maintenanceValidator;
        }

        public IMaintenanceValidator GetValidator()
        {
            return _validator;
        }

        public IList<Maintenance> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Maintenance> GetObjectsByItemId(int ItemId)
        {
            return _repository.GetObjectsByItemId(ItemId);
        }

        public IList<Maintenance> GetObjectsByCustomerId(int CustomerId)
        {
            return _repository.GetObjectsByCustomerId(CustomerId);
        }

        public IList<Maintenance> GetObjectsByItemTypeId(int ItemTypeId)
        {
            return _repository.GetObjectsByItemTypeId(ItemTypeId);
        }

        public IList<Maintenance> GetObjectsByUserId(int UserId)
        {
            return _repository.GetObjectsByUserId(UserId);
        }

        public Maintenance GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public Maintenance GetObjectByCode(string Code)
        {
            return _repository.FindAll(m => m.Code == Code && !m.IsDeleted).FirstOrDefault();
        }

        public Maintenance CreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService)
        {
            maintenance.Errors = new Dictionary<String, String>();
            if (_validator.ValidCreateObject(maintenance, _itemService, _itemTypeService, _userService, _customerService))
            {
                Item item = _itemService.GetObjectById(maintenance.ItemId);
                maintenance.ItemTypeId = item.ItemTypeId;
                return _repository.CreateObject(maintenance);
            }
            else
            {
                return maintenance;
            }
        }

        public Maintenance CreateObject(int ItemId, int CustomerId, int UserId, DateTime RequestDate, string Complaint, int MaintenanceCase,
                                        IItemService _itemService, IItemTypeService _itemTypeService, IUserService _userService, ICustomerService _customerService)
        {
            Maintenance maintenance = new Maintenance()
            {
                ItemId = ItemId,
                CustomerId = CustomerId,
                UserId = UserId,
                RequestDate = RequestDate,
                Complaint = Complaint,
                Case = MaintenanceCase
            };
            return this.CreateObject(maintenance, _itemService, _itemTypeService, _userService, _customerService);
        }

        public Maintenance UpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService)
        {
            return (maintenance = _validator.ValidUpdateObject(maintenance, _itemService, _itemTypeService, _userService, _customerService, _maintenanceService) ? _repository.UpdateObject(maintenance) : maintenance);
        }

        public Maintenance SoftDeleteObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidDeleteObject(maintenance) ? _repository.SoftDeleteObject(maintenance) : maintenance);
        }

        public Maintenance DiagnoseAndSolutionObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidDiagnoseAndSolutionObject(maintenance) ? _repository.DiagnoseAndSolutionObject(maintenance) : maintenance);
        }

        public Maintenance DiagnoseAndSolutionObject(Maintenance maintenance, string Diagnosis, int DiagnosisCase, DateTime DiagnosisDate, string Solution, int SolutionCase)
        {
            maintenance.Diagnosis = Diagnosis;
            maintenance.DiagnosisCase = DiagnosisCase;
            maintenance.DiagnosisDate = DiagnosisDate;
            maintenance.Solution = Solution;
            maintenance.SolutionCase = SolutionCase;
            return this.DiagnoseAndSolutionObject(maintenance);
        }

        public Maintenance ConfirmObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidConfirmObject(maintenance) ? _repository.ConfirmObject(maintenance) : maintenance);
        }

        public Maintenance UnconfirmObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidUnconfirmObject(maintenance) ? _repository.UnconfirmObject(maintenance) : maintenance);
        }

        public Maintenance CancelDiagnoseAndSolutionObject(Maintenance maintenace)
        {
            return (maintenace = _validator.ValidCancelDiagnoseAndSolutionObject(maintenace) ? _repository.CancelDiagnoseAndSolutionObject(maintenace) : maintenace);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }
    }
}