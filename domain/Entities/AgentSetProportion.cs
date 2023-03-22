using Domain;

namespace Domain.Entities
{
    public class AgentSetProportion : InfoData
    {


        /// <summary>
        /// 基于该比例数据生成的个体集
        /// </summary>
        public virtual ISet<AgentSet> AgentSets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ISet<OccupationConfig> OccupationConfigs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ISet<EduLevelConfig> EduLevelConfigs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ISet<AgeLevelConfig> AgeLevelConfigs { get; set; }

        public virtual ISet<LocationConfig> LocationConfigs { get; set; }
    }
}
