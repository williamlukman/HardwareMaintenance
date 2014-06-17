using Core.DomainModel;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface IItemTypeService
    {
        IItemTypeValidator GetValidator();
        IList<ItemType> GetAll();
        ItemType GetObjectById(int Id);
        ItemType GetObjectByName(string Name);
        ItemType CreateObject(ItemType itemType);
        ItemType CreateObject(string Name, string Description);
        ItemType UpdateObject(ItemType itemType);
        ItemType SoftDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService);
        bool DeleteObject(int Id);
    }
}