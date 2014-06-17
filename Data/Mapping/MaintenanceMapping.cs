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
                .HasForeignKey(m => m.ItemId);
            HasRequired(m => m.ItemType)
                .WithMany(it => it.Maintenances)
                .HasForeignKey(m => m.ItemTypeId);
            HasRequired(m => m.Customer)
                .WithMany(c => c.Maintenances)
                .HasForeignKey(m => m.CustomerId);
            HasRequired(m => m.User)
                .WithMany(u => u.Maintenances)
                .HasForeignKey(m => m.UserId);
            Ignore(m => m.Errors);
        }
    }
}