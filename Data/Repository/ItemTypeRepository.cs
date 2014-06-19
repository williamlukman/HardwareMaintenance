using Core.DomainModel;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using System.Data;

namespace Data.Repository
{
    public class ItemTypeRepository : EfRepository<ItemType>, IItemTypeRepository
    {

        private HardwareMaintenanceEntities entities;
        public ItemTypeRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<ItemType> GetAll()
        {
            return FindAll().ToList();
        }

        public ItemType GetObjectById(int Id)
        {
            ItemType itemType = Find(x => x.Id == Id && !x.IsDeleted);
            if (itemType != null) { itemType.Errors = new Dictionary<string, string>(); }
            return itemType;
        }

        public ItemType CreateObject(ItemType itemType)
        {
            itemType.IsDeleted = false;
            itemType.CreatedAt = DateTime.Now;
            return Create(itemType);
        }

        public ItemType UpdateObject(ItemType itemType)
        {
            itemType.UpdatedAt = DateTime.Now;
            Update(itemType);
            return itemType;
        }

        public ItemType SoftDeleteObject(ItemType itemType)
        {
            itemType.IsDeleted = true;
            itemType.DeletedAt = DateTime.Now;
            Update(itemType);
            return itemType;
        }

        public bool DeleteObject(int Id)
        {
            ItemType itemType = Find(x => x.Id == Id);
            return (Delete(itemType) == 1) ? true : false;
        }

    }
}