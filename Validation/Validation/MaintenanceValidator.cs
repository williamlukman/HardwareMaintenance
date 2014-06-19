using Core.DomainModel;
using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Core.Constants;

namespace Validation.Validation
{
    public class MaintenanceValidator : IMaintenanceValidator
    {

        public Maintenance VHasItem(Maintenance maintenance, IItemService _itemService, ICustomerService _customerService)
        {
            Item item = _itemService.GetObjectById(maintenance.ItemId);
            if (item == null)
            {
                maintenance.Errors.Add("Item", "Tidak boleh tidak ada");
            }
            Customer customer = _customerService.GetObjectById(item.CustomerId);
            if (customer == null)
            {
                maintenance.Errors.Add("Customer", "Tidak boleh tidak ada");
            }
            if (customer.Id != maintenance.CustomerId)
            {
                maintenance.Errors.Add("CustomerId", "Tidak boleh berbeda dengan customerId dari item");
            }
            return maintenance;
        }

        public Maintenance VHasCustomer(Maintenance maintenance, ICustomerService _customerService)
        {
            Customer customer = _customerService.GetObjectById(maintenance.CustomerId);
            if (customer == null)
            {
                maintenance.Errors.Add("Customer", "Tidak boleh tidak ada");
            }
            return maintenance;
        }

        public Maintenance VHasItemTypeByItem(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService)
        {
            Item item = _itemService.GetObjectById(maintenance.ItemId);
            ItemType itemType = _itemTypeService.GetObjectById(item.ItemTypeId);
            if (itemType == null)
            {
                maintenance.Errors.Add("ItemType", "Tidak boleh tidak ada");
            }
            return maintenance;
        }

        public Maintenance VHasItemType(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService)
        {
            ItemType itemType = _itemTypeService.GetObjectById(maintenance.ItemTypeId);
            if (itemType == null)
            {
                VHasItemTypeByItem(maintenance, _itemService, _itemTypeService);
            }
            return maintenance;
        }

        public Maintenance VHasUser(Maintenance maintenance, IUserService _userService)
        {
            DbUser user = _userService.GetObjectById(maintenance.UserId);
            if (user == null)
            {
                maintenance.Errors.Add("DbUser", "Tidak boleh tidak ada");
            }
            return maintenance;
        }

        public Maintenance VHasRequestDate(Maintenance maintenance)
        {
            // RequestDate will never be null
            return maintenance;
        }

        public Maintenance VHasComplaint(Maintenance maintenance)
        {
            if (String.IsNullOrEmpty(maintenance.Complaint) || maintenance.Complaint.Trim() == "")
            {
                maintenance.Errors.Add("Complaint", "Tidak boleh kosong");
            }
            return maintenance;
        }

        public Maintenance VHasCase(Maintenance maintenance)
        {
            if (maintenance.Case != Constant.MaintenanceCase.Scheduled &&
                maintenance.Case != Constant.MaintenanceCase.Emergency)
            {
                maintenance.Errors.Add("Case", "Can only select Scheduled And Emergency");
            }
            return maintenance;
        }

        public Maintenance VNotFinished(Maintenance maintenance)
        {
            if (maintenance.IsFinished)
            {
                maintenance.Errors.Add("IsFinished", "Tidak boleh sudah dikonfirmasi");
            }
            return maintenance;
        }

        public Maintenance VIsFinished(Maintenance maintenance)
        {
            if (!maintenance.IsFinished)
            {
                maintenance.Errors.Add("IsFinished", "Belum dikonfirmasi");
            }
            return maintenance;
        }


        public Maintenance VUpdateCustomer(Maintenance maintenance, IMaintenanceService _maintenanceService)
        {
            Maintenance databasemaintenance = _maintenanceService.GetObjectById(maintenance.Id);
            if (maintenance.CustomerId != databasemaintenance.CustomerId)
            {
                maintenance.Errors.Add("CustomerId", "Tidak boleh diubah");
            }
            return maintenance;
        }

        public Maintenance VNotDiagnosed(Maintenance maintenance)
        {
            if (maintenance.IsDiagnosed)
            {
                maintenance.Errors.Add("IsDiagnosed", "Tidak boleh sudah di diagnosa");
            }
            return maintenance;
        }

        public Maintenance VIsDiagnosed(Maintenance maintenance)
        {
            if (!maintenance.IsDiagnosed)
            {
                maintenance.Errors.Add("IsDiagnosed", "Belum di diagnosa");
            }
            return maintenance;
        }

        public Maintenance VHasDiagnosis(Maintenance maintenance)
        {
            String diagnosis = maintenance.Diagnosis;
            if (String.IsNullOrEmpty(diagnosis) || diagnosis.Trim() == "")
            {
                maintenance.Errors.Add("Diagnosis", "Tidak boleh kosong");
            }
            return maintenance;
        }

        public Maintenance VHasDiagnosisCase(Maintenance maintenance)
        {
            if (maintenance.DiagnosisCase == null)
            {
                maintenance.Errors.Add("DiagnosisCase", "Tidak boleh tidak ada");
                return maintenance;
            }
            if (maintenance.DiagnosisCase != Constant.DiagnosisCase.All_Ok &&
                maintenance.DiagnosisCase != Constant.DiagnosisCase.Fix_Required &&
                maintenance.DiagnosisCase != Constant.DiagnosisCase.Replacement_Required)
            {
                maintenance.Errors.Add("DiagnosisCase", "Can only select All_Ok, Fix_Required, and Replacement_Required");
            }
            return maintenance;
        }

        public Maintenance VHasDiagnosisDate(Maintenance maintenance)
        {
            if (maintenance.DiagnosisDate == null)
            {
                maintenance.Errors.Add("DiagnosisDate", "Tidak boleh tidak ada");
            }
            return maintenance;
        }

        public Maintenance VHasSolution(Maintenance maintenance)
        {
            String solution = maintenance.Solution;
            if (String.IsNullOrEmpty(solution) || solution.Trim() == "")
            {
                maintenance.Errors.Add("Solution", "Tidak boleh kosong");
            }
            return maintenance;
        }

        public Maintenance VHasSolutionCase(Maintenance maintenance)
        {
            if (maintenance.SolutionCase == null)
            {
                maintenance.Errors.Add("SolutionCase", "Tidak boleh tidak ada");
                return maintenance;
            }
            if (maintenance.SolutionCase != Constant.SolutionCase.Normal &&
                maintenance.SolutionCase != Constant.SolutionCase.Pending &&
                maintenance.SolutionCase != Constant.SolutionCase.Solved)
            {
                maintenance.Errors.Add("SolutionCase", "Can only select Normal, Pending, or Solved");
            }
            return maintenance;
        }

        public Maintenance VCreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService)
        {
            VHasItem(maintenance, _itemService, _customerService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasCustomer(maintenance, _customerService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasItemType(maintenance, _itemService, _itemTypeService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasUser(maintenance, _userService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasRequestDate(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasComplaint(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasCase(maintenance);
            return maintenance;
        }

        public Maintenance VUpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService)
        {
            VNotFinished(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasItem(maintenance, _itemService, _customerService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VUpdateCustomer(maintenance, _maintenanceService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasItemType(maintenance, _itemService, _itemTypeService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasUser(maintenance, _userService);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasRequestDate(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasComplaint(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasCase(maintenance);
            return maintenance;
        }
        public Maintenance VDeleteObject(Maintenance maintenance)
        {
            VNotDiagnosed(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VNotFinished(maintenance);
            return maintenance;
        }

        public Maintenance VDiagnoseAndSolutionObject(Maintenance maintenance)
        {
            VHasDiagnosis(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasDiagnosisCase(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasDiagnosisDate(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasSolution(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VHasSolutionCase(maintenance);
            return maintenance;
        }

        public Maintenance VConfirmObject(Maintenance maintenance)
        {
            VIsDiagnosed(maintenance);
            return maintenance;
        }

        public Maintenance VUnconfirmObject(Maintenance maintenance)
        {
            VIsFinished(maintenance);
            return maintenance;
        }

        public Maintenance VCancelDiagnoseAndSolutionObject(Maintenance maintenance)
        {
            VIsDiagnosed(maintenance);
            if (maintenance.Errors.Any()) { return maintenance; }
            VNotFinished(maintenance);
            return maintenance;
        }

        public bool ValidCreateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService)
        {
            VCreateObject(maintenance, _itemService, _itemTypeService, _userService, _customerService);
            return isValid(maintenance);
        }

        public bool ValidUpdateObject(Maintenance maintenance, IItemService _itemService, IItemTypeService _itemTypeService,
                                  IUserService _userService, ICustomerService _customerService, IMaintenanceService _maintenanceService)
        {
            maintenance.Errors.Clear();
            VUpdateObject(maintenance, _itemService, _itemTypeService, _userService, _customerService, _maintenanceService);
            return isValid(maintenance);
        }

        public bool ValidDeleteObject(Maintenance maintenance)
        {
            maintenance.Errors.Clear();
            VDeleteObject(maintenance);
            return isValid(maintenance);
        }

        public bool ValidDiagnoseAndSolutionObject(Maintenance maintenance)
        {
            maintenance.Errors.Clear();
            VDiagnoseAndSolutionObject(maintenance);
            return isValid(maintenance);
        }

        public bool ValidConfirmObject(Maintenance maintenance)
        {
            maintenance.Errors.Clear();
            VConfirmObject(maintenance);
            return isValid(maintenance);
        }

        public bool ValidUnconfirmObject(Maintenance maintenance)
        {
            maintenance.Errors.Clear();
            VUnconfirmObject(maintenance);
            return isValid(maintenance);
        }

        public bool ValidCancelDiagnoseAndSolutionObject(Maintenance maintenance)
        {
            maintenance.Errors.Clear();
            VCancelDiagnoseAndSolutionObject(maintenance);
            return isValid(maintenance);
        }

        public bool isValid(Maintenance obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Maintenance obj)
        {
            string erroroutput = "";
            KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            erroroutput += first.Key + "," + first.Value;
            foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            {
                erroroutput += Environment.NewLine;
                erroroutput += pair.Key + "," + pair.Value;
            }
            return erroroutput;
        }

    }
}
