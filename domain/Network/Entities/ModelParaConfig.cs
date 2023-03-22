using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Network.Entities
{
    public class ModelParaConfig : Data
    {

        public virtual OptionalParaConfig OptionalParaConfig { get; set; }
        public virtual string Value { get; set; }
        public virtual ModelPara ModelPara { get; set; }
    }
}
