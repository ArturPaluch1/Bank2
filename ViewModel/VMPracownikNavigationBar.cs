using Bank2.Commands;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMPracownikNavigationBar:ViewModelBase
    {
        public string nav { get; set; }
        //  public VMLogowanie Content { get; set; } 
        //public VMPracownikNavigationBar dcnav { get; set; }
        private ObservableCollection<Model1> tabItems;
        public ObservableCollection<Model1> TabItems
        {
            get { return tabItems; }
            set
            {
                tabItems = value;
                this.RaisePropertyChanged("TabItems");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            throw new NotImplementedException();
        }



        /// public int MyProperty { get; set; }
        public VMPracownikNavigationBar(INavigator navigator)
        {
            tabItems = new ObservableCollection<Model1>();
       //     PopulateCollection();
         //   tabItems[0].Content.CurrentViewModel = new VMLogowanie(tabItems[0].Content);
          //  tabItems[0].Content.CurrentViewModelChanged += OnCurrentVieModelChanged;
            
            // tabItems[0].Content.CurrentViewModel= new VMLogowanie(tabItems[0].Content);
            //    ICommand n = new UpdateCurrentViewModelCommand<VMLogowanie>(tabItems[0].Content, () => new VMLogowanie(tabItems[0].Content));
            //    n.Execute(null);
            //       Content = new VMLogowanie(navigator);
            //  vm = new VMLogowanie(navigator);
            nav = "k"; //nv.CurrentViewModel.ToString();
        }

        private void OnCurrentVieModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public void PopulateCollection()
        {
            // Navigator navigator = new Navigator();
            //navigator.CurrentViewModel = new VMLogowanie(navigator);

            Model1 model1 = new Model1()
            {
                Header = "tab1",

                navigator = "This is the content of first tabitem.",
           //   Content = new Navigator()

        };
           

            //Adding the tab tems into the collection
            tabItems.Add(model1);
         
        }
    }
    public class Model1
    {
        public string Header { get; set; }
        public  Navigator Content { get; set; }
        public string navigator { get; set; }
        public Model1()
        {

        }
    }
}
