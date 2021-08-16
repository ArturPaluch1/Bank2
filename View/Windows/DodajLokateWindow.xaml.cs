using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for DodajLokateWindow.xaml
    /// </summary>
    public partial class DodajLokateWindow : Window
    {
        public DodajLokateWindow(INavigator navigator)
        {
            InitializeComponent();
            DataContext = new VMDodajLokate(this, navigator);
        }
    }
}
