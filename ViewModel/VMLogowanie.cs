using Bank2.Commands;
using Bank2.Model;
using Bank2.Navigators;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Bank2.ViewModel
{
  public  class VMLogowanie : ViewModelBase
    { 
        private string _imie;
        private string _nazwisko;
        private string _password;


      
 
        public string Imie { get
            {
                return _imie;
            }
            set
            {
                _imie = value;
              
                OnPropertyChanged(nameof(Imie));
          
       //         ValidateImie(Imie);
            }
        }
        //public void ValidateImie()
        //{
        //    //Regex regImie = new Regex(@"^([a-zA-Z]*)$");

        //    //ClearErrors(nameof(Imie));
        //    //if (string.IsNullOrWhiteSpace(Imie))
        //    //    AddError(nameof(Imie), "Imię nie może być puste.");
        //    //if (Imie == null || Imie?.Length <= 2)
        //    //    AddError(nameof(Imie), "Imię musi mieć co najmiej 3 znaki.");
        //    //if(!regImie.IsMatch (Imie))
        //    //    AddError(nameof(Imie), "Imię musi składać się wyłącznie z liter.");
        //    //ErrorFree = !HasErrors;

            

        //}
        
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
             //   ValidateNazwisko(Nazwisko);
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
            //    ValidatePassword(Password);
            }
        } 

     


        //private Baza model = new Baza();



        public ICommand Zarejestruj { get; set; }
        public ICommand Zaloguj { get; set; }
        




        /// <summary>
        /// /////////////////////////////////////////////////
        /// </summary>
        /// 
        //bool _errorFree = false;
        //public bool ErrorFree {
        //    get { return _errorFree; }
        //    set
        //    {
        //        _errorFree = value;

        //       OnPropertyChanged(nameof(ErrorFree));
        //    }
        //    }
        //private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        //public bool HasErrors
        //{
        //    get { return _errorsByPropertyName.Any(); }// (x => x.Value != null && x.Value.Count > 0); }

        //}

        ////=> (
        ////    _errorsByPropertyName.Any());


        //public IEnumerable GetErrors(string propertyName)
        //{
        //    return _errorsByPropertyName.ContainsKey(propertyName) ?
        //    _errorsByPropertyName[propertyName] : null;
        //}
        //private void OnErrorsChanged(string propertyName)
        //{
        //    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //}

        //private void ValidateImie()
        //{
        //    ClearErrors(nameof(Imie));
        //    if (string.IsNullOrWhiteSpace(Imie))
        //        AddError(nameof(Imie), "Imie cannot be empty.");
        //    if (string.Equals(Imie, "Admin", StringComparison.OrdinalIgnoreCase))
        //        AddError(nameof(Imie), "Admin is not valid Imie.");
        //    if (Imie == null || Imie?.Length <= 5)
        //        AddError(nameof(Imie), "Imie must be at least 6 characters long.");
        //    ErrorFree = !HasErrors;
        //}

        //private void AddError(string propertyName, string error)
        //{
        //    if (!_errorsByPropertyName.ContainsKey(propertyName))
        //        _errorsByPropertyName[propertyName] = new List<string>();

        //    if (!_errorsByPropertyName[propertyName].Contains(error))
        //    {
        //        _errorsByPropertyName[propertyName].Add(error);
        //        OnErrorsChanged(propertyName);
        //    }
        //}

        //private void ClearErrors(string propertyName)
        //{
        //    if (_errorsByPropertyName.ContainsKey(propertyName))
        //    {
        //        _errorsByPropertyName.Remove(propertyName);
        //        OnErrorsChanged(propertyName);
        //    }
        //}



        /// <summary>
        /// ////////////////////////////////////////////////////
        /// </summary>
        /// <param name="navigator"></param>
        public VMLogowanie(INavigator navigator)//IEventAggregator ea)//NavigationService navigationService)
        {
               Zarejestruj = new UpdateCurrentViewModelCommand<VMDodajPracownika>(navigator, ()=>new VMDodajPracownika(navigator)); 
            Zaloguj = new ZalogujPracownikaCommand<VMPracownikNavigationBar>(navigator, () => new VMPracownikNavigationBar(navigator));

            Password = "";
            Imie = "";
            Nazwisko = "";
        }

    }


}
