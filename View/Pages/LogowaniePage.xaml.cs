using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Bank2.View.Pages
{
    /// <summary>
    /// Interaction logic for LogowaniePage.xaml
    /// </summary>
    public partial class LogowaniePage : Page
    {
        private INavigator _navigator;
        public LogowaniePage()
        {
            InitializeComponent();
            //  DataContext = new VMLogowanie();

        }
        public LogowaniePage(INavigator navigator)
        {
            _navigator = navigator;

        }
        private void OnClickZaloguj(object sender, RoutedEventArgs e)
        {
           
            _navigator.CurrentViewModel = new VMPracownikKlienci(_navigator);
   

        }






    }
}
