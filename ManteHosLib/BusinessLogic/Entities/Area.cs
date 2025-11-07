using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public Area() {
            Incidents = new List<Incident>();
        }
        public Area(string Name, Master Master) : this() {
            this.Name = Name;
            this.Master = Master;
        }
    }
}
