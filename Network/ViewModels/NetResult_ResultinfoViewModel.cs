using Domain.Network.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Network.ViewModels
{
    public class NetResult_ResultinfoViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        private NetworkResult _selectedItem;
        public NetworkResult SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        public int NodeNum { get; set; }
        #endregion

        #region 初始化
        private void Initialization()
        {
            NodeNum = SelectedItem.NetNodes.Count;
        }
        #endregion

        #region Main
        public NetResult_ResultinfoViewModel()
        {

        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (NetworkResult)navigationContext.Parameters["SelectedItem"];
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
