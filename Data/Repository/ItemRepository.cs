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
    public class ItemRepository : EfRepository<Item>, IItemRepository
    {

        private HardwareMaintenanceEntities entities;
        public ItemRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<Item> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<Item> GetObjectsByItemTypeId(int ItemTypeId)
        {
            return FindAll(x => x.ItemTypeId == ItemTypeId && !x.IsDeleted).ToList();
        }

        public IList<Item> GetObjectsByCustomerId(int CustomerId)
        {
            return FindAll(x => x.CustomerId == CustomerId && !x.IsDeleted).ToList();
        }

        public Item GetObjectById(int Id)
        {
            Item item = Find(x => x.Id == Id && !x.IsDeleted);
            if (item != null) { item.Errors = new Dictionary<string, string>(); }
            return item;
        }

        public Item CreateObject(Item item)
        {
            item.Code = SetObjectCode(item);
            item.IsDeleted = false;
            item.CreatedAt = DateTime.Now;
            return Create(item);
        }

        public Item UpdateObject(Item item)
        {
            item.UpdatedAt = DateTime.Now;
            Update(item);
            return item;
        }

        public Item SoftDeleteObject(Item item)
        {
            item.IsDeleted = true;
            item.DeletedAt = DateTime.Now;
            Update(item);
            return item;
        }

        public bool DeleteObject(int Id)
        {
            Item item = Find(x => x.Id == Id);
            return (Delete(item) == 1) ? true : false;
        }

        public string SetObjectCode(Item obj)
        {
            //Code: Customer.Id/year_created_at/month_created_at/total_item_in_that_year
            int totalobject = FindAll(x => x.CreatedAt.Year == DateTime.Now.Year).Count() + 1;
            string Code = obj.CustomerId + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + totalobject;
            return Code;
        }
    }
}