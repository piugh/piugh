using agent.Data;
using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace agent.ViewModels
{
    public class LearnAgentViewModel : BindableBase,INavigationAware
    {
        #region 当前选中的方案       
        private AgentLearningSch _selectedItem;
        public AgentLearningSch SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                SetProperty(ref _selectedItem, value);
                OnPerpertyChanged(nameof(SelectedItem));
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            var aa = SelectedItem.NetworkResult;
            var bb = SelectedItem.RumorLearningConfigs;
        }
        #endregion

        #region Main
        public LearnAgentViewModel()
        {
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

        #region 属性改变
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPerpertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
