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
