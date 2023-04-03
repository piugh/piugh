using Data;
using Domain.Entities;
using Domain.Network.Entities;
using NHibernate.Mapping;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Network.ViewModels
{
    public class NewNetConfigViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<NetworkSch> NetworkSchAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private NetworkSch _newItem;
        public NetworkSch NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //网络结构方案
        private List<NetworkModel> _netWorkModels;
        public List<NetworkModel> NetWorkModels
        {
            get { return _netWorkModels; }
            set { SetProperty(ref _netWorkModels, value); }
        }
        //网络参数方案
        private ObservableCollection<ModelPara> _modelParas;
        public ObservableCollection<ModelPara> ModelParas
        {
            get { return _modelParas; }
            set { SetProperty(ref _modelParas, value); }
        }
        //个体集方案
        private List<AgentSet> _agentSets;
        public List<AgentSet> AgentSets
        {
            get { return _agentSets; }
            set { SetProperty(ref _agentSets, value); }
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
            NetWorkModels = new DataBaseAccess<NetworkModel>().GetAll().ToList();

            AgentSets = new DataBaseAccess<AgentSet>().GetAll().ToList();

            //基础信息初始化
            NewItem = new NetworkSch()
            {
                Guid = Guid.NewGuid(),
            };
        }
        #endregion

        #region 选定网络结构
        public DelegateCommand<NetworkModel> SelectedNetWorkModel { get; private set; }
        public void SelectedNetWorkModelMethod(NetworkModel model)
        {
            NewItem.NetworkModel = model;
            //生成对应的网络参数方案
            ModelParas = new();
            var temp = new DataBaseAccess<ModelPara>().GetByCondition(model, "NetworkModel");
            foreach(var item in temp ) 
            {
                ModelParas.Add(item);
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
            if (NewItem.NetworkModel != null && NewItem.AgentSet != null && NewItem.ModelPara != null)
            {
                NewItem.CreateTime = DateTime.Now;
                NetworkSchAccess = new();
                NetworkSchAccess.Add(NewItem);
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
            else
                Warning = Visibility.Visible;
        }

        #endregion

        #region Main
        public NewNetConfigViewModel()
        {
            InitialNewItem();
            SelectedNetWorkModel = new DelegateCommand<NetworkModel>(SelectedNetWorkModelMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion
    }
}
