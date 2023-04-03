using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace agent.ViewModels
{
    public class NewInitialAgentViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<AgentSetProportion> ProportionAccess = new();
        public DataBaseAccess<AgentSet> AgentSetAccess = new();
        public DataBaseAccess<Agent> AgentAccess = new();
        #endregion

        #region 新建个体集方案
        public AgentSet NewItem { get; set; }

        //个体数目
        private int _agentNum;
        public int AgentNum
        {
            get { return _agentNum; }
            set { SetProperty(ref _agentNum, value); }
        }
        #endregion

        #region 已有统计比例方案
        //ProportionNames
        //所有个体集方案数据
        public IList<AgentSetProportion> ProportionItems;
        //所有个体方案名称
        private ObservableCollection<string> _proportionNames;
        public ObservableCollection<string> ProportionNames
        {
            get { return _proportionNames; }
            set { SetProperty(ref _proportionNames, value); }
        }
        #endregion

        #region 报错提示
        private Visibility _warning;
        public Visibility Warning
        {
            get { return _warning; }
            set { SetProperty(ref _warning, value); }
        }
        #endregion

        #region 切换下一步
        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set { SetProperty(ref _tabIndex, value); }
        }
        #endregion

        #region 初始化
        private void InitialNewItem()
        {
            Warning = Visibility.Hidden;
            TabIndex = 0;
            AgentNum = 0;
            SelectedItem = null;
            //基础信息初始化
            NewItem = new AgentSet()
            {
                Guid= Guid.NewGuid(),
            };

            //统计比例方案
            ProportionItems = ProportionAccess.GetAll();
            ProportionNames = new();
            foreach (AgentSetProportion item in ProportionItems)
            {
                ProportionNames.Add(item.Name);
            }
        }
        #endregion

        #region 当前选中的方案
        //所选个体集方案个体列表
        private AgentSetProportion _selectedItem;
        public AgentSetProportion SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
        #endregion

        #region 选择统计比例方案
        public DelegateCommand<string> SelectProportion { get; private set; }
        public void SelectProportionMethod(string myprop)
        {
            foreach (var Item in ProportionItems)
            {
                if (Item.Name == myprop)
                    SelectedItem = Item;                
            }
        }
        #endregion

        #region 第一步：基础信息配置
        public DelegateCommand Next1 { get; private set; }
        public void Next1Method()
        {
            if (string.IsNullOrWhiteSpace(NewItem.Name) ||
                string.IsNullOrWhiteSpace(NewItem.CreateName))
            {
                Warning = Visibility.Visible;
            }
            else
            {
                Warning = Visibility.Hidden;
                TabIndex = 1;
            }
        }
        #endregion

        #region 第二步：完成配置
        public DelegateCommand<Window> Finish { get; private set; }
        public void FinishMethod(Window newwindow)
        {
            if (SelectedItem == null)
            {
                Warning = Visibility.Visible;
            }
            else
            {              
                NewItem.CreateTime = DateTime.Now;
                NewItem.Proportion = SelectedItem;
                AgentSetAccess.Add(NewItem);

                Random random = new Random();

                //确定不同地理位置的人数配置
                IList<LocationConfig> locationConfigs = new DataBaseAccess<LocationConfig>().GetByCondition(SelectedItem, "AgentSetProportion");
                List<int> LocationValue = new List<int>();
                {
                    List<double> temp = locationConfigs.Select(t => t.Value).ToList();
                    double temp_sum = temp.Sum();
                    //先确定各个比例的人数
                    foreach (var i in temp)
                    {
                        if (temp_sum == 0)
                            LocationValue.Add((int)(AgentNum / locationConfigs.Count));
                        else
                            LocationValue.Add((int)(AgentNum * i / temp_sum));
                    }
                    //补全剩余人数
                    LocationValue[0] += AgentNum - LocationValue.Sum();
                }

                //确定不同职业的人数配置
                IList<OccupationConfig> occupationConfigs = new DataBaseAccess<OccupationConfig>().GetByCondition(SelectedItem, "AgentSetProportion");
                List<int> OccupationValue = new List<int>();
                {
                    List<double> temp = occupationConfigs.Select(t => t.Value).ToList();
                    double temp_sum = temp.Sum();
                    //先确定各个比例的人数
                    foreach (var i in temp)
                    {
                        if (temp_sum == 0)
                            OccupationValue.Add((int)(AgentNum / occupationConfigs.Count));
                        else
                            OccupationValue.Add((int)(AgentNum * i / temp_sum));
                    }                   
                    //补全剩余人数
                    OccupationValue[0] += AgentNum - OccupationValue.Sum();
                }
                //由内而外配置人数
                for (int occupation_index = 0; occupation_index < OccupationValue.Count(); occupation_index++)
                {
                    //确定不同教育水平的人数配置
                    IList<EduLevelConfig> eduLevelConfigs = new DataBaseAccess<EduLevelConfig>().GetByCondition(SelectedItem, "AgentSetProportion", occupationConfigs[occupation_index], "OccupationConfig");
                    List<int> EduLevelValue = new();
                    {
                        List<double> temp = eduLevelConfigs.Select(t => t.Value).ToList();
                        double temp_sum = temp.Sum();
                        //先确定各个比例的人数
                        foreach (var i in temp)
                        {
                            if (temp_sum == 0)
                                EduLevelValue.Add((int)(OccupationValue[occupation_index] / eduLevelConfigs.Count));
                            else
                                EduLevelValue.Add((int)(OccupationValue[occupation_index] * i / temp_sum));
                        }                       
                        //补全剩余人数
                        EduLevelValue[0] += OccupationValue[occupation_index] - EduLevelValue.Sum();
                    }
                    for (int edu_index = 0; edu_index < EduLevelValue.Count(); edu_index++)
                    {
                        //确定不同年龄阶段的人数配置
                        IList<AgeLevelConfig> ageLevelConfigs = new DataBaseAccess<AgeLevelConfig>().GetByCondition(SelectedItem, "AgentSetProportion", eduLevelConfigs[edu_index], "EduLevelConfig");
                        List<int> AgeLevelValue = new();
                        {
                            List<double> temp = ageLevelConfigs.Select(t => t.Value).ToList();
                            double temp_sum = temp.Sum();
                            //先确定各个比例的人数
                            foreach (var i in temp)
                            {
                                if (temp_sum == 0)
                                    AgeLevelValue.Add((int)(EduLevelValue[edu_index] / ageLevelConfigs.Count));
                                else
                                    AgeLevelValue.Add((int)(EduLevelValue[edu_index] * i / temp_sum));
                            }
                            //补全剩余人数
                            AgeLevelValue[0] += EduLevelValue[edu_index] - AgeLevelValue.Sum();
                        }
                        for (int age_index = 0; age_index < AgeLevelValue.Count(); age_index++)
                        {
                            //确定不同性别的人数配置
                            List<int> GenderValue = new List<int>();
                            {
                                List<double> temp = new() { ageLevelConfigs[age_index].MenProportion, ageLevelConfigs[age_index].WomenProportion };
                                double temp_sum = temp.Sum();
                                //先确定各个比例的人数
                                foreach (var i in temp)
                                {
                                    if (temp_sum == 0)
                                        GenderValue.Add((int)(AgeLevelValue[age_index] / 2));
                                    else
                                        GenderValue.Add((int)(AgeLevelValue[age_index] * i / temp_sum));
                                }
                                //补全剩余人数
                                GenderValue[0] += AgeLevelValue[age_index] - GenderValue.Sum();
                            }
                            //构建单个agent
                            for (int gender_index = 0; gender_index < GenderValue.Count(); gender_index++)
                            {
                                for (int count = 0; count < GenderValue[gender_index]; count++)
                                {
                                    //agent具体信息配置
                                    Agent agent = new Agent()
                                    {
                                        Guid = Guid.NewGuid(),
                                        AgentSet = NewItem
                                    };
                                    agent.Age = random.Next(ageLevelConfigs[age_index].AgeLevel.Down, ageLevelConfigs[age_index].AgeLevel.Up); ;
                                    agent.AgeLevel = ageLevelConfigs[age_index].AgeLevel;
                                    agent.EduLevel = eduLevelConfigs[edu_index].EduLevel;
                                    agent.Occupation = occupationConfigs[occupation_index].Occupation;
                                    if (gender_index == 0)
                                    {
                                        agent.Gender = "男";
                                    }
                                    else
                                    {
                                        agent.Gender = "女";
                                    }
                                    //地理位置信息添加
                                    int flag = random.Next(100);
                                    {
                                        int index = flag % LocationValue.Count();
                                        while (true)
                                        {
                                            if (LocationValue[index] == 0)
                                            {
                                                flag += 1;
                                                index = flag % LocationValue.Count();
                                            }
                                            else
                                            {
                                                agent.Latitude = random.Next((int)locationConfigs[index].Location.LatitudeLower, (int)locationConfigs[index].Location.LatitudeUpper);
                                                agent.Longitude = random.Next((int)locationConfigs[index].Location.LongitudeLower, (int)locationConfigs[index].Location.LongitudeUpper);
                                                LocationValue[index] -= 1;
                                                break;
                                            }
                                        }
                                    }
                                    AgentAccess.Add(agent);
                                }
                            }

                        }
                    }
                }
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
        }
        #endregion

        #region Main
        public NewInitialAgentViewModel()
        {
            InitialNewItem();
            SelectProportion = new DelegateCommand<string>(SelectProportionMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);

        }
        #endregion
    }
}
