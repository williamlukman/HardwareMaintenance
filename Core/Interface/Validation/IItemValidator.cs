using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Validation
{
    public interface IItemValidator
    {
        Item VHasUniqueCustomer(Item item, ICustomerService _customerService);
        Item VHasItemType(Item item, IItemTypeService _itemTypeService);
        Item VHasMaintenance (Item item, IMaintenanceService _maintenanceService);
        Item VCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService);
        Item VUpdateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService, IMaintenanceService _maintenanceService);
        Item VDeleteObject(Item item, ICustomerService _customerService, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService);
        bool ValidUpdateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService, IMaintenanceService _maintenanceService);
        bool ValidDeleteObject(Item item, ICustomerService _customerService, IMaintenanceService _maintenanceService);
        bool isValid(Item item);
        string PrintError(Item item);
    }
}

    }
}
