using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class ModelPara : InfoData
    {

        public virtual ISet<ModelParaConfig> ModelParaConfigs { get; set; }
        public virtual ISet<NetworkSch> NetworkSches { get; set; }
        public virtual NetworkModel NetworkModel { get; set; }
    }
}
