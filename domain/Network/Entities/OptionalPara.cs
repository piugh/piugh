using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class OptionalPara : InfoData
    {

        public virtual ISet<OptionalParaConfig> OptionalParaConfigs { get; set; }
    }
}
