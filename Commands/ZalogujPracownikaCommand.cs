using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Bank2.Commands
{

    public class ZalogujPracownikaCommand<TViewModel> : ICommand
           where TViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;

        public ZalogujPracownikaCommand(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;


        }




        public void Execute(object parameter)
        {
            if (_navigator.CurrentViewModel is VMLogowanie)
            {
                Pracownicy pracownik = null;
                pracownik = Zaloguj(_navigator.CurrentViewModel as VMLogowanie);
                if (pracownik != null)
                {
                    _navigator.zalogowanyPracownik = pracownik;
                    _navigator.CurrentViewModel = _createViewModel();
                }

            }





        }


        private Pracownicy Zaloguj(VMLogowanie vm)
        {
            Pracownicy zalogowany = null;


            if (!(vm.Imie == null || vm.Nazwisko == null || vm.Password == null))
            {


              
        
                Baza db = new Baza(_navigator.rodzajBazy.ToString());
             

                if (   db.Database.Exists() == true)
                        {
                        foreach (var item in db.Pracownicy)
                        {
                            if (
                                vm.Imie == item.Imię_pracownika.TrimEnd()
                              && vm.Nazwisko == item.Nazwisko_pracownika.TrimEnd()
                                && vm.Password == item.Password.TrimEnd())
                            {
                           
                                zalogowany = item;
                                break;
                            }


                        }
                        if (zalogowany != null)
                        {
                            MessageBox.Show("Dobre dane logowania");
                            return zalogowany;
                        }
                        else
                        {
                            MessageBox.Show("Złe dane logowania");
                            return null;
                        }
                    }
                    else
                        {
                        MessageBox.Show("Błąd logowania do bazy danych lub baza nie istnieje.");
                        return null;
                    }
                
                   




                  



                
                



            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie pola");
                return null;
            }

        }


    }

}
