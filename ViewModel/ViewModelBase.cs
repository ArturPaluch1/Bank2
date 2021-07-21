using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bank2.ViewModel
{
    public class ViewModelBase : INavigator
    {
        public ViewModelBase CurrentViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action CurrentViewModelChanged;
    }
}
