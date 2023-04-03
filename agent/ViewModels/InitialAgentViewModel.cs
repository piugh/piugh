using agent.Views;
using Data;
using Domain;
using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Resource.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace agent.ViewModels
{
    public class InitialAgentViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        //所选个体集方案个体列表
        private AgentSet _selectedItem;
        public AgentSet SelectedItem
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
                if(value == 0)
                {
                    IRegion region = _regionManager.Regions["InitialAgentBaseInfoRegion"];
                    region.RemoveAll();
                    _regionManager.RegisterViewWithRegion("InitialAgentBaseInfoRegion", typeof(BaseInfoView));
                }
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            int id = 1;
            if (SelectedItem.Agents == null)
                return;           
            foreach (Agent agent in SelectedItem.Agents)
            {
                agent.id = id;
                id++;
            }
            TabIndex = 0;
        }
        #endregion
      
        #region Main
        public InitialAgentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = navigationContext.Parameters["SelectedItem"] as AgentSet;
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
