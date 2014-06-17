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
    public class ItemTypeService : IItemTypeService
    {
        private IItemTypeRepository _repository;
        private IItemTypeValidator _validator;
        public ItemTypeService(IItemTypeRepository _itemTypeRepository, IItemTypeValidator _itemTypeValidator)
        {
            _repository = _itemTypeRepository;
            _validator = _itemTypeValidator;
        }

        public IItemTypeValidator GetValidator()
        {
            return _validator;
        }

        public IList<ItemType> GetAll()
        {
            return _repository.GetAll();
        }

        public ItemType GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public ItemType GetObjectByName(string name)
        {
            return _repository.FindAll(c => c.Name == name && !c.IsDeleted).FirstOrDefault();
        }

        public ItemType CreateObject(string Name, string Description)
        {
            ItemType itemType = new ItemType
            {
                Name = Name,
                Description = Description
            };
            return this.CreateObject(itemType);
        }

        public ItemType CreateObject(ItemType itemType)
        {
            itemType.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(itemType) ? _repository.CreateObject(itemType) : itemType);
        }

        public ItemType UpdateObject(ItemType itemType)
        {
            return (itemType = _validator.ValidUpdateObject(itemType) ? _repository.UpdateObject(itemType) : itemType);
        }

        public ItemType SoftDeleteObject(ItemType itemType, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            return (itemType = _validator.ValidDeleteObject(itemType, _itemService, _maintenanceService) ? _repository.SoftDeleteObject(itemType) : itemType);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }
    }
}