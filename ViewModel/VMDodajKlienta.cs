
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajKlienta : ViewModelBase
    {

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
        public string Telefon
        {
            get
            {
                return _Telefon;
            }
            set
            {
                _Telefon = value;
                OnPropertyChanged(nameof(Telefon));
                ValidateTelefon(Telefon);
            }
        }
        public string Miasto
        {
            get
            {
                return _Miasto;
            }
            set
            {
                _Miasto = value;
                OnPropertyChanged(nameof(Miasto));
                ValidateMiasto(Miasto);
            }
        }
        public string Ulica
        {
            get
            {
                return _Ulica;
            }
            set
            {
                _Ulica = value;
                OnPropertyChanged(nameof(Ulica));
                ValidateUlica(Ulica);
            }
        }

        private Window _window;
        private string _imie;
        private string _nazwisko;
        private string _password;
        private string _Telefon;
        private string _Miasto;
        private string _Ulica;

        public ICommand Dodaj { get; set; }
        public ICommand Anuluj { get; set; }

        public string Error => throw new NotImplementedException();

        private Baza _db;
        public VMDodajKlienta(Window window, INavigator navigator)
        {
            _db = new Baza(navigator.rodzajBazy.ToString());
            _window = window;
            Dodaj = new RelayCommand(DodajKlienta);
            Anuluj = new RelayCommand(ZamknijOkno);

            Password = "";
            Imie = "";
            Nazwisko = "";
            Telefon = "";
            Miasto = "";
            Ulica = "";




        }

        private void ZamknijOkno()
        {

            _window.Close();
        }

        private void DodajKlienta()
        {
    
            Klienci temp = new Klienci();
            temp.Imię = this.Imie;
            temp.Nazwisko = this.Nazwisko;
            temp.Password = this.Password;
            temp.Data_założenia = DateTime.Now;
            temp.Miasto = this.Miasto;
            temp.Ulica = this.Ulica;
            _db.Klienci.Add(temp);
            _db.SaveChanges();
            MessageBoxResult result = MessageBox.Show("Dodany", "", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                _window.Close();
            }

        }


    }


}
