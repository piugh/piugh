using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OccupationConfig : Data
    {

        public virtual double Value { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual AgentSetProportion AgentSetProportion { get; set; }
        public virtual ISet<EduLevelConfig> EduLevelConfigs { get; set; }
    }
}
