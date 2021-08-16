using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;

namespace Bank2.View.Windows
{
    /// <summary>
    /// Interaction logic for EdytujKredytWindow.xaml
    /// </summary>
    public partial class EdytujKredytWindow : Window
    {
        public EdytujKredytWindow(INavigator navigator, KredytyDataModel kredyt)
        {
            InitializeComponent();
            DataContext = new VMEdytujKredyt(this, navigator, kredyt);
        }
    }
}
