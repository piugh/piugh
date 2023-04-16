using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class NetNode : Data
    {
        public virtual int id { get; set; }
        public virtual ISet<NetEdge> NetEdges1 { get; set; }
        public virtual ISet<NetEdge> NetEdges2 { get; set; }
        public virtual NetworkResult NetworkResult { get; set; }
        public virtual Agent AgentProperty { get; set; }
        public virtual ISet<PropositionLearningConfig> PropositionLearningConfigs { get; set; }
        public virtual ISet<RumorLearningConfig> RumorLearningConfigs { get; set; }
    }
}
