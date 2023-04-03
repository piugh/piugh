using agent.Views;
using Data;
using Domain;
using Domain.Entities;
using LiveCharts.Wpf;
using LiveCharts;
using Microsoft.VisualBasic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Xml.Linq;
using Resource.Views;

namespace agent.ViewModels
{
    public class ProportionViewModel : BindableBase, INavigationAware
    {
        #region 数据接口
        public DataBaseAccess<OccupationConfig> OccupationConfigAccess;
        public DataBaseAccess<EduLevelConfig> EduLevelConfigAccess;
        public DataBaseAccess<AgeLevelConfig> AgeLevelConfigAccess;
        #endregion

        #region 当前选中的方案
        private AgentSetProportion _selectedItem;
        public AgentSetProportion SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        private ObservableCollection<TreeData> _treeDatas;
        public ObservableCollection<TreeData> TreeDatas
        {
            get { return _treeDatas; }
            set
            {
                SetProperty(ref _treeDatas, value);
            }
        }
        #endregion

        #region 显示信息
        private readonly IRegionManager _regionManager;
        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set
            {
                SetProperty(ref _tabIndex, value);
                if (value == 0)
                {
                    IRegion region = _regionManager.Regions["ProportionBaseInfoRegion"];
                    region.RemoveAll();
                    _regionManager.RegisterViewWithRegion("ProportionBaseInfoRegion", typeof(BaseInfoView));
                }
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            //数据接口初始化
            OccupationConfigAccess = new();
            EduLevelConfigAccess = new();
            AgeLevelConfigAccess = new();
            //方案数据初始化
            TreeDatas = new();
            GetTree(SelectedItem);
            GetPieSeriesData();
            TabIndex = 0;
        }
        #endregion

        #region 饼状图绘制

        #region 饼状图数据
        //年龄比例饼图数据
        private SeriesCollection _ageLevelSeries;
        public SeriesCollection AgeLevelSeries
        {
            get { return _ageLevelSeries; }
            set
            {
                SetProperty(ref _ageLevelSeries, value);
            }
        }
        //受教育程度饼图
        private SeriesCollection _eduLevelSerises;
        public SeriesCollection EduLevelSeries
        {
            get { return _eduLevelSerises; }
            set
            {
                SetProperty(ref _eduLevelSerises, value);
            }
        }

        //职业饼图数据
        private SeriesCollection _occupationSeries;
        public SeriesCollection OccupationSeries
        {
            get { return _occupationSeries; }
            set
            {
                SetProperty(ref _occupationSeries, value);
            }
        }
        //地理分布饼图
        private SeriesCollection _locationSeries;
        public SeriesCollection LocationSeries
        {
            get { return _locationSeries; }
            set
            {
                SetProperty(ref _locationSeries, value);
            }
        }

        private OccupationConfig _selectedOccupationConfig;
        public OccupationConfig SelectedOccupationConfig
        {
            get { return _selectedOccupationConfig; }
            set 
            { 
                SetProperty(ref _selectedOccupationConfig, value); 
                if(value!= null)
                {
                    GetEduPieSeriesData();
                }
            }
        }

        private EduLevelConfig _selectedEduLevelConfig;
        public EduLevelConfig SelectedEduLevelConfig
        {
            get { return _selectedEduLevelConfig; }
            set 
            { 
                SetProperty(ref _selectedEduLevelConfig, value); 
                if(value!=null)
                {
                    GetAgePieSeriesData();
                }
            }
        }
        #endregion
        //整体信息饼状图
        public void GetPieSeriesData()
        {
            //职业数据生成
            List<double> occupationvalue = new();
            List<string> occupationtitle = new();
            List<OccupationConfig> occupationconfigs = SelectedItem.OccupationConfigs.ToList();
            foreach (OccupationConfig i in occupationconfigs)
            {
                occupationtitle.Add(i.Occupation.Name);
                occupationvalue.Add(i.Value);
            }
            OccupationSeries = new();
            for (int i = 0; i < occupationtitle.Count; i++)
            {
                OccupationSeries.Add(new PieSeries
                {
                    DataLabels = true,
                    Title = occupationtitle[i],
                    Values = new ChartValues<double> { occupationvalue[i] }
                });
            }

            //地理分布数据生成
            List<double> locationvalue = new();
            List<string> locationtitle = new();
            List<LocationConfig> locationconfigs = SelectedItem.LocationConfigs.ToList();
            foreach (var i in locationconfigs)
            {
                locationtitle.Add(i.Location.Name);
                locationvalue.Add(i.Value);
            }
            LocationSeries = new();
            for (int i = 0; i < locationtitle.Count; i++)
            {
                LocationSeries.Add(new PieSeries
                {
                    DataLabels = true,
                    Title = locationtitle[i],
                    Values = new ChartValues<double> { locationvalue[i] }
                });
            }
        }
        //教育程度饼状图
        public void GetEduPieSeriesData()
        {
            //受教育程度数据生成 
            List<double> eduLevelvalue = new();
            List<string> eduLeveltitle = new();
            List<EduLevelConfig> eduLevelConfigs = SelectedOccupationConfig.EduLevelConfigs.ToList();
            foreach (EduLevelConfig i in eduLevelConfigs)
            {
                eduLeveltitle.Add(i.EduLevel.Name);
                eduLevelvalue.Add(i.Value);
            }
            EduLevelSeries = new();
            for (int i = 0; i < eduLeveltitle.Count; i++)
            {
                EduLevelSeries.Add(new PieSeries
                {
                    DataLabels = true,
                    Title = eduLeveltitle[i],
                    Values = new ChartValues<double> { eduLevelvalue[i] }
                });
            }
        }
        //年龄水平饼状图
        public void GetAgePieSeriesData()
        {
            //年龄分层数据生成
            List<double> ageLevelvalue = new();
            List<string> ageLeveltitle = new();
            List<AgeLevelConfig> ageLevelConfigs = SelectedEduLevelConfig.AgeLevelConfigs.ToList();
            foreach (AgeLevelConfig i in ageLevelConfigs)
            {
                if (true)
                {
                    ageLeveltitle.Add(i.AgeLevel.Name);
                    ageLevelvalue.Add(i.Value);
                }
            }
            AgeLevelSeries = new();
            for (int i = 0; i < ageLeveltitle.Count; i++)
            {
                AgeLevelSeries.Add(new PieSeries
                {
                    DataLabels = true,
                    Title = ageLeveltitle[i],
                    Values = new ChartValues<double> { ageLevelvalue[i] }
                });
            }
        }
        #endregion

        #region 统计比例的树型结构
        //用到的配置信息
        private IList<OccupationConfig> MyOccupationConfigs { get; set; }
        private IList<AgeLevelConfig> MyAgeLevelConfigs { get; set; }
        private IList<EduLevelConfig> MyEduLevelConfigs { get; set; }

        public void GetTree(AgentSetProportion MyItem)
        {
            TreeDatas.Clear();
            //个体信息比例配置
            MyOccupationConfigs = OccupationConfigAccess.GetByCondition(MyItem, "AgentSetProportion");

            Gender gender_men = new() {BaseInfo = new BaseInfo()};
            gender_men.BaseInfo.Name = "男";
            Gender gender_women = new() { BaseInfo = new BaseInfo() };
            gender_women.BaseInfo.Name = "女";

            foreach (OccupationConfig occupationConfig in MyOccupationConfigs)
            {
                TreeData tmp_occupation = new()
                {
                    Classify = occupationConfig.Occupation,
                    Value = occupationConfig.Value,
                };
                MyEduLevelConfigs = EduLevelConfigAccess.GetByCondition
                    (SelectedItem, "AgentSetProportion",
                    occupationConfig, "OccupationConfig");
                foreach (EduLevelConfig eduLevelConfig in MyEduLevelConfigs)
                {
                    TreeData tmp_edu = new()
                    {
                        Classify = eduLevelConfig.EduLevel,
                        Value = eduLevelConfig.Value,
                    };
                    MyAgeLevelConfigs = AgeLevelConfigAccess.GetByCondition(SelectedItem, "AgentSetProportion",
                        eduLevelConfig, "EduLevelConfig");
                    foreach (AgeLevelConfig ageLevelConfig in MyAgeLevelConfigs)
                    {
                        TreeData temp_ageLevel = new()
                        {
                            Classify = ageLevelConfig.AgeLevel,
                            Value = ageLevelConfig.Value,
                        };
                        {
                            TreeData tmp_gender1 = new() { Classify = gender_men, Value = ageLevelConfig.MenProportion };
                            TreeData tmp_gender2 = new() { Classify = gender_women, Value = ageLevelConfig.WomenProportion };
                            temp_ageLevel.TreeDatas.Add(tmp_gender1);
                            temp_ageLevel.TreeDatas.Add(tmp_gender2);
                        }
                        tmp_edu.TreeDatas.Add(temp_ageLevel);
                    }
                    tmp_occupation.TreeDatas.Add(tmp_edu);
                }
                TreeDatas.Add(tmp_occupation);
            }
        }
        #endregion

        #region Main
        public ProportionViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (AgentSetProportion)navigationContext.Parameters["SelectedItem"];
            Initialization();            
        }

        #endregion

        #region 允许导航（不用在意）
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion
    }

    #region 个体信息比例配置
    public class TreeData
    {
        public Guid Guid { get; set; }
        public object Classify { get; set; }            //不同类型的数据
        public double Value { get; set; }               //配置的比例
        public ObservableCollection<TreeData> TreeDatas { get; set; }
        public TreeData()
        {
            TreeDatas = new ObservableCollection<TreeData>();
        }
    }
    public class Gender
    {
        public BaseInfo BaseInfo { get; set; }
        public double Value { get; set; }
    }
    #endregion


}
