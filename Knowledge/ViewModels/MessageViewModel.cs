using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Microsoft.VisualBasic;
using NHibernate.Util;
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
    public class MessageViewModel : BindableBase, INavigationAware
    {
        #region 数据接口
        public DataBaseAccess<Crisis> CrisisAccess;
        public DataBaseAccess<Omen> OmenAccess;
        public DataBaseAccess<Result> ResultAccess;
        #endregion

        #region 当前选中的方案
        //所选个体集方案个体列表
        private Rumor _selectedItem;
        public Rumor SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        #endregion

        #region 异常信息定义
        private Omen _omen;
        public Omen Omen
        {
            get { return _omen; }
            set { SetProperty(ref _omen, value); }
        }

        private ObservableCollection<AnimalConfig> _animalConfigs;
        public ObservableCollection<AnimalConfig> AnimalConfigs
        {
            get { return _animalConfigs; }
            set 
            {
                SetProperty(ref _animalConfigs, value);
            }
        }

        private ObservableCollection<ClimateConfig> _climateConfigs;
        public ObservableCollection<ClimateConfig> ClimateConfigs
        {
            get { return _climateConfigs; }
            set
            {
                SetProperty(ref _climateConfigs, value);
            }
        }

        private ObservableCollection<ElectroConfig> _electroConfigs;
        public ObservableCollection<ElectroConfig> ElectroConfigs
        {
            get { return _electroConfigs; }
            set
            {
                SetProperty(ref _electroConfigs, value);
            }
        }

        private ObservableCollection<GroundConfig> _groundConfigs;
        public ObservableCollection<GroundConfig> GroundConfigs
        {
            get { return _groundConfigs; }
            set
            {
                SetProperty(ref _groundConfigs,value);
            }
        }

        private ObservableCollection<GroundwaterConfig> _groundwaterConfigs;
        public ObservableCollection<GroundwaterConfig> GroundwaterConfigs
        {
            get { return _groundwaterConfigs; }
            set
            {
                SetProperty(ref _groundwaterConfigs, value);
            }
        }
        #endregion

        #region 危机信息定义
        private ObservableCollection<Crisis> _crisis;
        public ObservableCollection<Crisis> Crisis
        {
            get { return _crisis; }
            set
            {
                SetProperty(ref _crisis, value);
            }
        }

        private Crisis _selectCrisis;
        public Crisis SelectCrisis
        {
            get { return _selectCrisis; }
            set
            {
                SetProperty(ref _selectCrisis, value);
            }
        }
        #endregion

        #region 后果信息定义
        private Result _result;
        public Result Result
        {
            get { return _result; }
            set 
            { 
                SetProperty(ref _result, value);
            }
        }
        #endregion

        #region 初始化
        private void Initialization()
        {
            OmenAccess = new();
            Omen = new();
            AnimalConfigs = new ();
            ClimateConfigs = new();
            ElectroConfigs = new();
            GroundConfigs= new ();
            GroundwaterConfigs= new ();
            GetOmen();

            CrisisAccess = new();
            Crisis = new();
            GetCrisis();

            ResultAccess = new();
            GetResult();
        }
        #endregion

        #region 征兆信息获取
        public void GetOmen()
        {
            Omen = OmenAccess.GetByCondition(SelectedItem, "Rumor")[0];

            //动物异常
            var AnimalConfigs_temp = Omen.AnimalConfigs;
            foreach (AnimalConfig i in AnimalConfigs_temp)
            {
                if (i.IsAdd)
                {
                    AnimalConfigs.Add(i);
                }                
            }

            //气候异常
            var ClimateConfig_temp = Omen.ClimateConfigs;           
            foreach (ClimateConfig i in ClimateConfig_temp)
            {
                if (i.IsAdd)
                {
                    ClimateConfigs.Add(i);
                }
            }

            //电磁异常
            var ElectroConfig_temp = Omen.ElectroConfigs;
            foreach (ElectroConfig i in ElectroConfig_temp)
            {
                if (i.IsAdd)
                {
                    ElectroConfigs.Add(i);
                }
            }

            //地面异常
            var GroundConfig_temp = Omen.GroundConfigs;
            foreach (GroundConfig i in GroundConfig_temp)
            {
                if (i.IsAdd)
                {
                    GroundConfigs.Add(i);
                }
            }

            //地下水异常
            var GroundwaterConfig_temp = Omen.GroundwaterConfigs;
            foreach (GroundwaterConfig i in GroundwaterConfig_temp)
            {
                if (i.IsAdd)
                {
                    GroundwaterConfigs.Add(i);
                }
            }
        }
        #endregion

        #region 危机信息获取
        public void GetCrisis()
        {
            var Crisis_temp = CrisisAccess.GetByCondition(SelectedItem, "Rumor");
            foreach(Crisis i in Crisis_temp)
            {
                if (i.IsAdd)
                {
                    Crisis.Add(i);
                }              
            }
            if(Crisis.Count> 0)
            {
                SelectCrisis = Crisis[0];
            }           
        }
        public DelegateCommand<Crisis> SelectChangeCrisis { get; private set; }
        public void SelectedCrisisMethod(Crisis mycrisis)
        {
            SelectCrisis = mycrisis;
        }
        #endregion

        #region 后果信息获取
        public void GetResult()
        {
            Result = ResultAccess.GetByCondition(SelectedItem, "Rumor")[0];           
        }
        #endregion

        #region Main
        public MessageViewModel()
        {
            SelectChangeCrisis = new DelegateCommand<Crisis>(SelectedCrisisMethod);
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
    }
}
