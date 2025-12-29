using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public Part()
        {
            UsedParts = new List<UsedPart>();
        }
        public Part(string code,int currentQuantity, string description ,int minimumQuantity,  string unitOfMeasure, float unitPrice) : this()
        {
            this.Code = code;
            this.CurrentQuantity = currentQuantity;
            this.Description = description;
            this.MinimunQuantity = minimumQuantity;
            this.UnitPrice = unitPrice;
            this.UnitOfMeasure = unitOfMeasure;
        }
    }
}
