using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InfoData : Data
    {

        public virtual string Name { get; set; }

        public virtual string CreateName { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual string Aim { get; set; }

        public virtual string Remark { get; set; }

    }
}
