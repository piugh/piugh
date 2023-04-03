using Data;
using Domain.Information.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Knowledge.ViewModels
{
    public class NewExperienceQueuViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<PropositionQueue> ExperienceQueueAccess;
        public DataBaseAccess<PropositionQueueConfig> ExperienceQueueConfigAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private PropositionQueue _newItem;
        public PropositionQueue NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //经验队列配置
        private ObservableCollection<PropositionQueueConfig> _experienceQueueConfigs;
        public ObservableCollection<PropositionQueueConfig> ExperienceQueueConfigs
        {
            get { return _experienceQueueConfigs; }
            set { SetProperty(ref _experienceQueueConfigs, value);}
        }
        //可选择经验列表
        private ObservableCollection<Proposition> _experiences;
        public ObservableCollection<Proposition> Experiences
        {
            get { return _experiences; }
            set
            {
                SetProperty(ref _experiences, value);
            }
        }
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
            //相关配置数据            
            var temp = new DataBaseAccess<Proposition>().GetAll().ToList();
            Experiences = new();
            foreach (var item in temp)
            {
                Experiences.Add(item);
            }

            //基础信息初始化
            NewItem = new PropositionQueue()
            {
                Guid = Guid.NewGuid(),
            };
            ExperienceQueueConfigs = new();
        }
        #endregion

        #region Add和Delete操作
        public DelegateCommand<Proposition> AddExperience { get; private set; }
        public void AddExperienceMethod(Proposition proposition)
        {
            if (proposition != null)
            {
                ExperienceQueueConfigs.Add(new PropositionQueueConfig()
                {
                    Guid = Guid.NewGuid(),
                    Proposition = proposition,
                    PropositionQueue = NewItem
                });
                Experiences.Remove(proposition);
            }
        }
        public DelegateCommand<PropositionQueueConfig> DeleteExperience { get; private set; }
        public void DeleteExperienceMethod(PropositionQueueConfig experienceQueueConfig)
        {
            if (experienceQueueConfig != null)
            {
                Experiences.Add(experienceQueueConfig.Proposition);
                ExperienceQueueConfigs.Remove(experienceQueueConfig);
            }
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

        #region 第二步：完成配置
        public DelegateCommand<Window> Finish { get; private set; }
        public void FinishMethod(Window newwindow)
        {
            if (ExperienceQueueConfigs.Count > 0)
            {
                ExperienceQueueAccess = new();
                ExperienceQueueConfigAccess = new();
                NewItem.CreateTime = DateTime.Now;
                ExperienceQueueAccess.Add(NewItem);
                for (int i = 0; i < ExperienceQueueConfigs.Count; i++)
                {
                    ExperienceQueueConfigs[i].Ordinal = i;
                    ExperienceQueueConfigAccess.Add(ExperienceQueueConfigs[i]);
                }
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
        }

        #endregion

        #region Main
        public NewExperienceQueuViewModel()
        {
            InitialNewItem();
            AddExperience = new DelegateCommand<Proposition>(AddExperienceMethod);
            DeleteExperience = new DelegateCommand<PropositionQueueConfig>(DeleteExperienceMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion
        
    }
}
