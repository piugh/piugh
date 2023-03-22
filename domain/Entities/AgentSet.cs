using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Network.Entities;

namespace Domain.Entities
{
    public class AgentSet : InfoData
    {
        //对象私有变量
        private AgentSetProportion _proportion;

        public virtual AgentSetProportion Proportion
        {
            get { return _proportion; }
            set { _proportion = value; }
        }

        public virtual ISet<Agent> Agents { get; set; }

        public virtual ISet<NetworkSch> NetworkSches { get; set; }

        public virtual ISet<Experiment> Experiments { get; set; }
    }
}
