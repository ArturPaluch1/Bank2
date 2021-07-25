using Bank2.Commands;
using Bank2.Navigators;
using Bank2.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Bank2.ViewModel
{
    class VMPracownikNavigationBar:ViewModelBase
    {
    //  public ICommand CurrentContent { get; set; }
        //  public VMLogowanie Content { get; set; } 
        //public VMPracownikNavigationBar dcnav { get; set; }
        //private ObservableCollection<Model1> tabItems;
        //public ObservableCollection<Model1> TabItems
        //{
        //    get { return tabItems; }
        //    set
        //    {
        //        tabItems = value;
        //        this.RaisePropertyChanged("TabItems");
        //    }
        //}

        //private void RaisePropertyChanged(string v)
        //{
        //    throw new NotImplementedException();
        //}

        private INavigator _navigator;
        public VMPracownikKlienci pg { get; set; }


      //  private PracownikKlienciPage _KlienciPage;

        public Page KlienciPage { get; set; }
        public Page PracownicyPage { get; set; }
        public Page KredytyPage { get; private set; }
        public Page LokatyPage { get; private set; }



        /*    private int _tabControlSelectedIndex;
           public int tabControlSelectedIndex
            {
                get
                {
                    return _tabControlSelectedIndex;
                }
                set
                {
                    switch(value)
                    {
                        case 0:  _navigator.CurrentViewModel = new VMPracownikKlienci(_navigator);
                            break;
                        case 1: 
                            break;
                        case 3:
                            _navigator.CurrentViewModel = new VMLogowanie(_navigator);
                            break;

                    }
                    //if (value != _tabControlSelectedIndex)
                    //{
                    //    _tabControlSelectedIndex = value;


                    //    _navigator.CurrentViewModel = new VMLogowanie(_navigator);
                    //}
                    //else
                    //{

                    //}
                }
            }*/

        /// public int MyProperty { get; set; }
        /// 

        public VMPracownikNavigationBar(INavigator navigator)
        {

            _navigator = navigator;
            KlienciPage = new PracownikKlienciPage();
            KlienciPage.DataContext = new VMPracownikKlienci(_navigator);
            PracownicyPage = new PracownikPracownicyPage();
            PracownicyPage.DataContext = new VMPracownikPracownicy(_navigator);
            KredytyPage = new PracownikKredytyPage();
            KredytyPage.DataContext = new VMPracownikKredyty(_navigator);
            LokatyPage = new PracownikLokatyPage();
            LokatyPage.DataContext = new VMPracownikLokaty(_navigator);
            //currentPage.NavigationService.Content = new VMPracownikKlienci(_navigator);
            //      bb = new UpdateCurrentViewModelCommand<VMPracownikKlienci>(_navigator, () => new VMPracownikKlienci(_navigator));
            //  _tabControlSelectedIndex = new UpdateCurrentViewModelCommand<VMLogowanie>(navigator, () => new VMLogowanie(navigator));
            //tabItems = new ObservableCollection<Model1>();
            //     PopulateCollection();
            //   tabItems[0].Content.CurrentViewModel = new VMLogowanie(tabItems[0].Content);
            //  tabItems[0].Content.CurrentViewModelChanged += OnCurrentVieModelChanged;

            // tabItems[0].Content.CurrentViewModel= new VMLogowanie(tabItems[0].Content);
            //    ICommand n = new UpdateCurrentViewModelCommand<VMLogowanie>(tabItems[0].Content, () => new VMLogowanie(tabItems[0].Content));
            //    n.Execute(null);
            //       Content = new VMLogowanie(navigator);
            //  vm = new VMLogowanie(navigator);
            //nv.CurrentViewModel.ToString();
        }

       

        //private void OnPropertyChanged(string v)
        //{
        //    throw new NotImplementedException();
        //}

        //public void PopulateCollection()
        //{
        //    // Navigator navigator = new Navigator();
        //    //navigator.CurrentViewModel = new VMLogowanie(navigator);

        //    Model1 model1 = new Model1()
        //    {
        //        Header = "tab1",

        //        navigator = "This is the content of first tabitem.",
        //   //   Content = new Navigator()

        //};
           

        //    //Adding the tab tems into the collection
        //    tabItems.Add(model1);
         
        //}
    }
    //public class Model1
    //{
    //    public string Header { get; set; }
    //    public  Navigator Content { get; set; }
    //    public string navigator { get; set; }
    //    public Model1()
    //    {

    //    }
    //}
}
