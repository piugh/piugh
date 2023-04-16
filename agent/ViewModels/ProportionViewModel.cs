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
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "BaseInfoView", parameter);
                }
                //饼状图
                if (value == 1)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "Proportion_Piechart", parameter);
                }
                //树状图
                if (value == 2)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "Proportion_Treemap", parameter);
                }
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            TabIndex = 0;
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
    public class Gender:InfoData
    {
        public double Value { get; set; }
    }
    #endregion


}
