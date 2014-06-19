using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(c => c.Id);
            HasMany(c => c.Items)
                .WithRequired(i => i.Customer)
                .HasForeignKey(i => i.CustomerId);
            Ignore(c => c.Errors);
        }
    }
}