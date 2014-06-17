using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class ItemTypeMapping : EntityTypeConfiguration<ItemType>
    {
        public ItemTypeMapping()
        {
            HasKey(it => it.Id);
            HasMany(it => it.Items);
            HasMany(it => it.Maintenances);
            Ignore(c => c.Errors);
        }
    }
}