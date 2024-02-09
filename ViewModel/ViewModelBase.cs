using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using static Bank2.Navigators.INavigator;

namespace Bank2.ViewModel
{
    public abstract class ViewModelBase : INavigator, INotifyDataErrorInfo, INotifyPropertyChanged
    {


        public ViewModelBase CurrentViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Pracownicy zalogowanyPracownik { get; set; }


        //
        public bool ErrorFree
        {
            get { return _errorFree; }
            set
            {
                _errorFree = value;

                OnPropertyChanged(nameof(ErrorFree));
            }
        }
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();
        bool _errorFree;


        public Dictionary<string, List<string>> ErrorsByPropertyName
        {
            get
            {
                return _errorsByPropertyName;
            }
        }
        public bool HasErrors
        {
            get { return _errorsByPropertyName.Any(); }

        }

        public RodzajBazy rodzajBazy { get; set; }

        public event Action CurrentViewModelChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != null)
                return _errorsByPropertyName.ContainsKey(propertyName) ?
                _errorsByPropertyName[propertyName] : null;
            else return null;
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        protected void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        protected void OnPropertyChanged(string nazwa)
        {

            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }



        public void ValidateImie(string Imie)
        {
            Regex regImie = new Regex(@"^([a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]*)$");

            ClearErrors(nameof(Imie));
            if (string.IsNullOrWhiteSpace(Imie))
                AddError(nameof(Imie), "Imię nie może być puste.");
            if (Imie == null || Imie?.Length <= 2)
                AddError(nameof(Imie), "Imię musi mieć co najmiej 3 znaki.");
            if (!regImie.IsMatch(Imie))
                AddError(nameof(Imie), "Imię musi składać się wyłącznie z liter.");
            ErrorFree = !HasErrors;
        }

        public void ValidatePassword(string Password)
        {

            ClearErrors(nameof(Password));
            Regex regNazwisko = new Regex(@"[a-z0-9]*[^a-z0-9]{1,}[a-z0-9]*");
            if (!regNazwisko.IsMatch(Password))
                AddError(nameof(Password), "Hasło musi zawierać duże litery lub/i znaki specjalne.");
            if (string.IsNullOrWhiteSpace(Password))
                AddError(nameof(Password), "Hasło nie może być puste.");

            if (Password == null || Password?.Length <= 5)
                AddError(nameof(Password), "Hasło musi mieć co najmniej 5 znaków.");


            ErrorFree = !HasErrors;
        }

        public void ValidateNazwisko(string Nazwisko)
        {
            ClearErrors(nameof(Nazwisko));

            Regex regNazwisko = new Regex(@"^([a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]*)$");
            if (!regNazwisko.IsMatch(Nazwisko))
                AddError(nameof(Nazwisko), "Nazwisko musi składać się wyłącznie z liter.");
            if (string.IsNullOrWhiteSpace(Nazwisko))
                AddError(nameof(Nazwisko), "Nazwisko nie może być puste.");
            if (Nazwisko == null || Nazwisko?.Length <= 1)
                AddError(nameof(Nazwisko), "Nazwisko musi mieć co najmniej 2 znaki.");
            ErrorFree = !HasErrors;
        }
        public void ValidatePesel(string Pesel)
        {
            ClearErrors(nameof(Pesel));


            Regex regPesel = new Regex(@"^([0-9]*)$");
            if (!regPesel.IsMatch(Pesel))
                AddError(nameof(Pesel), "Pesel musi składać się wyłącznie z cyfr.");
            if (string.IsNullOrWhiteSpace(Pesel) || Pesel == null)
                AddError(nameof(Pesel), "Pesel nie może być pusty.");
            if (Pesel?.Length != 11)
                AddError(nameof(Pesel), "Pesel musi mieć 11 cyfr.");
            ErrorFree = !HasErrors;
        }
        public void ValidateWynagrodzenie(decimal Wynagrodzenie)
        {
            ClearErrors(nameof(Wynagrodzenie));

            Regex regWynagrodzenie = new Regex(@"^([0-9]+[.,]{1}[0-9]+)$|^[0-9]+$");
            if (!regWynagrodzenie.IsMatch(Wynagrodzenie.ToString()))
                AddError(nameof(Wynagrodzenie), "Wynagrodzenie musi składać się wyłącznie z cyfr.");
            if (string.IsNullOrWhiteSpace(Wynagrodzenie.ToString()))
                AddError(nameof(Wynagrodzenie), "Wynagrodzenie nie może być puste.");

            if (Wynagrodzenie < 2500)
                AddError(nameof(Wynagrodzenie), "Wynagrodzenie musi wynosić co najmniej 2500.");

            ErrorFree = !HasErrors;
        }
        public void ValidateTelefon(string Telefon)
        {
            ClearErrors(nameof(Telefon));


            Regex regTelefon = new Regex(@"^[0-9]+$");
            if (!regTelefon.IsMatch(Telefon))
                AddError(nameof(Telefon), "Telefon musi składać się wyłącznie z cyfr.");
            if (string.IsNullOrWhiteSpace(Telefon) || Telefon == null)
                AddError(nameof(Telefon), "Telefon nie może być pusty.");
            if (Telefon?.Length != 9)
                AddError(nameof(Telefon), "Telefon musi mieć 9 cyfr.");
            ErrorFree = !HasErrors;
        }
        public void ValidateMiasto(string Miasto)
        {
            ClearErrors(nameof(Miasto));

            Regex regMiasto = new Regex(@"^([a-zA-Z]*)$");
            if (!regMiasto.IsMatch(Miasto))
                AddError(nameof(Miasto), "Miasto musi składać się wyłącznie z liter.");
            if (string.IsNullOrWhiteSpace(Miasto))
                AddError(nameof(Miasto), "Miasto nie może być puste.");
            if (Miasto == null || Miasto?.Length <= 1)
                AddError(nameof(Miasto), "Miasto musi mieć co najmniej 2 znaki.");
            ErrorFree = !HasErrors;
        }
        public void ValidateUlica(string Ulica)
        {
            ClearErrors(nameof(Ulica));

            Regex regUlica = new Regex(@"^[a-zA-Z]+[ ]+[a-zA-Z]*[ ]*[0-9]+(([a-z]{1})|([a-z]{0}))$");
            if (!regUlica.IsMatch(Ulica))
                AddError(nameof(Ulica), "Podaj nazwę ulicy i numer mieszkania");
            if (string.IsNullOrWhiteSpace(Ulica))
                AddError(nameof(Ulica), "Ulica nie może być pusta.");
            ErrorFree = !HasErrors;
        }
        public void ValidateKwota(decimal Kwota)
        {
            ClearErrors(nameof(Kwota));

            Regex regWynagrodzenie = new Regex(@"^([0-9]+[.,]{1}[0-9]+)$|^[0-9]+$");
            if (!regWynagrodzenie.IsMatch(Kwota.ToString()))
                AddError(nameof(Kwota), "Kwota musi składać się wyłącznie z cyfr.");
            if (string.IsNullOrWhiteSpace(Kwota.ToString()))
                AddError(nameof(Kwota), "Wynagrodzenie nie może być puste.");
            if (Kwota <= 0)
                AddError(nameof(Kwota), "Kwota jest za mała.");

            ErrorFree = !HasErrors;
        }
        public void ValidateOdbiorca(string Odbiorca)
        {
            ClearErrors(nameof(Odbiorca));



            if (string.IsNullOrWhiteSpace(Odbiorca) || Odbiorca == null)
                AddError(nameof(Odbiorca), "Odbiorca nie może być pusty.");

            ErrorFree = !HasErrors;
        }
        public void ValidateRachunekOdbiorcy(long RachunekOdbiorcy)
        {
            ClearErrors(nameof(RachunekOdbiorcy));


            Regex regRachunekOdbiorcy = new Regex(@"^[0-9]*$");
            if (!regRachunekOdbiorcy.IsMatch(RachunekOdbiorcy.ToString()))
                AddError(nameof(RachunekOdbiorcy), "Rachunek Odbiorcy musi składać się wyłącznie z cyfr.");
            if (string.IsNullOrWhiteSpace(RachunekOdbiorcy.ToString()) || RachunekOdbiorcy == null)
                AddError(nameof(RachunekOdbiorcy), "Rachunek Odbiorcy nie może być pusty.");
            if (RachunekOdbiorcy.ToString()?.Length != 11)
                AddError(nameof(RachunekOdbiorcy), "RachunekOdbiorcy musi mieć 11 cyfr.");
            ErrorFree = !HasErrors;
        }
    }


}








