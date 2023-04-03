using Domain.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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

        #region 初始化
        private void Initialization()
        {
        }
        #endregion

        #region Main
        public ExperimentItemViewModel()
        {

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
