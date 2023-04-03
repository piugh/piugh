using Data;
using Domain.Information.Entities;
using Domain.Network.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Network.ViewModels
{
    public class NewNetStructureViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<NetworkModel> NetworkModelAccess;
        public DataBaseAccess<OptionalParaConfig> OptionalParaConfigAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private NetworkModel _newItem;
        public NetworkModel NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //参数队列配置
        private ObservableCollection<OptionalParaConfig> _optionalParaConfigs;
        public ObservableCollection<OptionalParaConfig> OptionalParaConfigs
        {
            get { return _optionalParaConfigs; }
            set
            {
                SetProperty(ref _optionalParaConfigs, value);
            }
        }
        //可选择参数列表
        private ObservableCollection<OptionalPara> _optionalParas;
        public ObservableCollection<OptionalPara> OptionalParas
        {
            get { return _optionalParas; }
            set
            {
                SetProperty(ref _optionalParas, value);
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
            var temp = new DataBaseAccess<OptionalPara>().GetAll().ToList();
            OptionalParas = new();
            foreach (var item in temp)
            {
                OptionalParas.Add(item);
            }

            //基础信息初始化
            NewItem = new NetworkModel()
            {
                Guid = Guid.NewGuid(),
            };
            OptionalParaConfigs = new();
        }
        #endregion

        #region Add和Delete操作
        public DelegateCommand<OptionalPara> AddOptionalPara { get; private set; }
        public void AddOptionalParaMethod(OptionalPara optionalPara)
        {
            if (optionalPara != null)
            {
                OptionalParaConfigs.Add(new OptionalParaConfig()
                {
                    Guid = Guid.NewGuid(),
                    OptionalPara = optionalPara,
                    NetworkModel = NewItem
                });
                OptionalParas.Remove(optionalPara);
            }
        }
        public DelegateCommand<OptionalParaConfig> DeleteOptionalPara { get; private set; }
        public void DeleteOptionalParaMethod(OptionalParaConfig optionalParaConfig)
        {
            if (optionalParaConfig != null)
            {
                OptionalParas.Add(optionalParaConfig.OptionalPara);
                OptionalParaConfigs.Remove(optionalParaConfig);
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
            if (OptionalParaConfigs.Count > 0)
            {
                NetworkModelAccess = new();
                OptionalParaConfigAccess = new();
                NewItem.CreateTime = DateTime.Now;
                NetworkModelAccess.Add(NewItem);
                for (int i = 0; i < OptionalParaConfigs.Count; i++)
                {
                    OptionalParaConfigAccess.Add(OptionalParaConfigs[i]);
                }
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
            else
                Warning= Visibility.Visible;
        }

        #endregion

        #region Main
        public NewNetStructureViewModel()
        {
            InitialNewItem();
            AddOptionalPara = new DelegateCommand<OptionalPara>(AddOptionalParaMethod);
            DeleteOptionalPara = new DelegateCommand<OptionalParaConfig>(DeleteOptionalParaMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion
    }
}
