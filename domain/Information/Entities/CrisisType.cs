using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class CrisisType : Data
    {

        public virtual string Name { get; set; }
        public virtual int Order { get; set; }
        public virtual ISet<Crisis> Crises { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj as CrisisType != null)
            {
                CrisisType crisisType = obj as CrisisType;
                bool temp = Guid.Equals(crisisType.Guid);
                return temp;
            }
            else
                return false;

        }
    }
}
