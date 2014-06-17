using Core.DomainModel;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ItemService : IItemService
    {
        private IItemRepository _repository;
        private IItemValidator _validator;
        public ItemService(IItemRepository _itemRepository, IItemValidator _itemValidator)
        {
            _repository = _itemRepository;
            _validator = _itemValidator;
        }

        public IItemValidator GetValidator()
        {
            return _validator;
        }

        public IList<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Item> GetObjectsByItemTypeId(int ItemTypeId)
        {
            return _repository.GetObjectsByItemTypeId(ItemTypeId);
        }

        public IList<Item> GetObjectsByCustomerId(int CustomerId)
        {
            return _repository.GetObjectsByCustomerId(CustomerId);
        }

        public Item GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public Item GetObjectByCode(string Code)
        {
            return _repository.FindAll(i => i.Code == Code && !i.IsDeleted).FirstOrDefault();
        }

        public Item CreateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService)
        {
            item.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(item, _customerService, _itemTypeService) ? _repository.CreateObject(item) : item);
        }

        public Item UpdateObject(Item item, ICustomerService _customerService, IItemTypeService _itemTypeService, IMaintenanceService _maintenanceService)
        {
            return (item = _validator.ValidUpdateObject(item, _customerService, _itemTypeService, _maintenanceService) ? _repository.UpdateObject(item) : item);
        }

        public Item SoftDeleteObject(Item item, ICustomerService _customerService, IMaintenanceService _maintenanceService)
        {
            return (item = _validator.ValidDeleteObject(item, _customerService, _maintenanceService) ? _repository.SoftDeleteObject(item) : item);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }
    }
}