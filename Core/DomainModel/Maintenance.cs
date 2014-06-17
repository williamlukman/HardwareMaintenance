using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainModel
{
    public partial class Maintenance
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Complaint { get; set; }
        public int Case { get; set; }
        public string Code { get; set; }
        public bool IsDiagnosed { get; set; }
        public Nullable<string> Diagnosis { get; set; }
        public Nullable<int> DiagnosisCase { get; set; }
        public Nullable<DateTime> DiagnosisDate { get; set; }
        public Nullable<string> Solution { get; set; }
        public Nullable<int> SolutionCase { get; set; }
        public Nullable<DateTime> FinishDate { get; set; }
        public bool IsFinished { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }

        public Dictionary<string, string> Errors { get; set; }

        public virtual Item Item { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}
