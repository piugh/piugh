using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EduLevel : InfoData
    {
        public virtual ISet<EduLevelConfig> EduLevelConfigs { get; set; }
    }
}
