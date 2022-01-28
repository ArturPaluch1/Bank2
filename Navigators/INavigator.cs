using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.ComponentModel;

namespace Bank2.Navigators
{
    public interface INavigator
    {
        public enum RodzajBazy
        {
            SQLServer,
            Plik
        }
        public RodzajBazy rodzajBazy { get; set; }
        public event Action CurrentViewModelChanged;
        event PropertyChangedEventHandler PropertyChanged;

        ViewModelBase CurrentViewModel { get; set; }
        Pracownicy zalogowanyPracownik { get; set; }

    }
}
