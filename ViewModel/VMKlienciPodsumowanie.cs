using Bank2.Commands;
using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    public class VMKlienciPodsumowanie : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private UserControl _TuNaglowek;
        public UserControl TuNaglowek
        {
            get { return _TuNaglowek; }
            set
            {
                _TuNaglowek = value;
                OnPropertyChanged("TuNaglowek");
            }
        }
        //public static readonly DependencyProperty CityProperty = DependencyProperty.Register
        // (
        //      "City",
        //      typeof(INavigator),
        //      typeof(KlientPodsumowanieNaglowek),
        //      new PropertyMetadata()
        // );

        //public INavigator City { get; set; }
        //  {
        //    get { return (INavigator)GetValue(CityProperty); }
        //    set { SetValue(CityProperty, value); }
        //}

        public UserControl TablicaDanych { get; set; }
  
        private void OnPropertyChanged(string v)
        {
            //throw new NotImplementedException();
            //if (v== "TuNaglowek")
            //{
               
            //}
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        //private void OnPropertyChanged(ObservableCollection<KlienciDataModel> listaKlientow)
        //{
        //    //throw new NotImplementedException();
        //}

       
        public ObservableCollection<KredytyDataModel> ListaKredytow //{ get; set; } = new ObservableCollection<KredytyDataModel>();
        {
            get
            {
                return _ListaKredytow;
            }
    set
            {
                _ListaKredytow = value;
                OnPropertyChanged("ListaKredytow");
}
        }

        public ObservableCollection<LokatyDataModel> ListaLokat
        {
            get
            {
                return _ListaLokat;
            }
            set
            {
                _ListaLokat = value;
                OnPropertyChanged("ListaLokat");
            }
        }
        public ObservableCollection<PrzelewyDataModel> ListaPrzelewow
        {
            get
            {
                return _ListaPrzelewow;
            }
            set
            {
                _ListaPrzelewow = value;
                OnPropertyChanged("ListaPrzelewow");
            }
        }







        //{ get; set; } = new ObservableCollection<KredytyDataModel>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public KlientItemNaglowek gg { get; set; } = null;// new KlientItemNaglowek();

        private KlienciDataModel _klient;
        private INavigator _navigator;
        private ObservableCollection<KlienciDataModel> _listaKlientow;
        private ObservableCollection<KredytyDataModel> _ListaKredytow;
        private ObservableCollection<PrzelewyDataModel> _ListaPrzelewow;
        private ObservableCollection<LokatyDataModel> _ListaLokat;

        public ICommand Kredyty { get; set; }
        public ICommand Lokaty { get; set; }
        public ICommand Przelewy { get; set; }

        public VMKlienciPodsumowanie(INavigator navigator, KlienciDataModel klient)
        {
            _klient = klient;
            _navigator = navigator;
            Kredyty = new RelayCommand(WyswietlKredyty);
            Lokaty = new RelayCommand(WyswietlLokaty);
            Przelewy = new RelayCommand(WyswietlPrzelewy);
            TuNaglowek = null;// new LokataItemNaglowek();

            
            
           



        }

        private void WyswietlPrzelewy()
        {
            ListaPrzelewow = new ObservableCollection<PrzelewyDataModel>();

            ListaKredytow = null;
            ListaLokat = null;
            TuNaglowek = new PrzelewItemNaglowek();

            Baza db = new Baza();
            var querry = from Przelewy in db.Przelewy
                         where Przelewy.Nadawca == _klient.Id_klienta
                         select new
                         {
                             Przelewy.Id_Przelewu,
                             Przelewy.Kwota,
                             Przelewy.Nazwa_odbiorcy,
                             Przelewy.Tytuł_przelewu,
                             Przelewy.Nadawca,
                             Przelewy.Data
                         };
            
            foreach (var item in querry)
            {
                PrzelewyDataModel przelew = new PrzelewyDataModel();
                przelew.Id_Przelewu = item.Id_Przelewu;
                przelew.Kwota = item.Kwota;
                przelew.Nazwa_odbiorcy = item.Nazwa_odbiorcy;
                przelew.Tytuł_przelewu = item.Tytuł_przelewu;
                przelew.Data = item.Data;
                przelew.NadawcaImię = _klient.Imię;
                przelew.NadawcaNazwisko = _klient.Nazwisko;
                ListaPrzelewow.Add(przelew);


            }
           

            //  ListaPrzelewow = new ListyZasobow().PobierzPrzelewy();

        }

        private void WyswietlLokaty()
        {
            ListaLokat = new ObservableCollection<LokatyDataModel>();

            ListaPrzelewow = null;
            ListaKredytow = null;
            TuNaglowek = new LokataItemNaglowek();
            Baza db = new Baza();
            var querry = from Lokaty in db.Lokaty
                         where Lokaty.Klient == _klient.Id_klienta
                         select new
                         {
                             Lokaty.Id_Lokaty,
                             Lokaty.Klient,
                             Lokaty.Id_Rodzaju_lokaty,
                             Lokaty.Wysokość_lokaty,
                             Lokaty.Lokaty_udzielił,
                             Lokaty.Data_założenia,
                            
                         };

            foreach (var item in querry)
            {
                LokatyDataModel lokata = new LokatyDataModel();
                lokata.Id_Lokaty = item.Id_Lokaty;
                
                lokata.Kwota_lokaty = item.Wysokość_lokaty;
              
                lokata.Data_założenia = item.Data_założenia;
                lokata.KlientImie = _klient.Imię;
                lokata.KlientNazwisko = _klient.Nazwisko;
                
                foreach (var item2 in db.Rodzaje_lokat)
                {
                    if (item.Id_Rodzaju_lokaty == item2.Id_rodzaju_lokaty)
                    {
                        lokata.Oprocentowanie = item2.Oprocentowanie;
                        lokata.Rodzaj_lokaty = item2.Nazwa;
                    }
                }
                foreach (var item3 in db.Pracownicy)
                {
                    if (item.Lokaty_udzielił == item3.Id_Pracownika)
                    {
                        lokata.ImiePracownika = item3.Imię_pracownika;
                        lokata.NazwiskoPracownika = item3.Nazwisko_pracownika;
                    }
                }
                ListaLokat.Add(lokata);

                
            }
        }

        private void WyswietlKredyty()
        {
            ListaKredytow = new ObservableCollection<KredytyDataModel>();

            ListaPrzelewow = null;
            ListaLokat = null;
            TuNaglowek = new KredytItemNaglowek();
            Baza db = new Baza();
            var querry = from Kredyty in db.Kredyty
                         where Kredyty.Klient == _klient.Id_klienta
                         select new
                         {
                             Kredyty.Id_Kredytu,
                             Kredyty.Klient,
                             Kredyty.Rodzaj_kredytu,
                             Kredyty.Kwota_kredytu,
                             Kredyty.Kredytu_udzielił,
                             Kredyty.Data_założenia,

                         };

            foreach (var item in querry)
            {
                KredytyDataModel kredyt = new KredytyDataModel();
                kredyt.Id_Kredytu = item.Id_Kredytu;

                kredyt.Kwota_kredytu = item.Kwota_kredytu;

                kredyt.Data_założenia = item.Data_założenia;
                kredyt.KlientImie = _klient.Imię;
                kredyt.KlientNazwisko = _klient.Nazwisko;

                foreach (var item2 in db.Rodzaje_kredytów)
                {
                    if (item.Rodzaj_kredytu == item2.Id_rodzaju_kredytu)
                    {
                        kredyt.Oprocentowanie = item2.Oprocentowanie;
                        kredyt.Rodzaj_kredytu = item2.Nazwa;
                    }
                }
                foreach (var item3 in db.Pracownicy)
                {
                    if (item.Kredytu_udzielił == item3.Id_Pracownika)
                    {
                        kredyt.ImiePracownika = item3.Imię_pracownika;
                        kredyt.NazwiskoPracownika = item3.Nazwisko_pracownika;
                    }
                }
                ListaKredytow.Add(kredyt);


            }

        }
        }



}
