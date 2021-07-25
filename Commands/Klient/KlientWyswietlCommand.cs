using Bank2.Components;
using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank2.Commands.Klient
{
    class KlientWyswietlCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
      
        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
           

        }
        public KlientWyswietlCommand( )
        {
            
        }
    }
}
