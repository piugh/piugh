using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class RumorQueueConfig : Data
    {

        public virtual Rumor Rumor { get; set; }
        public virtual RumorQueue RumorQueue { get; set; }
        public virtual int Ordinal { get; set; }
    }
}
