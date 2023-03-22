using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class CrisisPersistentTime : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Crisis> Crises { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj as CrisisPersistentTime != null)
            {
                CrisisPersistentTime crisisPersistentTime = obj as CrisisPersistentTime;
                bool temp = Guid.Equals(crisisPersistentTime.Guid);
                return temp;
            }
            else
                return false;

        }

    }
}
