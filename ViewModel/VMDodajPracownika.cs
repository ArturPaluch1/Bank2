using Bank2.Commands;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajPracownika : ViewModelBase, INotifyPropertyChanged//, ICommand
    {
        private string _password;
       //rivate string _wynagrodzenieString;
        private decimal _wynagrodzenie;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        private ICommand _dodaj;
        
       public  ICommand Dodaj
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
                //OnPropertyChanged(nameof(Password));
            }
        }

        private string _imie;

        public string Imie
        {
            get { return _imie; }
            set { _imie = value;
            //    OnPropertyChanged(nameof(Imie));
            }
        }

        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public int Telefon { get; set; }
        public decimal Wynagrodzenie { get; set; }

        /*private void OnPropertyChanged(string v)
        {
            //    _password=
          
        }*/



        public VMDodajPracownika(INavigator navigator)
        {
            //Dodaj = new RelayCommand(new Action(ShowMessage));
            Dodaj = new DodajCommand(this);
            Anuluj = new AnulujCommand();
        }

       
    }
    
}
