using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class Proposition : InfoData
    {

        public virtual string EumBinary { get; set; }
        /// <summary>
        /// 行动
        /// </summary>
        public virtual Action Action { get; set; }
        /// <summary>
        /// 愿望
        /// </summary>
        public virtual Aspiration Aspiration { get; set; }
        /// <summary>
        /// 环境
        /// </summary>
        public virtual Environment Environment { get; set; }
        /// <summary>
        /// 态度
        /// </summary>
        public virtual bool Attitude { get; set; }
        public virtual Rumor Rumor { get; set; }
        public virtual ISet<PropositionQueueConfig> PropositionQueueConfigs { get; set; }
    }
}
