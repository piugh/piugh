using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class CrisisLevel : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Crisis> Crises { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj as CrisisLevel != null)
            {
                CrisisLevel crisisLevel = obj as CrisisLevel;
                bool temp = Guid.Equals(crisisLevel.Guid);
                return temp;
            }
            else
                return false;
        }
    }

}
