using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Resource.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Experiment.ViewModels
{
    public class ExperimentItemViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        private Domain.Entities.Experiment _selectedItem;
        public Domain.Entities.Experiment SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
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
                //基本信息
                if (value == 0)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "BaseInfoView", parameter);
                }
                //统计比例信息
                if (value == 1)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem.AgentSet.Proportion);
                    _regionManager.RequestNavigate("TabInfo", "Proportion_Piechart", parameter);
                }
                //个体信息
                if (value == 2)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem.AgentSet);
                    _regionManager.RequestNavigate("TabInfo", "InitialAgent_AgentSetTable", parameter);
                }
                //网络信息
                if (value == 3)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem.NetworkResult);
                    _regionManager.RequestNavigate("TabInfo", "NetResult_Resultinfo", parameter);
                }
                //个体学习信息
                if (value == 4)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem.AgentLearningSch);
                    _regionManager.RequestNavigate("TabInfo", "LearnAgent_Messageconfig", parameter);
                }
                //消息投放信息
                if (value == 5)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "ExperimentItem_RumorDelivery", parameter);
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
        public ExperimentItemViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = navigationContext.Parameters["SelectedItem"] as Domain.Entities.Experiment;
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
