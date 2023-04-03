using Domain.Network.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Network.ViewModels
{
    public class NetConfigViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        private NetworkSch _selectedItem;
        public NetworkSch SelectedItem
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
        public NetConfigViewModel()
        {
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (NetworkSch)navigationContext.Parameters["SelectedItem"];
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
