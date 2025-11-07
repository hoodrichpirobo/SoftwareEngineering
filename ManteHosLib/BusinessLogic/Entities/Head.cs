using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Head
    {
        public Head() { }  //no collections 
        
        public Head(string fullname, string id, string password):base(fullname, id, password)
        {
                //nothing to be initialized 
        }
    }
}
