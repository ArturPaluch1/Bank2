using Bank2.Commands;
using Bank2.Navigators;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    public class VMLogowanie : ViewModelBase
    {
        private string _imie;
        private string _nazwisko;
        private string _password;




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





       
        public VMLogowanie(INavigator navigator)
        {
            Zarejestruj = new UpdateCurrentViewModelCommand<VMDodajPracownika>(navigator, () => new VMDodajPracownika(navigator));
            Zaloguj = new ZalogujPracownikaCommand<VMPracownikNavigationBar>(navigator, () => new VMPracownikNavigationBar(navigator));

            Password = "";
            Imie = "";
            Nazwisko = "";
        }

    }


}
