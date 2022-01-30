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

        public INavigator.RodzajBazy rodzajBazy { get; set; }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}

