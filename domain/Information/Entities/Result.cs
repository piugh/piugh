using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Information.Entities
{
    public class Result : Data
    {

        /// <summary>
        /// 人员伤亡
        /// </summary>
        public virtual Casualty Casualty { get; set; }
        /// <summary>
        /// 未成年人伤亡
        /// </summary>
        public virtual MinorCasualty MinorCasualty { get; set; }
        /// <summary>
        /// 建筑物损失
        /// </summary>
        public virtual BuildingLoss BuildingLoss { get; set; }
        /// <summary>
        /// 经济损失
        /// </summary>
        public virtual EconomyLoss EconomyLoss { get; set; }
        /// <summary>
        /// 日常生活影响
        /// </summary>
        public virtual ImpactOfDaily ImpactOfDaily { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public virtual PersistentTime PersistentTime { get; set; }
        /// <summary>
        /// 影响范围
        /// </summary>
        public virtual InfluenceScope InfluenceScope { get; set; }
        public virtual Rumor Rumor { get; set; }
    }
}
