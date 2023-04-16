using agent.Views;
using Domain;
using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;
using Data;
using System.Collections.ObjectModel;
using NHibernate.Mapping;
using System.Windows.Markup;

namespace agent.ViewModels
{
    public class NewProportionViewModel : BindableBase
    {
        public DataBaseAccess<AgentSetProportion> ProportionAccess = new();
        public DataBaseAccess<LocationConfig> LocationConfigAccess = new();
        public DataBaseAccess<OccupationConfig> OccupationConfigAccess = new();
        public DataBaseAccess<EduLevelConfig> EduLevelConfigAccess = new();
        public DataBaseAccess<AgeLevelConfig> AgeLevelConfigAccess = new();

        #region 新建个体比例方案
        private AgentSetProportion _newItem;
        public AgentSetProportion NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        #endregion
        #region 地理位置分布配置
        private ObservableCollection<LocationConfig> _newlocationConfigs;
        public ObservableCollection<LocationConfig> NewLocationConfigs
        {
            get { return _newlocationConfigs; }
            set { SetProperty(ref _newlocationConfigs, value); }
        }
        private IList<Location> locations { get; set; }
        #endregion
        #region 个体信息比例配置
        private ObservableCollection<TreeData> _treeDatas;
        public ObservableCollection<TreeData> TreeDatas
        {
            get { return _treeDatas; }
            set { SetProperty(ref _treeDatas, value); }
        }
        private IList<Occupation> occupations { get; set; }
        private IList<EduLevel> eduLevels { get; set; }
        private IList<AgeLevel> ageLevels { get; set; }
        private ObservableCollection<Gender> _genders;
        public ObservableCollection<Gender> Genders
        {
            get { return _genders; }
            set { SetProperty(ref _genders, value); }
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
            //相关配置数据
            occupations = new DataBaseAccess<Occupation>().GetAll();
            eduLevels = new DataBaseAccess<EduLevel>().GetAll();
            ageLevels = new DataBaseAccess<AgeLevel>().GetAll();
            locations = new DataBaseAccess<Location>().GetAll();
            Genders = new();
            Genders.Add(new Gender()
            {
                Name = "男",
                Value = 0
            });
            Genders.Add(new Gender()
            {
                Name = "女",
                Value = 0
            });
            //基础信息初始化
            NewItem = new AgentSetProportion()
            {
                Guid = Guid.NewGuid(),
            };
            //地理位置分布初始化
            NewLocationConfigs = new();
            foreach (Location location in locations)
            {
                NewLocationConfigs.Add(new LocationConfig()
                {
                    Guid = Guid.NewGuid(),
                    AgentSetProportion = NewItem,
                    Location = location,
                    Value = 0
                });
            }
            //个体信息比例配置
            TreeDatas = new();
            foreach (Occupation occupation_t in occupations)
            {
                TreeData tmp_occupation = new() { Classify = occupation_t, Value = 0 };
                foreach (EduLevel eduLevel_t in eduLevels)
                {
                    TreeData tmp_edu = new() { Classify = eduLevel_t, Value = 0 };
                    foreach (AgeLevel ageLevel_t in ageLevels)
                    {
                        TreeData tmp_age = new() { Classify = ageLevel_t, Value = 0 };
                        foreach (Gender gender_t in Genders)
                        {
                            TreeData tmp_gender = new() { Classify = gender_t, Value = 0 };
                            tmp_age.TreeDatas.Add(tmp_gender);
                        }
                        tmp_edu.TreeDatas.Add(tmp_age);
                    }
                    tmp_occupation.TreeDatas.Add(tmp_edu);
                }
                TreeDatas.Add(tmp_occupation);
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
        #region 第二步：地理分布配置
        public DelegateCommand Next2 { get; private set; }
        public void Next2Method()
        {
            TabIndex = 2;
        }
        #endregion
        #region 第三步：完成配置
        public DelegateCommand<Window> Finish { get; private set; }
        public void FinishMethod(Window newwindow)
        {
            NewItem.CreateTime = DateTime.Now;
            ProportionAccess.Add(NewItem);
            foreach (var i in NewLocationConfigs)
            {
                LocationConfigAccess.Add(i);
            }
            foreach (var tmp_occupation in TreeDatas)
            {
                OccupationConfig occupationConfig = new OccupationConfig()
                {
                    Guid = Guid.NewGuid(),
                    AgentSetProportion = NewItem,
                    Occupation = (Occupation)tmp_occupation.Classify,
                    Value = tmp_occupation.Value,
                };
                OccupationConfigAccess.Add(occupationConfig);
                foreach (var tmp_edu in tmp_occupation.TreeDatas)
                {
                    EduLevelConfig eduLevelConfig = new EduLevelConfig()
                    {
                        Guid = Guid.NewGuid(),
                        AgentSetProportion = NewItem,
                        OccupationConfig = occupationConfig,
                        EduLevel = (EduLevel)tmp_edu.Classify,
                        Value = tmp_edu.Value
                    };
                    EduLevelConfigAccess.Add(eduLevelConfig);
                    foreach (var tmp_age in tmp_edu.TreeDatas)
                    {
                        AgeLevelConfig ageLevelConfig = new AgeLevelConfig()
                        {
                            Guid = Guid.NewGuid(),
                            AgentSetProportion = NewItem,
                            EduLevelConfig = eduLevelConfig,
                            Value = tmp_age.Value,
                            AgeLevel = (AgeLevel)tmp_age.Classify,
                        };
                        foreach (var tmp_gender in tmp_age.TreeDatas)
                        {
                            Gender t = (Gender)tmp_gender.Classify;
                            if (t.Name == "男")
                            {
                                ageLevelConfig.MenProportion = tmp_gender.Value;
                            }
                            if (t.Name == "女")
                            {
                                ageLevelConfig.WomenProportion = tmp_gender.Value;
                            }
                        }
                        AgeLevelConfigAccess.Add(ageLevelConfig);
                    }
                }
            }
            NHibernateHelper.CloseSession();
            newwindow.Close();
        }

        #endregion

        #region Main
        public NewProportionViewModel()
        {
            InitialNewItem();
            Next1 = new DelegateCommand(Next1Method);
            Next2 = new DelegateCommand(Next2Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
            
        }
        #endregion
    }   
}

