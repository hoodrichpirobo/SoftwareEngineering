using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Operator
    {

        public Operator() {
            WorkOrders =  new List <WorkOrder>();
         }
        public Operator(string fullname, string id, string password, Shift shift) : base(fullname, id, password)
        {
            // Initialize collection for the second time  due to the inheritance 
            this.WorkOrders = new List<WorkOrder>();
            this.Shift = shift;
        }
    }
}
