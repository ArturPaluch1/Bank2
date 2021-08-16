using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Windows.Input;

namespace Bank2.Commands
{
    public class UpdateCurrentViewModelCommand<TViewModel> : ICommand
        where TViewModel : ViewModelBase
    {
        /* public event EventHandler CanExecuteChanged;
         private readonly INavigator _navigator;


         public UpdateCurrentViewModelCommand(INavigator navigator)
         {
             _navigator = navigator;
         }

         public bool CanExecute(object parameter) => true;




         public void Execute(object parameter)
         {
             if(parameter is ViewType)
             {
                 ViewType viewType = (ViewType)parameter;
                 switch(viewType)
                     {
                     case ViewType.LogowaniePage:
                         _navigator.CurrentViewModel = new VMLogowanie(_navigator);
                         break;
                     case ViewType.PracownikPage:
                         _navigator.CurrentViewModel = new VMPracownik(_navigator);
                         break;
                     default:
                         break;

                 }
             }
         }*/




        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;

        public UpdateCurrentViewModelCommand(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object parameter) => true;




        public void Execute(object parameter)
        {
            _navigator.CurrentViewModel = _createViewModel();


        }


    }
}
