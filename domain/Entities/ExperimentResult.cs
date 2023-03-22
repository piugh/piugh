using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExperimentResult : InfoData
    {

        public virtual Experiment Experiment { get; set; }
        public virtual ISet<SpreadInfo> SpreadInfos { get; set; }
    }
}
