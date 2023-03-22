using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class InfluenceScope : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Result> Results { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj as InfluenceScope != null)
            {
                InfluenceScope influenceScope = obj as InfluenceScope;
                bool temp = Guid.Equals(influenceScope.Guid);
                return temp;
            }
            else
                return false;

        }
    }
}
