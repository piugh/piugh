using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class NetEdge : Data
    {

        public virtual NetNode Node1 { get; set; }
        public virtual NetNode Node2 { get; set; }
        public virtual NetworkResult NetworkResult { get; set; }
    }
}
