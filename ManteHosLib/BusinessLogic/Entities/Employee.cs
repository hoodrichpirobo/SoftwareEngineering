using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            ReportedIncidents = new List<Incident>();
        }

        public Employee(string fullName,string id ,string Password) : this()
        {
            this.FullName = fullName;
            this.Id=id;
            this.Password = Password;
        }
    }
}
