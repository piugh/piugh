using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class OptionalParaConfig : Data
    {

        public virtual OptionalPara OptionalPara { get; set; }
        public virtual NetworkModel NetworkModel { get; set; }
        public virtual ISet<ModelParaConfig> ModelParaConfigs { get; set; }
    }
}
