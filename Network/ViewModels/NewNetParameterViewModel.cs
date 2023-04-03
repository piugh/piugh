using Data;
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
    public class NewNetParameterViewModel : BindableBase
    {
        #region 数据接口
        public DataBaseAccess<ModelPara> ModelParaAccess;
        public DataBaseAccess<ModelParaConfig> ModelParaConfigAccess;
        #endregion

        #region 新建方案数据
        //新建方案
        private ModelPara _newItem;
        public ModelPara NewItem
        {
            get { return _newItem; }
            set { SetProperty(ref _newItem, value); }
        }
        //网络参数配置
        private ObservableCollection<ModelParaConfig> _modelParaConfigs;
        public ObservableCollection<ModelParaConfig> ModelParaConfigs
        {
            get { return _modelParaConfigs; }
            set { SetProperty(ref _modelParaConfigs, value); }
        }
        //可选网络结构
        private List<NetworkModel> _netWorkModels;
        public List<NetworkModel> NetWorkModels
        {
            get { return _netWorkModels; }
            set { SetProperty(ref _netWorkModels, value); }
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

            //基础信息初始化
            NewItem = new ModelPara()
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
            ModelParaConfigs = new();
            foreach(var i in model.OptionalParaConfigs)
            {
                ModelParaConfigs.Add(new ModelParaConfig
                {
                    Guid = Guid.NewGuid(),
                    ModelPara = NewItem,
                    OptionalParaConfig = i,
                    Value = "0"
                }) ;
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
            if(NewItem.NetworkModel !=null)
            {
                NewItem.CreateTime = DateTime.Now;
                ModelParaAccess = new();
                ModelParaConfigAccess = new();
                ModelParaAccess.Add(NewItem);
                for (int i = 0; i < ModelParaConfigs.Count; i++)
                {
                    ModelParaConfigAccess.Add(ModelParaConfigs[i]);
                }
                NHibernateHelper.CloseSession();
                newwindow.Close();
            }
            else
                Warning= Visibility.Visible;
        }

        #endregion

        #region Main
        public NewNetParameterViewModel()
        {
            InitialNewItem();
            SelectedNetWorkModel = new DelegateCommand<NetworkModel>(SelectedNetWorkModelMethod);
            Next1 = new DelegateCommand(Next1Method);
            Finish = new DelegateCommand<Window>(FinishMethod);
        }
        #endregion
    }
}
