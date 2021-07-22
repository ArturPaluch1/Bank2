using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.ViewModel
{
    class VMPracownikKlienci:ViewModelBase
    {
        private INavigator _navigator;
        public VMPracownikKlienci(INavigator navigator)
        {
            _navigator = navigator;

        }
    }
}
