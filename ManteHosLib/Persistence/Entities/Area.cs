using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        [Required]
        public virtual Master Master { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
