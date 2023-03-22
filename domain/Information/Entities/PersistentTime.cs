using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class PersistentTime : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Result> Results { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj as PersistentTime != null)
            {
                PersistentTime persistentTime = obj as PersistentTime;
                bool temp = Guid.Equals(persistentTime.Guid);
                return temp;
            }
            else
                return false;

        }
    }
}
