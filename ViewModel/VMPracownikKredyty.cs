using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank2.Navigators;

namespace Bank2.ViewModel
{
    class VMPracownikKredyty : ViewModelBase
    {
        private INavigator _navigator;
        public VMPracownikKredyty(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
