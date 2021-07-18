using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    using Bank2.Navigators;
    using Bank2.View.Pages;
    using Model;

    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Navigation;

 public   class VMMainWindow :  ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
      //  public INavigator Navigator { get; set; } = new Navigator();
        private readonly INavigator _navigator;

        private object _currentView;

        



          public event PropertyChangedEventHandler PropertyChanged;

          private void OnPropertyChanged(string nazwa)
          {
              if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
          }

      
        //public object CurrentView
        //{
        //    get { return _currentView; }
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged("CurrentView");
        //    }
        //}

        public VMMainWindow(INavigator navigator)
        {
            //CurrentView = new LogowaniePage();

           
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentVieModelChanged;




        }

        private void OnCurrentVieModelChanged()
        {
           OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
