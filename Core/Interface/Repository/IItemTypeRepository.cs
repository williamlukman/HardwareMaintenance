using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IItemTypeRepository : IRepository<ItemType>
    {
        IList<ItemType> GetAll();
        ItemType GetObjectById(int Id);
        ItemType CreateObject(ItemType itemType);
        ItemType UpdateObject(ItemType itemType);
        ItemType SoftDeleteObject(ItemType itemType);
        bool DeleteObject(int Id);
    }
}