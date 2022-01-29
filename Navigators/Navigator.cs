using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.ComponentModel;
using static Bank2.Navigators.INavigator;


namespace Bank2.Navigators
{
    public class Navigator : INavigator


    {


        public RodzajBazy rodzajBazy { get; set; } 

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
        public event PropertyChangedEventHandler PropertyChanged;

    }
}

