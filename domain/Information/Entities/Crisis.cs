using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class Crisis : Data
    {

        public virtual CrisisType Type { get; set; }
        public virtual bool IsAdd { get; set; }
        /// <summary>
        /// 距征兆时间
        /// </summary>
        public virtual CrisisTimeSpan TimeSpan { get; set; }
        /// <summary>
        /// 危机等级
        /// </summary>  
        public virtual CrisisLevel Level { get; set; }
        /// <summary>
        /// 危机频率
        /// </summary>
        public virtual CrisisFrequence Frequence { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public virtual CrisisPersistentTime PersistentTime { get; set; }
        public virtual Rumor Rumor { get; set; }
    }
}
