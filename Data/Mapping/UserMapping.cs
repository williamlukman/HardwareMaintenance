using System.Data.Entity.ModelConfiguration;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<DbUser>
    {
        public UserMapping()
        {
            HasKey(u => u.Id);
            HasMany(i => i.Maintenances);
            Ignore(c => c.Errors);
        }
    }
}