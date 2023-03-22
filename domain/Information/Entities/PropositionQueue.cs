using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain.Information.Entities
{
    public class PropositionQueue : InfoData
    {

        public virtual ISet<PropositionQueueConfig> PropositionQueueConfigs { get; set; }
        public virtual ISet<PropositionLearningConfig> PropositionLearningConfigs { get; set; }
    }
}
