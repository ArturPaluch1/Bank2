using Bank2.Navigators;

namespace Bank2.ViewModel
{
    class VMPracownikPracownicy : ViewModelBase
    {
        private INavigator _navigator;
        public VMPracownikPracownicy(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
