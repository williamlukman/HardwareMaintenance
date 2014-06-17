using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Validation
{
    public interface ICustomerValidator
    {
        Customer VName(Customer customer, ICustomerService _customerService);
        Customer VHasMaintenance (Customer customer, IMaintenanceService _maintenanceService);
        Customer VHasItem(Customer customer, IItemService _itemService);
        Customer VCreateObject(Customer customer, ICustomerService _customerService);
        Customer VUpdateObject(Customer customer, ICustomerService _customerService);
        Customer VDeleteObject(Customer customer, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(Customer customer, ICustomerService _customerService);
        bool ValidUpdateObject(Customer customer, ICustomerService _customerService);
        bool ValidDeleteObject(Customer customer, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool isValid(Customer customer);
        string PrintError(Customer customer);
    }
}