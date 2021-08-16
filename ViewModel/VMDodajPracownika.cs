using Bank2.Commands;
using Bank2.Navigators;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajPracownika : ViewModelBase
    {
        private string _password;
        private decimal _wynagrodzenie;

        private ICommand _dodaj;

        public ICommand Dodaj
        {
            get
            {
                return _dodaj;
            }
            set
            {
                _dodaj = value;
            }
        }

        public ICommand Anuluj { get; private set; }

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

        private string _imie;

        private string _nazwisko;
        private string _Telefon;
        private string _Pesel;

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
        public string Pesel
        {
            get
            {
                return _Pesel;
            }
            set
            {
                _Pesel = value;
                OnPropertyChanged(nameof(Pesel));

                ValidatePesel(Pesel);
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
        public decimal Wynagrodzenie
        {
            get
            {
                return _wynagrodzenie;
            }
            set
            {



                _wynagrodzenie = value;





                OnPropertyChanged(nameof(Wynagrodzenie));

                ValidateWynagrodzenie(Wynagrodzenie);
            }
        }






        public VMDodajPracownika(INavigator navigator)
        {
            //Dodaj = new RelayCommand(new Action(ShowMessage));
            Dodaj = new DodajPracownikaCommand<VMLogowanie>(this, navigator, () => new VMLogowanie(navigator));
            Anuluj = new UpdateCurrentViewModelCommand<VMLogowanie>(navigator, () => new VMLogowanie(navigator));
            Password = "";
            Imie = "";
            Nazwisko = "";
            Pesel = "";
            Telefon = "";
            Wynagrodzenie = 0;

        }




    }

}
