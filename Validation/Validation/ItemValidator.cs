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
    public class ItemValidator : IItemValidator
    {

        public Item VHasUniqueCustomer(Item item, ICustomerService _customerService)
        {
            Customer customer = _customerService.GetObjectById(item.CustomerId);
            if (customer == null)
            {
                item.Errors.Add("Customer", "Tidak boleh tidak ada");
            }
            if (_customerService.IsNameDuplicated(customer))
            {
                item.Errors.Add("Customer", "Tidak boleh diduplikasi");
            }
            return item;
        }

        public Item VHasItemType(Item item, IItemTypeService _itemTypeService)
        {
            ItemType itemType = _itemTypeService.GetObjectById(item.ItemTypeId);
            if (itemType == null)
            {
                item.Errors.Add("ItemType", "Tidak boleh tidak ada");
            }
            return item;
        }

        public Item VUpdateTypeIdHasMaintenance(Item item, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            IList<Maintenance> maintenances = _maintenanceService.GetObjectsByItemId(item.Id);
            if (maintenances.Any())
            {
                Item databaseitem = _itemService.GetObjectById(item.Id);
                if (databaseitem.Id == item.Id && databaseitem.ItemTypeId != item.ItemTypeId)
                {
                    item.Errors.Add("ItemTypeId", "Tidak boleh diubah jika terasosiasi dengan maintenance");
                }
            }
            return item;
        }

        public Item VHasMaintenance(Item item, IMaintenanceService _maintenanceService)
        {
            IList<Maintenance> maintenances = _maintenanceService.GetObjectsByItemId(item.Id);
            if (maintenances.Any())
            {
                item.Errors.Add("Maintenances", "Tidak boleh terasosiasi dengan maintenance");
            }
            return item;
        }

        public Item VUpdateCustomer(Item item, IItemService _itemService)
        {
            Item databaseitem = _itemService.GetObjectById(item.Id);
            if (databaseitem.Id == item.Id && databaseitem.CustomerId != item.CustomerId)
            {
                item.Errors.Add("ItemId", "Tidak boleh diubah");
            }
            return item;
        }


        public Item VCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService)
        {
            VHasUniqueCustomer(item, _customerService);
            VHasItemType(item, _itemTypeService);
            return item;
        }

        public Item VUpdateObject(Item item, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            VUpdateTypeIdHasMaintenance(item, _itemService, _maintenanceService);
            VUpdateCustomer(item, _itemService);
            return item;
        }

        public Item VDeleteObject(Item item, IMaintenanceService _maintenanceService)
        {
            VHasMaintenance(item, _maintenanceService);
            return item;
        }

        public bool ValidCreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService)
        {
            VCreateObject(item, _customerService, _itemTypeService);
            return isValid(item);
        }

        public bool ValidUpdateObject(Item item, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            item.Errors.Clear();
            VUpdateObject(item, _itemService, _maintenanceService);
            return isValid(item);
        }

        public bool ValidDeleteObject(Item item, IMaintenanceService _maintenanceService)
        {
            item.Errors.Clear();
            VDeleteObject(item, _maintenanceService);
            return isValid(item);
        }

        public bool isValid(Item obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(Item obj)
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
