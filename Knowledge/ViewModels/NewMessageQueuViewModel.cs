using Data;
using Domain.Entities;
using Domain.Information.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Knowledge.ViewModels
{
    public class NewMessageQueuViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<RumorQueue> RumorQueueAccess;
        public DataBaseAccess<RumorQueueConfig> RumorQueueConfigAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private RumorQueue _newItem;
        public RumorQueue NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //谣言队列配置
        private ObservableCollection<RumorQueueConfig> _rumorQueueConfigs;
        public ObservableCollection<RumorQueueConfig> RumorQueueConfigs
        {
            get { return _rumorQueueConfigs; }
            set 
            { 
                SetProperty(ref _rumorQueueConfigs, value);
            }
        }
        //可选择谣言列表
        private ObservableCollection<Rumor> _rumors;
        public ObservableCollection<Rumor> Rumors
        {
            get { return _rumors; }
            set 
            { 
                SetProperty(ref _rumors, value);
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
            var temp = new DataBaseAccess<Rumor>().GetAll().ToList();
            Rumors = new();
            foreach(var item in temp ) 
            {
                Rumors.Add(item);
            }
            
            //基础信息初始化
            NewItem = new RumorQueue()
            {
                Guid = Guid.NewGuid(),
            };
            RumorQueueConfigs = new();
        }
        #endregion

        #region Add和Delete操作
        public DelegateCommand<Rumor> AddRumor { get; private set; }
        public void AddRumorMethod(Rumor rumor)
        {
            if (rumor!=null) 
            {
                RumorQueueConfigs.Add(new RumorQueueConfig()
                {
                    Guid = Guid.NewGuid(),
                    Rumor = rumor,
                    RumorQueue = NewItem
                });
                Rumors.Remove(rumor);
            }
        }
        public DelegateCommand<RumorQueueConfig> DeleteRumor { get; private set; }
        public void DeleteRumorMethod(RumorQueueConfig rumorQueueConfig)
        {
            if(rumorQueueConfig != null)
            {
                Rumors.Add(rumorQueueConfig.Rumor);
                RumorQueueConfigs.Remove(rumorQueueConfig);
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
            if (RumorQueueConfigs.Count > 0)
            {
                RumorQueueAccess = new();
                RumorQueueConfigAccess = new();
                NewItem.CreateTime = DateTime.Now;
                RumorQueueAccess.Add(NewItem);
                for (int i = 0; i < RumorQueueConfigs.Count; i++)
                {
                    RumorQueueConfigs[i].Ordinal = i;
                    RumorQueueConfigAccess.Add(RumorQueueConfigs[i]);
                }
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
        }

        #endregion

        #region Main
        public NewMessageQueuViewModel()
        {
            InitialNewItem();
            AddRumor = new DelegateCommand<Rumor>(AddRumorMethod);
            DeleteRumor = new DelegateCommand<RumorQueueConfig>(DeleteRumorMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion
    }
}
