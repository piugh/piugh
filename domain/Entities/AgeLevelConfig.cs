using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AgeLevelConfig : Data
    {
        public virtual double Value { get; set; }
        public virtual double WomenProportion { get; set; }
        public virtual double MenProportion { get; set; }
        public virtual AgeLevel AgeLevel { get; set; }
        public virtual EduLevelConfig EduLevelConfig { get; set; }
        public virtual AgentSetProportion AgentSetProportion { get; set; }
    }
}
