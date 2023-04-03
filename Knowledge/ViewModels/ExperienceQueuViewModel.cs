using Domain.Information.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Knowledge.ViewModels
{
    public class ExperienceQueuViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        //所选个体集方案个体列表
        private PropositionQueue _selectedItem;
        public PropositionQueue SelectedItem
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
        }
        #endregion

        #region Main
        public ExperienceQueuViewModel()
        {
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (PropositionQueue)navigationContext.Parameters["SelectedItem"];
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
