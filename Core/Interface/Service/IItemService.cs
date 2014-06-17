using Core.DomainModel;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface IItemService
    {
        IItemValidator GetValidator();
        IList<Item> GetAll();
        IList<Item> GetObjectsByItemTypeId(int ItemTypeId);
        IList<Item> GetObjectsByCustomerId(int CustomerId);
        Item GetObjectById(int Id);
        Item GetObjectByCode(string Code);
        Item CreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService);
        Item UpdateObject(Item item, IItemService _itemService, IMaintenanceService _maintenanceService);
        Item SoftDeleteObject(Item item, IMaintenanceService _maintenanceService);
        bool DeleteObject(int Id);
    }
}