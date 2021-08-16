using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for ZrobWplateWindow.xaml
    /// </summary>
    public partial class ZrobWplateWindow : Window
    {
        public ZrobWplateWindow(INavigator navigator)
        {
            InitializeComponent();
            DataContext = new VMZrobWplate(this, navigator);
        }
    }
}
