using Bank2.Navigators;
using Bank2.View.Pages;
using System.Windows.Controls;

namespace Bank2.ViewModel
{
 public   class VMPracownikNavigationBar : ViewModelBase
    {

        private INavigator _navigator;
      //  public VMPracownikKlienci pg { get; set; }



        public Page KlienciPage { get; set; }
        public Page PracownicyPage { get; set; }
        public Page KredytyPage { get; private set; }
        public Page LokatyPage { get; private set; }




        public VMPracownikNavigationBar(INavigator navigator)
        {

            _navigator = navigator;
            KlienciPage = new PracownikKlienciPage();
            KlienciPage.DataContext = new VMPracownikKlienci(_navigator);
            PracownicyPage = new PracownikPracownicyPage();
            PracownicyPage.DataContext = new VMPracownikPracownicy(_navigator);
            KredytyPage = new PracownikKredytyPage();
            KredytyPage.DataContext = new VMPracownikKredyty(_navigator);
            LokatyPage = new PracownikLokatyPage();
            LokatyPage.DataContext = new VMPracownikLokaty(_navigator);
        }


    }
}
