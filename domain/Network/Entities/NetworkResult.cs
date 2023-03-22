using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain.Network.Entities
{
    public class NetworkResult : InfoData
    {

        public virtual NetworkSch NetworkSch { get; set; }
        public virtual ISet<NetNode> NetNodes { get; set; }
        public virtual ISet<NetEdge> NetEdges { get; set; }
        public virtual ISet<AgentLearningSch> AgentLearningSches { get; set; }
        public virtual ISet<Experiment> Experiments { get; set; }
    }
}
