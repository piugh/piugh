using agent.Data;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Network.ViewModels
{
    public class NetConfigViewModel : BindableBase
    {
        #region 所有方案数据
        private ObservableCollection<ProportionItem> _myitem;
        public ObservableCollection<ProportionItem> MyItem
        {
            get { return _myitem; }
            set { SetProperty(ref _myitem, value); }
        }
        #endregion

        #region 网络配置方案数据获取
        private void CreateNetConfigItem()
        {
            var myitem = new ObservableCollection<ProportionItem>();
            for (int i = 0; i < 10; i++)
            {
                myitem.Add(new ProportionItem()
                {
                    FirstName = String.Format("First {0}", i),
                    LastName = String.Format("Last {0}", i),
                    Age = i
                });
            }
            MyItem = myitem;
        }
        #endregion

        #region 当前选中的方案
        private ProportionItem _selectedItem;
        public ProportionItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }
        #endregion

        #region 方案选择改变
        public DelegateCommand<ProportionItem> SelectedItemChange { get; private set; }
        public void SelectionChange(ProportionItem proportionItem)
        {
            SelectedItem = proportionItem;
        }
        #endregion

        #region 方案操作：增删复制
        public DelegateCommand NewItemCommand { get; private set; }
        public DelegateCommand DeleteItemCommand { get; private set; }
        public DelegateCommand CopyItemCommand { get; private set; }

        public void NewItem()
        {

        }
        public void DeleteItem()
        {
            foreach (var item in MyItem)
            {
                if (item.FirstName == SelectedItem.FirstName)
                {
                    //aaaa不能用
                    //MyItem.Remove(item);                    
                    return;
                }
            }
        }
        public void CopyItem()
        {

        }
        #endregion

        public NetConfigViewModel()
        {
            CreateNetConfigItem();
            SelectedItemChange = new DelegateCommand<ProportionItem>(SelectionChange).ObservesProperty(() => MyItem);
            NewItemCommand = new DelegateCommand(NewItem).ObservesProperty(() => MyItem);
            DeleteItemCommand = new DelegateCommand(DeleteItem).ObservesProperty(() => MyItem);
            CopyItemCommand = new DelegateCommand(CopyItem).ObservesProperty(() => MyItem);
        }
    }
}
