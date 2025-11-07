using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Incident
    {
        public Incident()
        {
            
        }

        public Incident(string Department, string Description,DateTime ReportDate, Employee Reporter) : this()
        {
           
            this.Department = Department;
            this.Description = Description;
            this.ReportDate = ReportDate;
            this.Reporter = Reporter;
        }
    }
}
