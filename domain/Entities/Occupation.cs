using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Occupation : InfoData
    {

        public virtual ISet<OccupationConfig> OccupationConfigs { get; set; }
    }
}
