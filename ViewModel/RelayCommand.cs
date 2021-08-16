using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bank2
{
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<object, bool> canExecute;
        private Action<ObservableCollection<object>> edytujLokate;

        public RelayCommand(Action<ObservableCollection<object>> edytujLokate)
        {
            this.edytujLokate = edytujLokate;
        }

        public RelayCommand(Action Execute, Func<object, bool> CanExecute = null)
        {
            if (Execute == null) throw new ArgumentNullException(nameof(Execute));
            else this.execute = Execute;
            this.canExecute = CanExecute;




        }

        public event EventHandler CanExecuteChanged;
        //public void RaiseCanExecuteChanged()
        //{
        //    if (CanExecuteChanged != null)
        //        CanExecuteChanged(this, new EventArgs());
        //}

        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true;
            else

                return canExecute(parameter);

        }

        public void Execute(object parameter)
        {
            execute();
        }
    }

}