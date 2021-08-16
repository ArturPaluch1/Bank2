using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for ZrobPrzelewWindow.xaml
    /// </summary>
    public partial class ZrobPrzelewWindow : Window
    {
        public ZrobPrzelewWindow(INavigator navigator)
        {
            InitializeComponent();
            DataContext = new VMZrobPrzelew(this, navigator);
        }
    }
}
