using Domain.Entities;
using LiveCharts.Wpf;
using LiveCharts;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

namespace agent.ViewModels
{
	public class Proportion_PiechartViewModel : BindableBase, INavigationAware
    {
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
        #endregion

        #region 初始化
        private void Initialization()
        {
            GetPieSeriesData();
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
                if (value != null)
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
                if (value != null)
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

        #region Main
        public Proportion_PiechartViewModel()
        {
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
}
