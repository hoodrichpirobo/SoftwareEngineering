using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        public UsedPart() { }
        public UsedPart(int quantity, Part part)
        {
            
            this.Quantity = quantity;
            this.Part = part;

            if (this.Part.CurrentQuantity - this.Quantity < this.Part.MinimunQuantity) {
                this.Needed = true;
            } else
            {
                this.Needed = false;
                this.Part.CurrentQuantity -= this.Quantity;
            }
        }

    }
}
