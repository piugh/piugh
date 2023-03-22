using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Information.Entities;
using Domain.Network.Entities;

namespace Domain.Entities
{
    public class RumorLearningConfig : Data
    {

        //所属个体学习方案
        public virtual AgentLearningSch AgentLearningSch { get; set; }
        //对应网络节点
        public virtual NetNode NetNode { get; set; }
        //对应谣言队列
        public virtual RumorQueue RumorQueue { get; set; }
    }
}
