using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank2.Navigators;

namespace Bank2.ViewModel
{
    class VMPracownikLokaty : ViewModelBase
    {
        private INavigator _navigator;
        public VMPracownikLokaty(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
