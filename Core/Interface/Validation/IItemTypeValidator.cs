using Core.DomainModel;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Validation
{
    public interface IItemTypeValidator
    {
        ItemType VName(ItemType itemType, IItemTypeService _itemTypeService);
        ItemType VHasMaintenance (ItemType itemType, IMaintenanceService _maintenanceService);
        ItemType VHasItem(ItemType itemType, IItemService _itemService);
        ItemType VCreateObject(ItemType itemType, IItemTypeService _itemTypeService);
        ItemType VUpdateObject(ItemType itemType, IItemTypeService _itemTypeService);
        ItemType VDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(ItemType itemType, IItemTypeService _itemTypeService);
        bool ValidUpdateObject(ItemType itemType, IItemTypeService _itemTypeService);
        bool ValidDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool isValid(ItemType itemType);
        string PrintError(ItemType itemType);
    }
}

    }
}
