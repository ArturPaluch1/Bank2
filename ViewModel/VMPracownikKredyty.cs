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
