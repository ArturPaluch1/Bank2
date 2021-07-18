using Bank2.Commands;
using Bank2.Model;
using Bank2.Navigators;
using Bank2.View;
using Bank2.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Bank2.ViewModel
{
    class VMLogowanie : ViewModelBase//: Page//, INotifyPropertyChanged//,  IViewModel
    {
        // private NavigationService _navigationService;

      //  private IEventAggregator _ea;





        //private Baza model = new Baza();
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Zarejestruj { get; set; }

        //bool zalogowany = false;

        //private string imie;
        //private string nazwisko;
        //public string Password { private get; set; }



        //public string Imie
        //{

        //    get
        //    {
        //        return imie;
        //    }
        //    set
        //    {
        //        imie = value;
        //        OnPropertyChanged(nameof(Imie));
        //    }

        //}

        private void OnPropertyChanged(string nazwa)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }



        /*   public ICommand Zarejestruj
           {

           }*/


       
        public VMLogowanie(INavigator navigator)//IEventAggregator ea)//NavigationService navigationService)
        {
               Zarejestruj = new UpdateCurrentViewModelCommand<VMDodajPracownika>(navigator, ()=>new VMDodajPracownika(navigator));

            //    Zaloguj = new RelayCommand(new Action<object>(ShowMessage));

            //   _navigationService = navigationService;
            //      _ea = ea;
            //       Zarejestruj = new RelayCommand(
            //            ExecuteApplyChangesCommand);



        }

     /*   private void ExecuteApplyChangesCommand()
        {
           
            PracownikPage page = new PracownikPage();
      //      this.NavigationService.Navigate(page);
            
            //  NavigationService.



            //   NavigationService.GetNavigationService(this);
            //    ns.Navigate(page);

            //  Frame.NavigationService.Navigate(page);
            //  throw new NotImplementedException();


        }*/


        public void ShowMessage(object obj)
        {
            //   MessageBox.Show(obj.ToString());
        }
       
    }


}
