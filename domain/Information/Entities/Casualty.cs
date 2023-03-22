using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class Casualty : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Result> Results { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj as Casualty != null)
            {
                Casualty casualty = obj as Casualty;
                bool temp = Guid.Equals(casualty.Guid);
                return temp;
            }
            else
                return false;

        }
    }
}
