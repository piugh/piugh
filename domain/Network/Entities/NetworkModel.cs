using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class NetworkModel : InfoData
    {

        public virtual ISet<NetworkSch> NetworkSches { get; set; }
        public virtual ISet<OptionalParaConfig> OptionalParaConfigs { get; set; }
        public virtual ISet<ModelPara> ModelParas { get; set; }
    }
}
