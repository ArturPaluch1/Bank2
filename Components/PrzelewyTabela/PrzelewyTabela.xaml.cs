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
using Bank2.Navigators;

namespace Bank2.Components
{
    /// <summary>
    /// Interaction logic for PrzelewyTabela.xaml
    /// </summary>
    public partial class PrzelewyTabela : UserControl
    {
        public PrzelewyTabela(INavigator navigator)
        {
            InitializeComponent();
        }
    }
}
