using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {

        public WorkOrder()
        {
            Operators = new List<Operator>();
            UsedParts = new List<UsedPart>();
        }

        public WorkOrder(DateTime startDate, Incident incident) : this()
        {
            this.EndDate = null;

            this.StartDate = startDate;

            this.Incident = incident; // cardinality 1

        }

        public UsedPart AddUsedPart(int aQuantity, Part aPart)
        {
            UsedPart uP = new UsedPart(aQuantity, aPart);
            UsedParts.Add(uP);
            return uP; 
        }

        public void AddOperator(Operator op1)
        {
            if (!Operators.Contains(op1)) 
                Operators.Add(op1);
        }
    }
}
