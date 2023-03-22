using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Information.Entities;
using Domain.Network.Entities;

namespace Domain.Entities
{
    public class Experiment : InfoData
    {
        public virtual AgentSet AgentSet { get; set; }
        public virtual Rumor Rumor { get; set; }
        public virtual NetworkResult NetworkResult { get; set; }
        public virtual AgentLearningSch AgentLearningSch { get; set; }
        public virtual ISet<ExperimentResult> ExperimentResults { get; set; }
    }
}
