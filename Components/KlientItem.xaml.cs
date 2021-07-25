using Bank2.Model;
using Bank2.View.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank2.Components
{
    /// <summary>
    /// Interaction logic for KlientItem.xaml
    /// </summary>
    public partial class KlientItem : UserControl
    {
        public KlientItem()
        {
            InitializeComponent();
           // DataContext = new VMKlientItem();
        }
    }
}
