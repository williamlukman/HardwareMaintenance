using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModel
{
    public partial class Item
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ItemTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime ManufacturedAt { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }

        public Dictionary<string, string> Errors { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
