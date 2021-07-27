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
using Bank2.Model;
using Bank2.Navigators;
using Bank2.ViewModel;

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
