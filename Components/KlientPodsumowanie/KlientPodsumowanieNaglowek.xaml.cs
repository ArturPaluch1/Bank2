using Bank2.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank2.Components
{
    /// <summary>
    /// Interaction logic for KlientPodsumowanieNaglowek.xaml
    /// </summary>
    public partial class KlientPodsumowanieNaglowek : UserControl
    {
        public KlientPodsumowanieNaglowek(INavigator navigator, KlienciDataModel klient)
        {
            InitializeComponent();
            DataContext = new VMKlienciPodsumowanie(navigator, klient);

        }
        //public static readonly DependencyProperty CityProperty = DependencyProperty.Register
        //(
        //     "City",
        //     typeof(INavigator),
        //     typeof(KlientPodsumowanieNaglowek),
        //     new PropertyMetadata()
        //);

        //public INavigator City
        //{
        //    get { return (INavigator)GetValue(CityProperty); }
        //    set { SetValue(CityProperty, value); }
        //}



        //public static readonly DependencyProperty NavigatorProperty = DependencyProperty.Register
        //    (
        //         "Navigator",
        //         typeof(INavigator),
        //         typeof(KlientPodsumowanieNaglowek),
        //         new PropertyMetadata(string.Empty)
        //    );

        //public string City
        //{
        //    get { return (string)GetValue(CityProperty); }
        //    set { SetValue(CityProperty, value); }
        //}


    }
}
