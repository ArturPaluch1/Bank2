namespace Bank2.ViewModel
{
    using Bank2.Navigators;

    using System.ComponentModel;

    public class VMMainWindow : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        //  public INavigator Navigator { get; set; } = new Navigator();
        private readonly INavigator _navigator;

        private object _currentView;





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nazwa)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }


        //public object CurrentView
        //{
        //    get { return _currentView; }
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged("CurrentView");
        //    }
        //}

        public VMMainWindow(INavigator navigator)
        {
            //CurrentView = new LogowaniePage();


            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentVieModelChanged;




        }

        private void OnCurrentVieModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
