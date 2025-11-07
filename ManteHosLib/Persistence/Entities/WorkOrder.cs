using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public int Id { get; set; }
        
        
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public String RepairReport { get; set; }
        [Required]
        public virtual Incident Incident { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
        public virtual ICollection<UsedPart> UsedParts { get; set; }
    }
}
