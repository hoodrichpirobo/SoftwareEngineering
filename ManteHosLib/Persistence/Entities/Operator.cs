using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Operator : Employee
    {
        public Shift Shift { get; set; } = Shift.Morning;
    
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    
    }
}
