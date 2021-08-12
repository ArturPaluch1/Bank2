using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank2.Navigators
{
  /*  public enum ViewType
    {
        LogowaniePage,
        PracownikPage
    }*/
    public interface INavigator
    {

        public event Action CurrentViewModelChanged;
        event PropertyChangedEventHandler PropertyChanged;

        ViewModelBase CurrentViewModel { get; set; }
        Pracownicy zalogowanyPracownik { get; set; }
     //   ICommand UpdateCurrentViewModelCommand { get; }
         
    }
}
