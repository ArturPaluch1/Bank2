using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for EdytujLokateWindow.xaml
    /// </summary>
    public partial class EdytujLokateWindow : Window
    {
        public EdytujLokateWindow(INavigator navigator, LokatyDataModel Lokata)
        {
            InitializeComponent();
            DataContext = new VMEdytujLokate(this, navigator, Lokata);
        }
    }
}
