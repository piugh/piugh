using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Information.Entities;
using Domain;
using Domain.Network.Entities;

namespace Domain.Entities
{
    public class AgentLearningSch : InfoData
    {

        public virtual NetworkResult NetworkResult { get; set; }
        public virtual ISet<RumorLearningConfig> RumorLearningConfigs { get; set; }
        public virtual ISet<PropositionLearningConfig> PropositionLearningConfigs { get; set; }
        public virtual ISet<Experiment> Experiments { get; set; }
    }
}
