using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using NHibernate.Mapping;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Resource.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace agent.ViewModels
{
    public class LearnAgentViewModel : BindableBase,INavigationAware
    {
        #region 当前方案    
        //选中的方案
        private AgentLearningSch _selectedItem;
        public AgentLearningSch SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                SetProperty(ref _selectedItem, value);
                if (value!= null ) 
                {
                    int id = 1;
                    foreach (var i in SelectedItem.NetworkResult.NetNodes)
                    {
                        i.id = id;
                        id++;
                    }
                }
            }
        }
        //选择的网络节点
        private ObservableCollection<NetNode> _selectedNodes;
        public ObservableCollection<NetNode> SelectedNodes
        {
            get { return _selectedNodes; }
            set
            {
                SetProperty(ref _selectedNodes, value);
            }
        }
        //网络节点
        public IList<NetNode> NetNodes { get; set; }
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
                //个体消息配置
                if (value == 1)
                {
                    IRegion region = _regionManager.Regions["TabInfo"];
                    region.RemoveAll();
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("TabInfo", "LearnAgent_Messageconfig", parameter);
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
        public LearnAgentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (AgentLearningSch)navigationContext.Parameters["SelectedItem"];
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
