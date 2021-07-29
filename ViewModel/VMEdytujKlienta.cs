using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMEdytujKlienta//: INotifyPropertyChanged//: INotifyCollectionChanged, 
    {
        public bool ISChecked;
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Password { get; set; }
        public int Telefon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }

       
        private KlienciDataModel _Klient;
        private Window _window;
        private INavigator _navigator;
        private UserControl _TablicaDanych;
        public UserControl TablicaDanych { get; set; }
//        {
//            get { return _TablicaDanych; }
//    set
//            {
//                _TablicaDanych = value;
//                OnPropertyChanged("TablicaDanych");
//}
//        }



//        public event PropertyChangedEventHandler PropertyChanged;
//        // void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



//        public void OnPropertyChanged(string v)
//        {

//        }


        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
       
        public ICommand Edytuj { get; set; }
        public ICommand Anuluj { get; set; }

        

        //public event NotifyCollectionChangedEventHandler CollectionChanged;

       // public event CollectionChangeEventHandler CollectionChanged;
                                                  
        public VMEdytujKlienta(Window window, INavigator navigator,  KlienciDataModel Klient)
        {
            this.Imie = Klient.Imię;
            this.Nazwisko = Klient.Nazwisko;
            this.Miasto = Klient.Miasto;
           // this.Password = "bbdbfdf";
            this.Telefon = Klient.Telefon;
            this.Ulica = Klient.Ulica;

            _Klient = Klient;
            _window = window;
            _navigator = navigator;
            ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
         // ListaKlientow.CollectionChanged += ContentCollectionChanged;

         //   ListaKlientow.CollectionChanged +=  new System.Collections.Specialized.NotifyCollectionChangedEventHandler(changed);
          

            TablicaDanych = new KlienciTabela(_navigator);
           
       
            Edytuj = new RelayCommand(EdytujKlienta);
            Anuluj = new RelayCommand(WyjdzZokna);
          

        }
        //private void changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
        //{
        //    //You get notified here two times.
        //}

        //private void ContentCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args)
        //{
           
        //}

        //private void OnPropertyChanged()
        //{
        //    //  throw new NotImplementedException();
        //    //return ListaKlientow;
        //}

        private void WyjdzZokna()
        {

            _window.Close();
        }

        private bool CzyPoprawnyFormularz()
        {
            return true;

        }
        private void EdytujKlienta()
        {
            

            if (CzyPoprawnyFormularz()==true)
            {

            }

            KlienciDataModel temp1 = new KlienciDataModel();
           int licznik = 0;


           
                Baza db = new Baza();
                Klienci temp = new Klienci();

            foreach (var item in db.Klienci)
            {
                if(item.Id_klienta==_Klient.Id_klienta)
                {
                    item.Imię = this.Imie;
                    item.Nazwisko = this.Nazwisko;
                    if(this.Password!=null)
                    {
                    
                        item.Password = this.Password;
                    }
                   

                    item.Data_założenia = DateTime.Now;
                    item.Miasto = this.Miasto;
                    item.Ulica = this.Ulica;
                    item.Telefon = this.Telefon;
                    
                    
                }
            }
            db.SaveChanges();
            //  db.Klienci.
            //    db.Klienci.Add(temp);
            //  db.SaveChanges();
            MessageBoxResult result = MessageBox.Show("Zedytowany", "", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
              

                _window.Close();
            }






        }
    }
}
