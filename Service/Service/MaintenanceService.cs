﻿using Core.DomainModel;
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
                                  IUserService _userService)
        {
            maintenance.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(maintenance, _itemService, _itemTypeService, _userService) ? _repository.CreateObject(maintenance) : maintenance);
        }

        public Maintenance UpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, IMaintenanceService _maintenanceService)
        {
            return (maintenance = _validator.ValidUpdateObject(maintenance, _itemService, _itemTypeService, _userService, _maintenanceService) ? _repository.UpdateObject(maintenance) : maintenance);
        }

        public Maintenance SoftDeleteObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidDeleteObject(maintenance) ? _repository.SoftDeleteObject(maintenance) : maintenance);
        }

        public Maintenance DiagnoseAndSolutionObject(Maintenance maintenance)
        {
            return (maintenance = _validator.ValidDiagnoseAndSolutionObject(maintenance) ? _repository.DiagnoseAndSolutionObject(maintenance) : maintenance);
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