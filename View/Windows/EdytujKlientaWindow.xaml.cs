using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for EdytujKlientaWindow.xaml
    /// </summary>
    public partial class EdytujKlientaWindow : Window
    {
        public EdytujKlientaWindow(INavigator navigator, KlienciDataModel Klient)
        {
            InitializeComponent();
            DataContext = new VMEdytujKlienta(this, navigator, Klient);
        }
    }
}
