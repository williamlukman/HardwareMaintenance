using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        IList<Item> GetAll();
        IList<Item> GetObjectsByItemTypeId(int ItemTypeId);
        IList<Item> GetObjectsByCustomerId(int CustomerId);
        Item GetObjectById(int Id);
        Item CreateObject(Item item);
        Item UpdateObject(Item item);
        Item SoftDeleteObject(Item item);
        bool DeleteObject(int Id);
        string SetObjectCode();
    }
}