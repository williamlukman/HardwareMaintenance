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
        ItemType VName(ItemType itemType);
        ItemType VHasMaintenance (ItemType itemType, IMaintenanceService _maintenanceService);
        ItemType VHasItem(ItemType itemType, IItemService _itemService);
        ItemType VCreateObject(ItemType itemType);
        ItemType VUpdateObject(ItemType itemType);
        ItemType VDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool ValidCreateObject(ItemType itemType);
        bool ValidUpdateObject(ItemType itemType);
        bool ValidDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool isValid(ItemType itemType);
        string PrintError(ItemType itemType);
    }
}

    }
}
