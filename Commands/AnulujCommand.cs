using System;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    internal class AnulujCommand : ICommand
    {
        public AnulujCommand()
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          MessageBox.Show("anuluj");
        }
    }
}