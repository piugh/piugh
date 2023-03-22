using agent.Data;
using agent.Views;
using Data;
using Domain;
using Domain.Entities;
using Domain.Information.Entities;
using Knowledge.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Resource.ViewModels
{  
    public class ViewAViewModel : BindableBase, INavigationAware
    {
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
        private List<InfoData> _myItem;
        public List<InfoData> MyItem 
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
        #endregion

        public dynamic DataAccess;

        #region 初始化
        public void Initialize()
        {
            //获取字典
            GetRumorDic();
            //获取方案数据
            string TypeName = RumorDic[TypeNamePara][0];
            Listtitle = RumorDic[TypeNamePara][1];
            DataAccess = DataAccessFactory.CreateAccess(TypeName);
            MyItem = new();
            var temp = DataAccess.GetAll();
            foreach (var item in temp)
            {
                MyItem.Add(item as Domain.InfoData);
            }
        }
        #endregion

        #region 方案选择变化
        private InfoData _selectedItem;
        public InfoData SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
        public DelegateCommand<InfoData> SelectedItemChange { get; private set; }
        public void SelectionChange(InfoData Item)
        {
            SelectedItem = Item;
            //一定记得要清除region 
            IRegion region = _regionManager.Regions["DetialOfItem"];
            region.RemoveAll();
            string detailView = RumorDic[TypeNamePara][2];
            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("SelectedItem", SelectedItem);
            _regionManager.RequestNavigate("DetialOfItem", detailView, parameter);
        }
        #endregion

        #region 方案操作：增删改
        public DelegateCommand NewItemCommand { get; private set; }
        public DelegateCommand DeleteItemCommand { get; private set; }
        public DelegateCommand<string> CopyItemCommand { get; private set; }

        public void NewItem()
        {
            switch (TypeNamePara)
            {
                case "Proportion":
                    {
                        NewProportion newProportion = new NewProportion();
                        newProportion.ShowDialog();
                        //Initialize(); //不能有，不然会和selecchange冲突
                        break;
                    }
                case "InitialAgent":
                    {
                        NewInitialAgent newInitialAgent = new NewInitialAgent();
                        newInitialAgent.ShowDialog();
                        break;
                    }

                case "Message":
                    {
                        NewMessage newMessage = new NewMessage();
                        newMessage.ShowDialog();
                        break;
                    }
                default:
                    return;
            }

        }
        public void DeleteItem()
        {
            if(SelectedItem != null)
            {
                //DataAccess.Delete(SelectedItem);
            }
        }

        public void CopyItem(string proportionItem)
        {
        }
        #endregion

        
        #region Main
        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SelectedItemChange = new DelegateCommand<InfoData>(SelectionChange);
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

        #region 导航字典创建
        public Dictionary<string, List<string>> RumorDic { get; private set; }
        public void GetRumorDic()
        {
            RumorDic = new Dictionary<string, List<string>>();
            RumorDic.Add("Proportion", new List<string> { typeof(DataBaseAccess<AgentSetProportion>).AssemblyQualifiedName, "已有统计比例方案", "Proportion" });
            RumorDic.Add("InitialAgent", new List<string> { typeof(DataBaseAccess<AgentSet>).AssemblyQualifiedName, "已有初始个体集方案", "InitialAgent" });
            RumorDic.Add("LearnAgent", new List<string> { typeof(DataBaseAccess<AgentLearningSch>).AssemblyQualifiedName, "已有个体学习方案", "LearnAgent" });
            RumorDic.Add("Message", new List<string> { typeof(DataBaseAccess<Rumor>).AssemblyQualifiedName, "已有谣言方案", "Message" });
            RumorDic.Add("MessageQueue", new List<string> { typeof(DataBaseAccess<RumorQueue>).AssemblyQualifiedName, "已有谣言队列方案", "MessageQueu" });

        }
        #endregion

    }
}
