using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class MaintenanceMapping : EntityTypeConfiguration<Maintenance>
    {
        public MaintenanceMapping()
        {
            HasKey(m => m.Id);
            HasRequired(m => m.Item)
                .WithMany(i => i.Maintenances)
                .WillCascadeOnDelete(false);
            HasRequired(m => m.ItemType)
                .WithMany(it => it.Maintenances)
                .WillCascadeOnDelete(false);
            HasRequired(m => m.Customer)
                .WithMany(c => c.Maintenances)
                .WillCascadeOnDelete(false);
            HasRequired(m => m.DbUser)
                .WithMany(u => u.Maintenances)
                .WillCascadeOnDelete(false);
            Ignore(m => m.Errors);
        }
    }
}