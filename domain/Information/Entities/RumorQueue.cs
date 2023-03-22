using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain.Information.Entities
{
    public class RumorQueue : InfoData
    {

        public virtual ISet<RumorQueueConfig> RumorQueueConfigs { get; set; }
        public virtual ISet<RumorLearningConfig> RumorLearningConfigs { get; set; }
    }
}
