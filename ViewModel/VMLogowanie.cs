using Bank2.Commands;
using Bank2.Navigators;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    public class VMLogowanie : ViewModelBase
    {
        private string _imie;
        private string _nazwisko;
        private string _password;


        private INavigator _navigator;

        public string Imie
        {
            get
            {
                return _imie;
            }
            set
            {
                _imie = value;

                OnPropertyChanged(nameof(Imie));

                       ValidateImie(Imie);
            }
        }
       

        public string Nazwisko
        {
            get
            {
                return _nazwisko;
            }
            set
            {
                _nazwisko = value;

                OnPropertyChanged(nameof(Nazwisko));
                ValidateNazwisko(Nazwisko);
            }
        }



        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;

                OnPropertyChanged(nameof(Password));
                   ValidatePassword(Password);
            }
        }




      



        public ICommand Zarejestruj { get; set; }
        public ICommand Zaloguj { get; set; }
        public ICommand BazaDanychPlik { get; set; }
        public ICommand BazaDanychSQLServer { get; set; }





        public VMLogowanie(INavigator navigator)
        {
            _navigator = navigator;
            Zarejestruj = new UpdateCurrentViewModelCommand<VMDodajPracownika>(_navigator, () => new VMDodajPracownika(_navigator));
         
           _navigator.rodzajBazy = INavigator.RodzajBazy.SQLServer;
            Zaloguj = new ZalogujPracownikaCommand<VMPracownikNavigationBar>(_navigator, () => new VMPracownikNavigationBar(_navigator));
            BazaDanychPlik = new RelayCommand(UpdateDatabaseSourceToFile);
            BazaDanychSQLServer = new RelayCommand(UpdateDatabaseSourceToBazaDanychSQLServer);
             Password = "";
            Imie = "";
            Nazwisko = "";
        }

        private void UpdateDatabaseSourceToBazaDanychSQLServer()
        {
            _navigator.rodzajBazy = INavigator.RodzajBazy.SQLServer;
        }

        private void UpdateDatabaseSourceToFile()
        {
            _navigator.rodzajBazy = INavigator.RodzajBazy.Plik;
        }
    }


}
