using NHibernate.Bytecode.Lightweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class OmenValue : Data
    {

        public virtual string Name { get; set; }
        public virtual string EumBinary { get; set; }
        public virtual ISet<AnimalConfig> AnimalConfigs { get; set; }
        public virtual ISet<ClimateConfig> ClimateConfigs { get; set; }
        public virtual ISet<ElectroConfig> ElectroConfigs { get; set; }
        public virtual ISet<GroundConfig> GroundConfigs { get; set; }
        public virtual ISet<GroundwaterConfig> GroundwaterConfigs { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //


            // TODO: write your implementation of Equals() here
            if (obj as OmenValue != null)
            {
                OmenValue omenValue = obj as OmenValue;
                bool temp = EumBinary.Equals(omenValue.EumBinary);
                return temp;
            }
            else
                return false;


            //if (obj != null && obj is object)
            //{
            //    OmenValue omenValue = obj as OmenValue;

            //    if (obj is OmenValue)
            //    {
            //        bool temp = EumBinary.Equals(omenValue.EumBinary);
            //        return temp;
            //    }
            //    else
            //        return false;
            //}

        }
    }
}
