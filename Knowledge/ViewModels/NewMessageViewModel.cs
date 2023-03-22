using agent.ViewModels;
using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Knowledge.ViewModels
{
    public class NewMessageViewModel : BindableBase
    {
        #region 新建谣言方案
        //定义谣言
        private Rumor _newItem;
        public Rumor NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //定义征兆
        private Omen _omen;
        public Omen Omen
        {
            get { return _omen; }
            set { SetProperty(ref _omen, value); }
        }
        //定义危机
        private ObservableCollection<Crisis> _crisis;
        public ObservableCollection<Crisis> Crisis
        {
            get { return _crisis; }
            set { SetProperty(ref _crisis, value); }
        }
        //定义后果
        private Result _result;
        public Result Result
        {
            get { return _result; }
            set
            { SetProperty(ref _result, value); }
        }
        #endregion

        #region 征兆细节信息
        public IList<OmenValue> OmenValues { get; set; }

        private ObservableCollection<AnimalConfig> _animalConfigs;
        public ObservableCollection<AnimalConfig> AnimalConfigs
        {
            get { return _animalConfigs; }
            set { SetProperty(ref _animalConfigs, value); }
        }
        private ObservableCollection<ClimateConfig> _climateConfigs;
        public ObservableCollection<ClimateConfig> ClimateConfigs
        {
            get { return _climateConfigs; }
            set { SetProperty(ref _climateConfigs, value); }
        }

        private ObservableCollection<ElectroConfig> _electroConfigs;
        public ObservableCollection<ElectroConfig> ElectroConfigs
        {
            get { return _electroConfigs; }
            set { SetProperty(ref _electroConfigs, value); }
        }

        private ObservableCollection<GroundConfig> _groundConfigs;
        public ObservableCollection<GroundConfig> GroundConfigs
        {
            get { return _groundConfigs; }
            set { SetProperty(ref _groundConfigs, value); }
        }

        private ObservableCollection<GroundwaterConfig> _groundwaterConfigs;
        public ObservableCollection<GroundwaterConfig> GroundwaterConfigs
        {
            get { return _groundwaterConfigs; }
            set { SetProperty(ref _groundwaterConfigs, value); }
        }


        #endregion

        #region 危机细节信息
        private Crisis _selectedCrisis;
        public Crisis SelectedCrisis
        {
            get { return _selectedCrisis; }
            set { SetProperty(ref _selectedCrisis, value); }
        }
        public IList<CrisisType> crisisTypes { get; set; }
        public IList<CrisisFrequence> crisisFrequences { get; set; }
        public IList<CrisisLevel> crisisLevels { get; set; }
        public IList<CrisisPersistentTime> crisisPersistentTimes { get; set; }
        public IList<CrisisTimeSpan> crisisTimeSpans { get; set; }

        #endregion

        #region 后果细节信息
        public IList<Casualty> casualties { get; set; }
        public IList<MinorCasualty> minorCasualties { get; set; }
        public IList<BuildingLoss> buildingLosses { get; set; }
        public IList<EconomyLoss> economyLosses { get; set; }
        public IList<ImpactOfDaily> impactOfDailies { get; set; }
        public IList<PersistentTime> persistentTimes { get; set; }
        public IList<InfluenceScope> influenceScopes { get; set; }

        #endregion

        #region 报错提示
        private Visibility _warning;
        public Visibility Warning
        {
            get { return _warning; }
            set { SetProperty(ref _warning, value); }
        }
        #endregion
        #region 切换下一步
        private int _tabIndex;
        public int TabIndex
        {
            get { return _tabIndex; }
            set { SetProperty(ref _tabIndex, value); }
        }
        #endregion

        #region 初始化
        private void InitialNewItem()
        {
            Warning = Visibility.Hidden;
            TabIndex = 0;
            #region 相关配置数据
            IList<AnimalAnomaly> animalAnomalies = new DataBaseAccess<AnimalAnomaly>().GetAllByOrder();
            IList<ClimateAnomaly> climateAnomalies = new DataBaseAccess<ClimateAnomaly>().GetAllByOrder();
            IList<ElectroAnomaly> electroAnomalies = new DataBaseAccess<ElectroAnomaly>().GetAllByOrder();
            IList<GroundAnomaly> groundAnomalies = new DataBaseAccess<GroundAnomaly>().GetAllByOrder();
            IList<GroundwaterAnomaly> groundwaterAnomalies = new DataBaseAccess<GroundwaterAnomaly>().GetAllByOrder();

            crisisTypes = new DataBaseAccess<CrisisType>().GetAllByOrder();
            crisisFrequences = new DataBaseAccess<CrisisFrequence>().GetAll();
            crisisLevels = new DataBaseAccess<CrisisLevel>().GetAll();
            crisisPersistentTimes = new DataBaseAccess<CrisisPersistentTime>().GetAll();
            crisisTimeSpans = new DataBaseAccess<CrisisTimeSpan>().GetAll();

            casualties = new DataBaseAccess<Casualty>().GetAll();
            minorCasualties = new DataBaseAccess<MinorCasualty>().GetAll();
            buildingLosses = new DataBaseAccess<BuildingLoss>().GetAll();
            economyLosses = new DataBaseAccess<EconomyLoss>().GetAll();
            impactOfDailies = new DataBaseAccess<ImpactOfDaily>().GetAll();
            persistentTimes = new DataBaseAccess<PersistentTime>().GetAll();
            influenceScopes = new DataBaseAccess<InfluenceScope>().GetAll();
            #endregion

            #region 基础信息初始化
            NewItem = new Rumor()
            {
                Guid = Guid.NewGuid()
            };
            #endregion

            #region 征兆信息初始化
            Omen = new Omen() { Guid = Guid.NewGuid(), Rumor = NewItem };
            OmenValues = new DataBaseAccess<OmenValue>().GetAll();

            AnimalConfigs = new();
            foreach (var i in animalAnomalies)
            {
                AnimalConfigs.Add(new AnimalConfig()
                {
                    Guid = Guid.NewGuid(),
                    AnimalAnomaly = i,
                    Omen = Omen,
                    Value = null
                });
            }

            ClimateConfigs = new();
            foreach(var i in climateAnomalies)
            {
                ClimateConfigs.Add(new ClimateConfig()
                {
                    Guid = Guid.NewGuid(),
                    ClimateAnomaly = i,
                    Omen = Omen,
                    Value = null
                });
            }

            ElectroConfigs = new();
            foreach (var i in electroAnomalies)
            {
                ElectroConfigs.Add(new ElectroConfig()
                {
                    Guid = Guid.NewGuid(),
                    ElectroAnomaly = i,
                    Omen = Omen,
                    Value = null
                });
            }

            GroundConfigs = new();
            foreach(var i in groundAnomalies)
            {
                GroundConfigs.Add(new GroundConfig()
                {
                    Guid = Guid.NewGuid(),
                    GroundAnomaly = i,
                    Omen = Omen,
                    Value = null
                });
            }

            GroundwaterConfigs= new();
            foreach(var i in groundwaterAnomalies)
            {
                GroundwaterConfigs.Add(new GroundwaterConfig()
                {
                    Guid = Guid.NewGuid(),
                    GroundwaterAnomaly = i,
                    Omen = Omen,
                    Value = null
                });
            }

            #endregion

            #region 危机信息初始化
            Crisis = new();
            foreach (var i in crisisTypes)
            {
                Crisis crisis = new Crisis()
                {
                    Guid = Guid.NewGuid(),
                    IsAdd = false,
                    Type = i,
                    Rumor = NewItem
                    
                };
                Crisis.Add(crisis);                
            }
            #endregion

            #region 后果信息初始化
            Result = new Result() { Guid = Guid.NewGuid(), Rumor = NewItem };
            
            #endregion

        }
        #endregion

        #region 第一步：基础信息配置
        public DelegateCommand Next1 { get; private set; }
        public void Next1Method()
        {
            if (string.IsNullOrWhiteSpace(NewItem.Name) ||
                string.IsNullOrWhiteSpace(NewItem.CreateName))
            {
                Warning = Visibility.Visible;
            }
            else
            {
                Warning = Visibility.Hidden;
                TabIndex = 1;
            }
        }
        #endregion

        #region 第二步：征兆信息配置
        public DelegateCommand Next2 { get; private set; }
        public void Next2Method()
        {
            TabIndex = 2;
        }
        #endregion

        #region 第三步：危机信息配置
        public DelegateCommand Next3 { get; private set; }
        public void Next3Method()
        {
            TabIndex = 3;
        }
        #endregion

        #region 第四步：完成新建
        public DelegateCommand Finish { get; private set; }
        public void FinishMethod()
        {
            TabIndex = 3;
        }
        #endregion


        public NewMessageViewModel()
        {
            InitialNewItem();
            Next1 = new DelegateCommand(Next1Method);
            Next2 = new DelegateCommand(Next2Method);
            Next3 = new DelegateCommand(Next3Method);
            Finish = new DelegateCommand(FinishMethod);
        }

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
