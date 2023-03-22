using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AgeLevel : InfoData
    {
        /// <summary>
        /// 年龄上界
        /// </summary>
        public virtual int Up { get; set; }
        /// <summary>
        /// 年龄下界
        /// </summary>
        public virtual int Down { get; set; }

        public virtual ISet<AgeLevelConfig> AgeLevelConfigs { get; set; }
    }
}
