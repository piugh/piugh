using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class AnimalConfig : Data
    {

        public virtual OmenValue Value { get; set; }
        public virtual bool IsAdd { get; set; }
        public virtual AnimalAnomaly AnimalAnomaly { get; set; }
        public virtual Omen Omen { get; set; }
    }
}
