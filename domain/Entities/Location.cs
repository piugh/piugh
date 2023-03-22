using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location : InfoData
    {

        //描述一个方形区域
        public virtual int LongitudeUpper { get; set; }
        public virtual int LongitudeLower { get; set; }
        public virtual int LatitudeUpper { get; set; }
        public virtual int LatitudeLower { get; set; }
        public virtual ISet<LocationConfig> LocationConfigs { get; set; }
    }
}
