using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      //  private bool _zalogowany = false;

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
               if (Zaloguj(_navigator.CurrentViewModel as VMLogowanie))
                {
                    _navigator.CurrentViewModel = _createViewModel();
                }
                else
                {
                    (_navigator.CurrentViewModel as VMLogowanie).Imie = "";
                    (_navigator.CurrentViewModel as VMLogowanie).Nazwisko = "";
                    (_navigator.CurrentViewModel as VMLogowanie).Password = "";
                    _navigator.CurrentViewModel = new VMLogowanie(_navigator);
                }

            }

           
         


        }


        private bool Zaloguj(VMLogowanie vm)
        {
            bool zalogowany = false;
          
            if (!(vm.Imie==null || vm.Nazwisko == null || vm.Password == null))
            {

                try
                {
                    Baza db = new Baza();


                    foreach (var item in db.Pracownicy)
                    {
                        if (
                            vm.Imie == item.Imię_pracownika.TrimEnd()
                          && vm.Nazwisko == item.Nazwisko_pracownika.TrimEnd()
                            && vm.Password == item.Password.TrimEnd())
                        {
                            zalogowany = true;
                            break;
                        }


                    }
                    if (zalogowany == true)
                    {
                        MessageBox.Show("Dobre dane logowania");
                        return zalogowany;
                    }
                    else
                    {
                        MessageBox.Show("Złe dane logowania");
                        return zalogowany;
                    }



                }
                catch
                {
                    MessageBox.Show("Błąd logowania do bazy danych.");
                    return false;
                }



            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie pola");
                return false;
            }
            
          //  return zalogowany;
        }


    }

}
