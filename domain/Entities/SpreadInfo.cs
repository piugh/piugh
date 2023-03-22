using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Information.Entities;
using Domain.Network.Entities;

namespace Domain.Entities
{
    public class SpreadInfo : Data
    {

        public virtual NetNode Send { get; set; }
        public virtual NetNode Receive { get; set; }
        public virtual int Step { get; set; }
        public virtual string RumorString { get; set; }
        public virtual ExperimentResult ExperimentResult { get; set; }

        public virtual string MeanString { get; set; }
        public virtual int DetailNum
        {
            get { return new Random().Next(10, 30); }
        }
    }
}
