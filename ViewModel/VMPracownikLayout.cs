using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.ViewModel
{
    class VMPracownikLayout:ViewModelBase
    {

        private INavigator _navigator;
        public VMPracownikLayout(INavigator navigator) 
        {
            _navigator = navigator;
        }
    }
}
