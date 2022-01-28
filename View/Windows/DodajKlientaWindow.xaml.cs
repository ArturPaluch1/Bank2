
using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for DodajKlientaWindow.xaml
    /// </summary>
    public partial class DodajKlientaWindow : Window
    {
        public DodajKlientaWindow(INavigator navigator)
        {
            InitializeComponent();
            DataContext = new VMDodajKlienta(this, navigator);

        }
    }
}
