using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Master
    {
        public Master() { }
        public Master(string fullname, string id, string password) :base(fullname, id, password) { }
    }
}
