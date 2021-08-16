using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for DodajKredytWindow.xaml
    /// </summary>
    public partial class DodajKredytWindow : Window
    {
        public DodajKredytWindow(INavigator navigator)
        {
            InitializeComponent();
            DataContext = new VMDodajKredyt(this, navigator);
        }
    }
}
