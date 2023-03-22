using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class PropositionQueueConfig : Data
    {

        public virtual Proposition Proposition { get; set; }
        public virtual PropositionQueue PropositionQueue { get; set; }
        public virtual int Ordinal { get; set; }
    }
}
