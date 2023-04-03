using agent.Views;
using Data;
using Domain.Entities;
using Domain.Information.Entities;
using Domain.Network.Entities;
using Domain;
using Knowledge.Views;
using Network.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Rumor.ViewModels
{
    public class ListOfItemViewModel : BindableBase, INavigationAware
    {
        #region 数据接口
        public dynamic DataAccess;
        #endregion

        #region 注入视图
        private readonly IRegionManager _regionManager;
        #endregion

        #region 接收的参数
        private string _typeNamePara;
        public string TypeNamePara
        {
            get { return _typeNamePara; }
            set { SetProperty(ref _typeNamePara, value); }
        }
        #endregion

        #region 方案数据
        //全部方案
        private ObservableCollection<InfoData> _myItem;
        public ObservableCollection<InfoData> MyItem
        {
            get { return _myItem; }
            set { SetProperty(ref _myItem, value); }
        }
        //list标题
        private string _listtitle;
        public string Listtitle
        {
            get { return _listtitle; }
            set { SetProperty(ref _listtitle, value); }
        }

        private Type type;
        #endregion

        #region 方案选择
        private InfoData _selectedItem;
        public InfoData SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem && value != null)
                {
                    SetProperty(ref _selectedItem, value);
                    IRegion region = _regionManager.Regions["DetialOfItem"];
                    region.RemoveAll();
                    string detailView = RumorDic[TypeNamePara][2];
                    NavigationParameters parameter = new NavigationParameters();
                    parameter.Add("SelectedItem", SelectedItem);
                    _regionManager.RequestNavigate("DetialOfItem", detailView, parameter);
                }
            }
        }
        #endregion

        #region 初始化
        public void Initialize()
        {
            //获取方案数据
            string TypeName = RumorDic[TypeNamePara][0];
            Listtitle = RumorDic[TypeNamePara][1];
            DataAccess = DataAccessFactory.CreateAccess(TypeName);
            MyItem = new();
            var temp = DataAccess.GetAll();
            foreach (var item in temp)
            {
                if (item.GetType() != type)
                {
                    type = item.GetType();
                }
                MyItem.Add(item as Domain.InfoData);
            }
        }
        #endregion

        #region 方案操作：增删改
        #region 新建方案
        public DelegateCommand NewItemCommand { get; private set; }
        public void NewItem()
        {
            switch (TypeNamePara)
            {
                #region 个体模块
                case "Proportion":
                    {
                        NewProportion newProportion = new NewProportion();
                        newProportion.ShowDialog();
                        break;
                    }
                case "InitialAgent":
                    {
                        NewInitialAgent newInitialAgent = new NewInitialAgent();
                        newInitialAgent.ShowDialog();
                        break;
                    }
                case "LearnAgent":
                    {
                        NewLearnAgent newLearnAgent = new NewLearnAgent();
                        newLearnAgent.ShowDialog();
                        break;
                    }
                #endregion
                #region 网络模块
                case "NetStructure":
                    {
                        NewNetStructure newNetStructure = new NewNetStructure();
                        newNetStructure.ShowDialog();
                        break;
                    }
                case "NetParameter":
                    {
                        NewNetParameter newNetParameter = new NewNetParameter();
                        newNetParameter.ShowDialog();
                        break;
                    }
                case "NetConfig":
                    {
                        NewNetConfig newNetConfig = new NewNetConfig();
                        newNetConfig.ShowDialog();
                        break;
                    }
                #endregion
                #region 消息模块
                case "Message":
                    {
                        NewMessage newMessage = new NewMessage();
                        newMessage.ShowDialog();
                        break;
                    }
                case "MessageQueue":
                    {
                        NewMessageQueu newMessageQueu = new NewMessageQueu();
                        newMessageQueu.ShowDialog();
                        break;
                    }
                case "Experience":
                    {
                        NewExperience newExperience = new NewExperience();
                        newExperience.ShowDialog();
                        break;
                    }
                case "ExperienceQueue":
                    {
                        NewExperienceQueu newExperienceQueu = new NewExperienceQueu();
                        newExperienceQueu.ShowDialog();
                        break;
                    }

                #endregion
                default:
                    return;
            }
            Initialize();
        }

        #endregion
        #region 删除方案
        public DelegateCommand DeleteItemCommand { get; private set; }
        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                DataAccess.Delete(type.Name, SelectedItem);
                Initialize();
            }
        }
        #endregion
        #region 复制方案
        public DelegateCommand<string> CopyItemCommand { get; private set; }
        public void CopyItem(string proportionItem)
        {
        }
        #endregion
        #endregion

        #region Main
        public ListOfItemViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NewItemCommand = new DelegateCommand(NewItem);
            DeleteItemCommand = new DelegateCommand(DeleteItem);
            CopyItemCommand = new DelegateCommand<string>(CopyItem);
        }
        #endregion

        #region 导航拦截传参（Main）
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            TypeNamePara = navigationContext.Parameters["TypeOfList"].ToString();
            IRegion region = _regionManager.Regions["DetialOfItem"];
            region.RemoveAll();
            //获取字典
            GetRumorDic();
            Initialize();
        }
        #endregion

        #region 允许导航（不用在意）
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();

        }
        #endregion

        #region 导航字典创建
        public Dictionary<string, List<string>> RumorDic { get; private set; }
        public void GetRumorDic()
        {
            RumorDic = new Dictionary<string, List<string>>();
            #region 个体字典
            RumorDic.Add("Proportion", new List<string> { typeof(DataBaseAccess<AgentSetProportion>).AssemblyQualifiedName, "已有统计比例方案", "Proportion" });
            RumorDic.Add("InitialAgent", new List<string> { typeof(DataBaseAccess<AgentSet>).AssemblyQualifiedName, "已有初始个体集方案", "InitialAgent" });
            RumorDic.Add("LearnAgent", new List<string> { typeof(DataBaseAccess<AgentLearningSch>).AssemblyQualifiedName, "已有个体学习方案", "LearnAgent" });
            #endregion
            #region 消息字典
            RumorDic.Add("Message", new List<string> { typeof(DataBaseAccess<Domain.Information.Entities.Rumor>).AssemblyQualifiedName, "已有谣言方案", "Message" });
            RumorDic.Add("MessageQueue", new List<string> { typeof(DataBaseAccess<RumorQueue>).AssemblyQualifiedName, "已有谣言队列方案", "MessageQueu" });
            RumorDic.Add("Experience", new List<string> { typeof(DataBaseAccess<Proposition>).AssemblyQualifiedName, "已有经验方案", "Experience" });
            RumorDic.Add("ExperienceQueue", new List<string> { typeof(DataBaseAccess<PropositionQueue>).AssemblyQualifiedName, "已有经验队列方案", "ExperienceQueu" });
            #endregion
            #region 网络字典
            RumorDic.Add("NetStructure", new List<string> { typeof(DataBaseAccess<NetworkModel>).AssemblyQualifiedName, "已有网络结构方案", "NetStructure" });
            RumorDic.Add("NetParameter", new List<string> { typeof(DataBaseAccess<ModelPara>).AssemblyQualifiedName, "已有网络参数方案", "NetParameter" });
            RumorDic.Add("NetConfig", new List<string> { typeof(DataBaseAccess<NetworkSch>).AssemblyQualifiedName, "已有网络配置方案", "NetConfig" });
            RumorDic.Add("NetResult", new List<string> { typeof(DataBaseAccess<NetworkResult>).AssemblyQualifiedName, "已有网络结果方案", "NetResult" });
            #endregion
            #region 计算实验字典
            RumorDic.Add("ExperimentItem", new List<string> { typeof(DataBaseAccess<Domain.Entities.Experiment>).AssemblyQualifiedName, "已有计算实验方案", "ExperimentItem" });
            RumorDic.Add("ExperimentResult", new List<string> { typeof(DataBaseAccess<Domain.Entities.ExperimentResult>).AssemblyQualifiedName, "已有计算实验结果", "ExperimentResult" });
            #endregion

        }
        #endregion

    }
}
