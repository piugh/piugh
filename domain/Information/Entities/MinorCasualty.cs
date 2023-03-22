using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class MinorCasualty : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<Result> Results { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj as MinorCasualty != null)
            {
                MinorCasualty minorCasualty = obj as MinorCasualty;
                bool temp = Guid.Equals(minorCasualty.Guid);
                return temp;
            }
            else
                return false;

        }
    }
}
