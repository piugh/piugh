using agent.Data;
using Domain.Entities;
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
    public class ExperienceViewModel : BindableBase, INavigationAware
    {
        #region 当前选中的方案
        //所选个体集方案个体列表
        private Rumor _selectedItem;
        public Rumor SelectedItem
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
        
        }
        #endregion

        #region Main
        public ExperienceViewModel()
        {
        }
        #endregion

        #region 导航拦截传参
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedItem = (Rumor)navigationContext.Parameters["SelectedItem"];
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
