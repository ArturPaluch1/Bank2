using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.ComponentModel;

namespace Bank2.Navigators
{
    public class Navigator : INavigator//, INotifyPropertyChanged

    {
        public Pracownicy zalogowanyPracownik { get; set; }
        private ViewModelBase _currentViewModel;
        public event Action CurrentViewModelChanged;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;


            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        //   public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand<_currentViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        /*  protected void OnPropertyChanged(string propertyName)
          {
              if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
              //28,05
          }*/
    }
}

