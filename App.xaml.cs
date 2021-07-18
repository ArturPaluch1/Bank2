using Bank2.Navigators;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bank2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Navigator navigator = new Navigator();
            navigator.CurrentViewModel = new VMLogowanie(navigator);
            MainWindow = new MainWindow
            {
                DataContext = new VMMainWindow(navigator)
            };
        
        
            
            MainWindow.Show();


            base.OnStartup(e);
        }

    }

}
