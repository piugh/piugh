using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain.Information.Entities
{
    public class Rumor : InfoData
    {

        public virtual string RumorEumBinary { get; set; }
        public virtual string OmenEumBinary { get; set; }
        public virtual string CrisisEumBinary { get; set; }
        public virtual string ResultEumBinary { get; set; }
        public virtual ISet<Omen> Omens { get; set; }
        public virtual ISet<Crisis> Crisises { get; set; }
        public virtual ISet<Result> Results { get; set; }
        public virtual ISet<Proposition> Propositions { get; set; }
        public virtual ISet<RumorQueueConfig> RumorQueueConfigs { get; set; }
        public virtual ISet<Experiment> Experiments { get; set; }

        public virtual string MeanString
        {
            get { return ToString(); }
        }
        public override string ToString()
        {
            string rumorString = "";
            rumorString += "征兆：\n";
            foreach (var omen in Omens)
            {
                if (omen.AnimalConfigs != null && omen.AnimalConfigs.Count > 0
                    && omen.AnimalConfigs.Where(n => n.IsAdd.Equals(true)).Count() > 0)
                {
                    rumorString += "生物异常有：";
                    foreach (var config in omen.AnimalConfigs)
                    {
                        if (!config.IsAdd)
                        {
                            continue;
                        }
                        rumorString += config.AnimalAnomaly.Name;
                        rumorString += '，';
                        rumorString += config.Value.Name;
                        rumorString += "；";
                    }
                    rumorString += "\n";
                }

                if (omen.GroundwaterConfigs != null && omen.GroundwaterConfigs.Count > 0
                    && omen.GroundwaterConfigs.Where(n => n.IsAdd.Equals(true)).Count() > 0)
                {
                    rumorString += "地下水异常有：";
                    foreach (var config in omen.GroundwaterConfigs)
                    {
                        if (!config.IsAdd)
                        {
                            continue;
                        }
                        rumorString += config.GroundwaterAnomaly.Name;
                        rumorString += '，';
                        rumorString += config.Value.Name;
                        rumorString += "；";
                    }
                    rumorString += "\n";
                }

                if (omen.ClimateConfigs != null && omen.ClimateConfigs.Count > 0
                    && omen.ClimateConfigs.Where(n => n.IsAdd.Equals(true)).Count() > 0)
                {
                    rumorString += "气候异常有：";
                    foreach (var config in omen.ClimateConfigs)
                    {
                        if (!config.IsAdd)
                        {
                            continue;
                        }
                        rumorString += config.ClimateAnomaly.Name;
                        rumorString += '，';
                        rumorString += config.Value.Name;
                        rumorString += "；";
                    }
                    rumorString += "\n";
                }

                if (omen.GroundConfigs != null && omen.GroundConfigs.Count > 0
                    && omen.GroundConfigs.Where(n => n.IsAdd.Equals(true)).Count() > 0)
                {
                    rumorString += "地面异常有：";
                    foreach (var config in omen.GroundConfigs)
                    {
                        if (!config.IsAdd)
                        {
                            continue;
                        }
                        rumorString += config.GroundAnomaly.Name;
                        rumorString += '，';
                        rumorString += config.Value.Name;
                        rumorString += "；";
                    }
                    rumorString += "\n";
                }

                if (omen.ElectroConfigs != null && omen.ElectroConfigs.Count > 0
                    && omen.ElectroConfigs.Where(n => n.IsAdd.Equals(true)).Count() > 0)
                {
                    rumorString += "电磁异常有：";
                    foreach (var config in omen.ElectroConfigs)
                    {
                        if (!config.IsAdd)
                        {
                            continue;
                        }
                        rumorString += config.ElectroAnomaly.Name;
                        rumorString += '，';
                        rumorString += config.Value.Name;
                        rumorString += "；";
                    }
                    rumorString += "\n";
                }
            }
            rumorString += "危机：\n";
            foreach (var crisis in Crisises)
            {
                if (!crisis.IsAdd)
                {
                    continue;
                }
                rumorString += "类型为";
                rumorString += crisis.Type.Name;
                rumorString += "的危机";
                rumorString += '，';
                rumorString += "程度";
                rumorString += crisis.Level.Name;
                rumorString += '，';
                rumorString += "发生频率为";
                rumorString += crisis.Frequence.Name;
                rumorString += '，';
                rumorString += "持续时间为";
                rumorString += crisis.Level.Name;
                rumorString += '\n';
            }

            rumorString += "后果：\n";
            foreach (var result in Results)
            {
                rumorString += "人员伤亡";
                rumorString += result.Casualty.Name;
                rumorString += '，';
                rumorString += "未成年人员伤亡";
                rumorString += result.MinorCasualty.Name;
                rumorString += '，';
                rumorString += "建筑物损失";
                rumorString += result.BuildingLoss.Name;
                rumorString += '，';
                rumorString += "经济损失";
                rumorString += result.EconomyLoss.Name;
                rumorString += '，';
                rumorString += "日常生活影响";
                rumorString += result.ImpactOfDaily.Name;
                rumorString += '，';
                rumorString += "持续时间";
                rumorString += result.PersistentTime.Name;
                rumorString += '，';
                rumorString += "影响范围";
                rumorString += result.InfluenceScope.Name;
                rumorString += '\n';
            }
            return rumorString;
        }
    }
}
