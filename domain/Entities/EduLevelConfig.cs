using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EduLevelConfig : Data
    {
        public virtual double Value { get; set; }
        public virtual EduLevel EduLevel { get; set; }
        public virtual OccupationConfig OccupationConfig { get; set; }
        public virtual AgentSetProportion AgentSetProportion { get; set; }
        public virtual ISet<AgeLevelConfig> AgeLevelConfigs { get; set; }
    }
}
