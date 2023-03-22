using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class ClimateAnomaly : Data
    {

        public virtual string Name { get; set; }
        public virtual int Order { get; set; }
        public virtual ISet<ClimateConfig> ClimateConfigs { get; set; }
    }
}
