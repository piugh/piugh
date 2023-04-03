using Domain;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.ViewModels
{
    public class BaseInfoViewModel : BindableBase
    {
        private InfoData _selectedItem;
        public InfoData SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public BaseInfoViewModel()
        {

        }
    }
}
