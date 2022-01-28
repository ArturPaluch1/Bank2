namespace Bank2.ViewModel
{
    using Bank2.Navigators;

    using System.ComponentModel;

    public class VMMainWindow : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        private readonly INavigator _navigator;

      





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwa)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }

        public VMMainWindow(INavigator navigator)
        {



            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentVieModelChanged;




        }

        private void OnCurrentVieModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
