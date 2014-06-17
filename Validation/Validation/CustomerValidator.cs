using Core.DomainModel;
using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Validation.Validation
{
    public class CustomerValidator : ICustomerValidator
    {

        public Customer VName(Customer customer, ICustomerService _customerService)
        {
            if (String.IsNullOrEmpty(customer.Name) || customer.Name.Trim() == "")
            {
                customer.Errors.Add("Name", "Tidak boleh kosong");
            }
            if (_customerService.IsNameDuplicated(customer))
            {
                customer.Errors.Add("Name", "Tidak boleh ada duplikasi");
            }
            return customer;
        }

        public Customer VHasMaintenance(Customer customer, IMaintenanceService _maintenanceService)
        {
            IList<Maintenance> list = _maintenanceService.GetObjectsByCustomerId(customer.Id);
            if (list.Any())
            {
                customer.Errors.Add("Maintenance", "Tidak boleh ada yang terasosiakan dengan customer");
            }
            return customer;
        }

        public Customer VHasItem(Customer customer, IItemService _itemService)
        {
            IList<Item> list = _itemService.GetObjectsByCustomerId(customer.Id);
            if (list.Any())
            {
                customer.Errors.Add("Item", "Tidak boleh ada yang terasosiakan dengan customer");
            }
            return customer;
        }

        public Customer VCreateObject(Customer customer, ICustomerService _customerService)
        {
            VName(customer, _customerService);
            return customer;
        }

        public Customer VUpdateObject(Customer customer, ICustomerService _customerService)
        {
            VName(customer, _customerService);
            return customer;
        }

        public Customer VDeleteObject(Customer customer, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            VHasMaintenance(customer, _maintenanceService);
            if (customer.Errors.Any()) { return customer; }
            VHasItem(customer, _itemService);
            return customer;
        }

        public bool ValidCreateObject(Customer customer, ICustomerService _customerService)
        {
            VCreateObject(customer, _customerService);
            return isValid(customer);
        }

        public bool ValidUpdateObject(Customer customer, ICustomerService _customerService)
        {
            customer.Errors.Clear();
            VUpdateObject(customer, _customerService);
            return isValid(customer);
        }

        public bool ValidDeleteObject(Customer customer, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            customer.Errors.Clear();
            VDeleteObject(customer, _itemService, _maintenanceService);
            return isValid(customer);
        }

        public bool isValid(Customer obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Customer obj)
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
