using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        
        public string FullName { get; set; }

        public string Id { get; set; }
        
        public string Password { get; set; }

        public virtual ICollection<Incident> ReportedIncidents { get; set;  }

    }
}
