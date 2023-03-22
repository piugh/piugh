using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LocationConfig : Data
    {

        public virtual double Value { get; set; }
        public virtual Location Location { get; set; }
        public virtual AgentSetProportion AgentSetProportion { get; set; }
    }
}
