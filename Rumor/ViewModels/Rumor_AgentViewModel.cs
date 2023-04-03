using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Rumor.ViewModels
{
    public class Rumor_AgentViewModel : BindableBase
    {
        #region 视图注入
        private readonly IRegionManager _regionManager;
        #endregion

        #region 方案选择命令
        public DelegateCommand<string> Manage { get; set; }
        #endregion

        #region 方案选择操作
        private void SelectionManage(string i)
        {
            IRegion region = _regionManager.Regions["ListOfItem"];
            region.RemoveAll();
            //导航传参:0\1\2分别表示统计比例、初始个体集和经验个体集
            NavigationParameters parameter = new NavigationParameters{{ "TypeOfList", i }};
            _regionManager.RequestNavigate("ListOfItem", "ListOfItem", parameter);            
        }      
        #endregion

        #region Main
        public Rumor_AgentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Manage = new DelegateCommand<string>(SelectionManage);
        }
        #endregion

    }
}
