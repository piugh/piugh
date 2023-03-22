using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class ElectroAnomaly : Data
    {

        public virtual string Name { get; set; }
        public virtual int Order { get; set; }
        public virtual ISet<ElectroConfig> ElectroConfigs { get; set; }
    }
}
