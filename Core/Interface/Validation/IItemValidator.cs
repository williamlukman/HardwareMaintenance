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
        Item VHasTypeId(Item item, IItemTypeService _itemTypeService);
        Item VUpdateTypeIdHasMaintenance(Item item, IItemService _itemService, IMaintenanceService _maintenanceService);
        Item VHasMaintenance (Item item, IMaintenanceService _maintenanceService);
        Item VUpdateCustomer(Item item, IItemService _itemService);

        Item VCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService);
        Item VUpdateObject(Item item, IItemService _itemService, IMaintenanceService _maintenanceService);
        Item VDeleteObject(Item item, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService);
        bool ValidUpdateObject(Item item, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool ValidDeleteObject(Item item, IMaintenanceService _maintenanceService);
        bool isValid(Item item);
        string PrintError(Item item);
    }
}

    }
}
