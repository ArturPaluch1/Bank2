using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    internal class DodajPracownikaCommand<TViewModel> : ICommand
    where TViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;

        VMDodajPracownika _vm;
        private INavigator _navigator;
        private Func<TViewModel> _createViewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is VMDodajPracownika)
            {
                dodaj((parameter as VMDodajPracownika));

            }

        }
        public DodajPracownikaCommand(VMDodajPracownika vm, INavigator navigator, Func<TViewModel> createViewModel)
        {
            _vm = vm;
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        private void dodaj(VMDodajPracownika nv)
        {


            if (_vm.Imie != null && _vm.Nazwisko != null && _vm.Password != null && _vm.Pesel != null && _vm.Wynagrodzenie != null && _vm.Telefon != null)
            {
             
                    Baza db = new Baza(_navigator.rodzajBazy.ToString());
                  
                    db.Pracownicy.Add(new Pracownicy()
                    {
                        Data_zatrudnienia = DateTime.Now,
                        Imię_pracownika = _vm.Imie,
                        Nazwisko_pracownika = _vm.Nazwisko,
                        PESEL = _vm.Pesel,
                        Password = _vm.Password,
                        Telefon = int.Parse(_vm.Telefon),
                        Wynagrodzenie = _vm.Wynagrodzenie


                    }
                    );

                    db.SaveChanges();

                    MessageBoxResult result = MessageBox.Show("Dodawanie powiodło się.", "", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        _navigator.CurrentViewModel = _createViewModel();
                    }
            

            }
            else
            {
                MessageBox.Show("Uzupełnij wszystko");
            }


        }


    }
}