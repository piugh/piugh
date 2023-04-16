using Domain.Information.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataConvert
    {
        /// <summary>
        /// 返回一个与数据库无关的只有Name的Rumor类，用于展示
        /// </summary>
        /// <param name="rumorString"></param>
        /// <returns></returns>
        public static Rumor StringToRumor(string rumorString)
        {
            Rumor rumor = new Rumor();
            string myRumorString=rumorString.Replace(",","");
            int postion = 0;
            //初始化征兆数据
            IList<OmenValue> omenValues= new DataBaseAccess<OmenValue>().GetAll();
            rumor.Omens = new HashSet<Omen>();
            //1.生物异常
            int temp = postion;
            postion += 7;
            HashSet<AnimalConfig> animalConfigs = new HashSet<AnimalConfig>();
            {
                DataBaseAccess<AnimalAnomaly> dataBaseAccess = new();
                IList<AnimalAnomaly> animalAnomalies = dataBaseAccess.GetAllByOrder();
                foreach (AnimalAnomaly animalAnomaly in animalAnomalies)
                {
                    if (myRumorString.Substring(temp, 1).Equals("1"))
                    {
                        AnimalConfig animalConfig = new AnimalConfig();
                        animalConfig.AnimalAnomaly = new AnimalAnomaly()
                        {
                            Name = animalAnomaly.Name,
                            Order = animalAnomaly.Order
                        };
                        animalConfig.Value = new OmenValue()
                        {
                            Name = omenValues
                            .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 2)))
                            .First().Name
                        };
                        animalConfig.IsAdd = true;
                        animalConfigs.Add(animalConfig);
                    }
                    postion += 2;
                    temp++;
                }
            }
                

            //2.地下水异常
            temp = postion;
            postion += 7;
            HashSet<GroundwaterConfig> groundwaterConfigs = new HashSet<GroundwaterConfig>();
            {
                DataBaseAccess<GroundwaterAnomaly> dataBaseAccess = new DataBaseAccess<GroundwaterAnomaly>();
                IList<GroundwaterAnomaly> groundwaterAnomalies = dataBaseAccess.GetAllByOrder();
                foreach (GroundwaterAnomaly groundwaterAnomaly in groundwaterAnomalies)
                {
                    if (myRumorString.Substring(temp, 1).Equals("1"))
                    {
                        GroundwaterConfig groundwaterConfig = new GroundwaterConfig();
                        groundwaterConfig.GroundwaterAnomaly = new GroundwaterAnomaly()
                        {
                            Name = groundwaterAnomaly.Name,
                            Order = groundwaterAnomaly.Order
                        };
                        groundwaterConfig.Value = new OmenValue()
                        {
                            Name = omenValues
                            .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 2)))
                            .First().Name
                        };
                        groundwaterConfig.IsAdd = true;
                        groundwaterConfigs.Add(groundwaterConfig);
                    }
                    postion += 2;
                    temp++;
                }
            }

            //3.气候异常
            temp = postion;
            postion += 6;
            HashSet<ClimateConfig> climateConfigs = new HashSet<ClimateConfig>();
            {
                DataBaseAccess<ClimateAnomaly> databaseAccesss = new();
                IList<ClimateAnomaly> climateAnomalies = databaseAccesss.GetAllByOrder();
                foreach (ClimateAnomaly climateAnomaly in climateAnomalies)
                {
                    if (myRumorString.Substring(temp, 1).Equals("1"))
                    {
                        ClimateConfig climateConfig = new ClimateConfig();
                        climateConfig.ClimateAnomaly = new ClimateAnomaly()
                        {
                            Name = climateAnomaly.Name,
                            Order = climateAnomaly.Order
                        };
                        climateConfig.Value = new OmenValue()
                        {
                            Name = omenValues
                            .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 2)))
                            .First().Name
                        };
                        climateConfig.IsAdd = true;
                        climateConfigs.Add(climateConfig);
                    }
                    postion += 2;
                    temp++;
                }
            }

            //4.地面异常
            temp = postion;
            postion += 5;
            HashSet<GroundConfig> groundConfigs = new HashSet<GroundConfig>();
            {
                DataBaseAccess<GroundAnomaly> DataBaseAccess = new();
                IList<GroundAnomaly> groundAnomalies = DataBaseAccess.GetAllByOrder();
                foreach (GroundAnomaly groundAnomaly in groundAnomalies)
                {
                    if (myRumorString.Substring(temp, 1).Equals("1"))
                    {
                        GroundConfig groundConfig = new GroundConfig();
                        groundConfig.GroundAnomaly = new GroundAnomaly()
                        {
                            Name = groundAnomaly.Name,
                            Order = groundAnomaly.Order
                        };
                        groundConfig.Value = new OmenValue()
                        {
                            Name = omenValues
                            .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 2)))
                            .First().Name
                        };
                        groundConfig.IsAdd = true;
                        groundConfigs.Add(groundConfig);
                    }
                    postion += 2;
                    temp++;
                }
            }


            //5.电磁异常
            temp = postion;
            postion += 5;
            HashSet<ElectroConfig> electroConfigs = new HashSet<ElectroConfig>();
            {
                DataBaseAccess<ElectroAnomaly> DataBaseAccess = new();
                IList<ElectroAnomaly> electroAnomalies = new DataBaseAccess<ElectroAnomaly>().GetAllByOrder();
                foreach (ElectroAnomaly electroAnomaly in electroAnomalies)
                {
                    if (myRumorString.Substring(temp, 1).Equals("1"))
                    {
                        ElectroConfig electroConfig = new ElectroConfig();
                        electroConfig.ElectroAnomaly = new()
                        {
                            Name = electroAnomaly.Name,
                            Order = electroAnomaly.Order
                        };
                        electroConfig.Value = new OmenValue()
                        {
                            Name = omenValues
                            .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 2)))
                            .First().Name
                        };
                        electroConfig.IsAdd = true;
                        electroConfigs.Add(electroConfig);
                    }
                    postion += 2;
                    temp++;
                }
            }
            omenValues.Clear();
            rumor.Omens.Add(new Omen()
            {
                AnimalConfigs = animalConfigs,
                GroundConfigs = groundConfigs,
                GroundwaterConfigs = groundwaterConfigs,
                ClimateConfigs = climateConfigs,
                ElectroConfigs = electroConfigs
            });


            //危机
            IList<CrisisType> crisisTypes = new DataBaseAccess<CrisisType>().GetAllByOrder();
            IList<CrisisTimeSpan> crisisTimeSpans = new DataBaseAccess<CrisisTimeSpan>().GetAll();
            IList<CrisisLevel> crisisLevels = new DataBaseAccess<CrisisLevel>().GetAll();
            IList<CrisisFrequence> crisisFrequences = new DataBaseAccess<CrisisFrequence>().GetAll();
            IList<CrisisPersistentTime> crisisPersistentTimes = new DataBaseAccess<CrisisPersistentTime>().GetAll();
            int typeNum = 0;
            HashSet<Crisis> crises= new HashSet<Crisis>();
            foreach(CrisisType crisisType in crisisTypes)
            {
                if(myRumorString.Substring(postion+typeNum,1).Equals("1"))
                {
                    Crisis crisis = new Crisis();
                    crisis.IsAdd = true;
                    crisis.Type = new CrisisType() { Name = crisisType.Name, Order = crisisType.Order };
                    crisis.TimeSpan = new CrisisTimeSpan()
                    {
                        Name = crisisTimeSpans
                        .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion + crisisTypes.Count + typeNum * 12, 3)))
                        .First().Name
                    };
                    crisis.Level = new CrisisLevel()
                    {
                        Name = crisisLevels
                         .Where(n => n.EumBinary.
                            Equals(myRumorString.Substring(postion + crisisTypes.Count + typeNum * 12 + 3, 3)))
                        .First().Name
                    };
                    crisis.Frequence = new CrisisFrequence()
                    {
                        Name = crisisFrequences
                        .Where(n => n.EumBinary.
                            Equals(myRumorString.Substring(postion + crisisTypes.Count + typeNum * 12 + 6, 3)))
                        .First().Name
                    };
                    crisis.PersistentTime = new CrisisPersistentTime()
                    {
                        Name = crisisPersistentTimes
                        .Where(n => n.EumBinary.
                            Equals(myRumorString.Substring(postion + crisisTypes.Count + typeNum * 12 + 9, 3)))
                        .First().Name
                    };
                    crises.Add(crisis);
                }
                typeNum += 1;
                
            }
            //调整下标
            postion += crisisTypes.Count;
            postion += (typeNum*12);
            rumor.Crisises = crises;

            //crisisTypes.Clear();
            //crisisTimeSpans.Clear();
            //crisisLevels.Clear();
            //crisisFrequences.Clear();
            //crisisPersistentTimes.Clear();

            //后果
            IList<Casualty>  casualties=new DataBaseAccess<Casualty>().GetAll();
            IList<MinorCasualty> minorCasualties=new DataBaseAccess<MinorCasualty>().GetAll();
            IList<BuildingLoss> buildingLosses=new DataBaseAccess<BuildingLoss>().GetAll();
            IList<EconomyLoss> economyLosses=new DataBaseAccess<EconomyLoss>().GetAll();
            IList<ImpactOfDaily> impactOfDailys=new DataBaseAccess<ImpactOfDaily>().GetAll();
            IList<PersistentTime > persistentTimes=new DataBaseAccess<PersistentTime>().GetAll();
            IList<InfluenceScope> influenceScopes=new DataBaseAccess<InfluenceScope>().GetAll();

            Result result=new Result();
            result.Casualty = new Casualty()
            {
                Name = casualties
                    .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                    .First().Name
            };
            postion += 3;
            result.MinorCasualty = new MinorCasualty()
            {
                Name = minorCasualties
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            postion += 3;
            result.BuildingLoss = new BuildingLoss()
            {
                Name = buildingLosses
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            postion += 3;
            result.EconomyLoss = new EconomyLoss()
            {
                Name = economyLosses
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            postion += 3;
            result.ImpactOfDaily = new ImpactOfDaily()
            {
                Name = impactOfDailys
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            postion += 3;
            result.PersistentTime = new PersistentTime()
            {
                Name = persistentTimes
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            postion += 3;
            result.InfluenceScope = new InfluenceScope()
            {
                Name = influenceScopes
                .Where(n => n.EumBinary.Equals(myRumorString.Substring(postion, 3)))
                .First().Name
            };
            rumor.Results = new HashSet<Result>() { result };
            //casualties.Clear();
            //minorCasualties.Clear();
            //buildingLosses.Clear();
            //economyLosses.Clear();
            //impactOfDailys.Clear();
            //persistentTimes.Clear();
            //influenceScopes.Clear();

            return rumor;
        }
    }
}
