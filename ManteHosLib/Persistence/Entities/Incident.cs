using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Incident
    {
        public int Id { get; set; }
       
        public DateTime ReportDate { get; set; }
        
        public string Department { get; set; }
       
        public string Description { get; set; }
        public Priority Priority { get; set; } = Priority.Low;
        public Status Status { get; set; } = Status.Created;
        public string RejectionReason { get; set; }
        public float CostOfUsedParts { get; set; } = 0f;
        public virtual Area Area { get; set; }
        [Required]
        public virtual Employee Reporter { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
