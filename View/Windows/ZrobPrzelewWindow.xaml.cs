using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
