using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class Omen : Data
    {

        /// <summary>
        /// 生物异常信息
        /// </summary>
        public virtual ISet<AnimalConfig> AnimalConfigs { get; set; }
        /// <summary>
        /// 气候异常信息
        /// </summary>
        public virtual ISet<ClimateConfig> ClimateConfigs { get; set; }
        /// <summary>
        /// 电磁异常信息
        /// </summary>
        public virtual ISet<ElectroConfig> ElectroConfigs { get; set; }
        /// <summary>
        /// 地面异常信息
        /// </summary>
        public virtual ISet<GroundConfig> GroundConfigs { get; set; }
        /// <summary>
        /// 地下水异常信息
        /// </summary>
        public virtual ISet<GroundwaterConfig> GroundwaterConfigs { get; set; }
        /// <summary>
        /// 所属谣言
        /// </summary>
        public virtual Rumor Rumor { get; set; }
    }
}
