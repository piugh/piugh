using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain.Network.Entities
{
    public class NetworkSch : InfoData
    {

        public virtual ModelPara ModelPara { get; set; }
        public virtual NetworkModel NetworkModel { get; set; }
        public virtual ISet<NetworkResult> NetworkResults { get; set; }
        public virtual AgentSet AgentSet { get; set; }
    }
}
