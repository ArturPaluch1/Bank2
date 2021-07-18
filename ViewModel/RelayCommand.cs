using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank2
{
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action Execute, Func<object, bool> CanExecute = null)
        {
            if (Execute == null) throw new ArgumentNullException(nameof(Execute));
            else this.execute = Execute;
            this.canExecute = CanExecute;




        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true;
            else return canExecute(parameter);

        }

        public void Execute(object parameter)
        {
            execute();
        }
    }

}