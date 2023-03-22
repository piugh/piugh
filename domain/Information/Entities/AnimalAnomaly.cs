using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class AnimalAnomaly : Data
    {

        public virtual string Name { get; set; }
        public virtual int Order { get; set; }
        public virtual ISet<AnimalConfig> AnimalConfigs { get; set; }

        public override bool Equals(object? obj)
        {
            return Guid.Equals((obj as AnimalAnomaly).Guid);
        }
    }
}
