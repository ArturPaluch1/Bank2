using Bank2.Commands;
using Bank2.Commands.Klient;
using Bank2.Commands.Kredyt;
using Bank2.Commands.Lokata;
using Bank2.Commands.Przelew;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bank2.ViewModel;
using System.Windows;
using System.ComponentModel;
using Bank2.Model;
using Bank2.Components;
using System.Collections.ObjectModel;
using Bank2.View.Pages;
using Bank2.View.Windows;
using System.Windows.Controls;

namespace Bank2.ViewModel
{
    class VMPracownikKlienci : ViewModelBase, INotifyPropertyChanged
    {
        private UserControl _TablicaDanych;
        public UserControl TablicaDanych
        {
            get { return _TablicaDanych; }
    set  {
                _TablicaDanych = value;
                OnPropertyChanged("TablicaDanych");
}
        }
        
        public ICommand klienciWyswietl { get; set; }
        public ICommand klienciDodaj { get; set; }
        public ICommand klienciEdytuj { get; set; }
        public ICommand klienciUsun { get; set; }
        public ICommand klienciUsunieci { get; set; }
        public ICommand KredytWyswietl { get; set; }
        public ICommand KredytDodaj { get; set; }
        public ICommand KredytEdytuj { get; set; }
        public ICommand KredytUsun { get; set; }
        public ICommand KredytUsuniete { get; set; }
        public ICommand LokataWyswietl { get; set; }
        public ICommand LokataDodaj { get; set; }
        public ICommand LokataEdytuj { get; set; }
        public ICommand LokataiUsun { get; set; }
        public ICommand LokataUsuniete { get; set; }
        public ICommand PrzelewWyswietl { get; set; }
        public ICommand PrzelewDodaj { get; set; }
        public ICommand PrzelewWplata { get; set; }
        public ICommand PrzelewHistoria { get; set; }
        public ICommand wyloguj { get; set; }
        public ICommand wyjdz { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private INavigator _navigator;

        /// <summary>
        /// //////////////////////////////////////
        /// </summary>
        /// 
        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
        public ObservableCollection<KredytyDataModel> ListaKredytow { get; set; } = new ObservableCollection<KredytyDataModel>();
        public ObservableCollection<LokatyDataModel> ListaLokat { get; set; } = new ObservableCollection<LokatyDataModel>();
        public ObservableCollection<PrzelewyDataModel> ListaPrzelewow { get; set; } = new ObservableCollection<PrzelewyDataModel>();
        public ObservableCollection<RodzajeLokatDataModel> ListaRodzajowLokat { get; set; } = new ObservableCollection<RodzajeLokatDataModel>();
        public ObservableCollection<RodzajeKredytowDataModel> ListaRodzajowKredytow { get; set; } = new ObservableCollection<RodzajeKredytowDataModel >();

        private string _ButtonKlienciWyswietlContent = "Wyświetl";
        public string ButtonKlienciWyswietlContent
        {
            get { return _ButtonKlienciWyswietlContent; }
            set  {
                _ButtonKlienciWyswietlContent = value;
                OnPropertyChanged("ButtonKlienciWyswietlContent"); }
        }
        private string _ButtonKredytyWyswietlContent = "Wyświetl";
        public string ButtonKredytyWyswietlContent
        {
            get { return _ButtonKredytyWyswietlContent; }
            set
            {
                _ButtonKredytyWyswietlContent = value;
                OnPropertyChanged("ButtonKredytyWyswietlContent");
            }
        }
        private string _ButtonLokatyWyswietlContent = "Wyświetl";
        public string ButtonLokatyWyswietlContent
        {
            get { return _ButtonLokatyWyswietlContent; }
            set
            {
                _ButtonLokatyWyswietlContent = value;
                OnPropertyChanged("ButtonLokatyWyswietlContent");
            }
        }
        private string _ButtonPrzelewyWyswietlContent = "Wyświetl";
        public string ButtonPrzelewyWyswietlContent
        {
            get { return _ButtonPrzelewyWyswietlContent; }
            set
            {
                _ButtonPrzelewyWyswietlContent = value;
                OnPropertyChanged("ButtonPrzelewyWyswietlContent");
            }
        }


        //private Visibility _KlienciTabelaVisibility = Visibility.Hidden;
        //public Visibility KlienciTabelaVisibility
        //{
        //    get { return _KlienciTabelaVisibility; }
        //    set
        //    {
        //        _KlienciTabelaVisibility = value;
        //        OnPropertyChanged("KlienciTabelaVisibility");
        //    }

        //}

        //private Visibility _KredytyTabelaVisibility = Visibility.Hidden;
        //public Visibility KredytyTabelaVisibility
        //{
        //    get { return _KredytyTabelaVisibility; }
        //    set
        //    {
        //        _KredytyTabelaVisibility = value;
        //        OnPropertyChanged("KredytyTabelaVisibility");
        //    }

        //}
        //private Visibility _LokatyTabelaVisibility = Visibility.Hidden;
        //public Visibility LokatyTabelaVisibility
        //{
        //    get { return _LokatyTabelaVisibility; }
        //    set
        //    {
        //        _LokatyTabelaVisibility = value;
        //        OnPropertyChanged("LokatyTabelaVisibility");
        //    }

        //}
        //private Visibility _PrzelewyTabelaVisibility = Visibility.Hidden;
        

        //public Visibility PrzelewyTabelaVisibility
        //{
        //    get { return _PrzelewyTabelaVisibility; }
        //    set
        //    {
        //        _PrzelewyTabelaVisibility = value;
        //        OnPropertyChanged("PrzelewyTabelaVisibility");
        //    }

        //}









        public VMPracownikKlienci(INavigator navigator)
        {
            _navigator = navigator;
          

            wyloguj = new UpdateCurrentViewModelCommand<VMLogowanie>(_navigator, () => new VMLogowanie(_navigator));
            wyjdz = new RelayCommand(Wyjdz);
            klienciWyswietl = new RelayCommand(WyswietlKlientow);
            klienciDodaj = new RelayCommand(WyswietlOknoDodajKlienta);
            klienciEdytuj = new RelayCommand(EdytujKlienta);
            klienciUsun = new RelayCommand(UsunKlienta);
            //klienciUsunieci = new KlientPokarzUsunietychCommand();

            KredytWyswietl = new RelayCommand(WyswietlKredyty);
         KredytDodaj = new RelayCommand(WyswietlOknoDodajKredyt);
            KredytEdytuj = new RelayCommand(EdytujKredyt);
            KredytUsun = new RelayCommand(UsunKredyt);
            //KredytUsuniete = new KredytUsunieteCommand();

            LokataWyswietl = new RelayCommand(WyswietlLokaty);
            LokataDodaj = new RelayCommand(WyswietlOknoDodajLokate);
            LokataEdytuj = new RelayCommand(EdytujLokate);
            LokataiUsun = new RelayCommand(UsunLokate);
            //LokataUsuniete = new LokataUsunieteCommand();

            PrzelewWyswietl = new RelayCommand(WyswietlPrzelewy);
            PrzelewDodaj = new RelayCommand(WyswietlOknoZrobPrzelew);
            //PrzelewWplata = new PrzelewWplataCommand();
            //PrzelewHistoria = new PrzelewHistoriaCommand();



        }

        private void UsunLokate(ObservableCollection<object> obj)
        {
            throw new NotImplementedException();
        }

        private void UsunKredyt(ObservableCollection<object> obj)
        {
            throw new NotImplementedException();
        }

        private void UsunKlienta(ObservableCollection<object> obj)
        {
            throw new NotImplementedException();
        }

        private void EdytujLokate()
        {
            
            LokatyDataModel temp1 = new LokatyDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaLokat)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {
                EdytujLokateWindow okno = new EdytujLokateWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();

            }
        }

        private void EdytujKredyt()
        {
            KredytyDataModel temp1 = new KredytyDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaKredytow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {
                EdytujKredytWindow okno = new EdytujKredytWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();

            }
            }

        private void EdytujKlienta()
        {
            

            KlienciDataModel temp1 = new KlienciDataModel();
            int licznik = 0;
            string bladKlienta;

            //sprawdza zaznaczenie
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie klienta.\n");

            }
            else
            {

                EdytujKlientaWindow okno = new EdytujKlientaWindow(_navigator, temp1);
                okno.Closing += Okno_Closing;
                okno.Show();
            }
        }

        private void Okno_Closing(object sender, CancelEventArgs e)
        {   /// Aktualizowanie widoku po zmianach
            switch(sender.GetType().Name)
            {
                case "EdytujKlientaWindow":
                    {
                        ListaKlientow = new ListyZasobow().PobierzKlienci();
                        TablicaDanych = null;
                        TablicaDanych = new KlienciTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;
                    }
                case "EdytujKredytWindow":
                    {
                        ListaKredytow = new ListyZasobow().PobierzKredyty();
                        TablicaDanych = null;
                        TablicaDanych = new KredytyTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;
                    }
                case "EdytujLokateWindow":
                    {
                        ListaLokat = new ListyZasobow().PobierzLokaty();
                        TablicaDanych = null;
                        TablicaDanych = new LokatyTabela(_navigator);
                        TablicaDanych.DataContext = this;
                        break;

                    }
            }
           
         
          
        }

        private void WyswietlOknoZrobPrzelew()
        {
            ZrobPrzelewWindow okno = new ZrobPrzelewWindow(_navigator);
            okno.Show();
        }

        private void WyswietlOknoDodajLokate()
        {
            DodajLokateWindow okno = new DodajLokateWindow(_navigator);
            okno.Show();
        }

        private void WyswietlOknoDodajKlienta()
        {
            DodajKlientaWindow okno = new DodajKlientaWindow(_navigator);
            okno.Show();
        }
        private void WyswietlOknoDodajKredyt()
        {
            DodajKredytWindow okno = new DodajKredytWindow(_navigator);
            okno.Show();
        }
        private void WyswietlKlientow()
        {
            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych.DataContext = this;

            if (ButtonKlienciWyswietlContent == "Wyświetl")
            {
                ButtonKlienciWyswietlContent = "Schowaj";

                


                Baza db = new Baza();
                //ListaKlientow.Clear();
                ListaKlientow.Clear();
                ListaKlientow = new ListyZasobow().PobierzKlienci();
                //foreach (var item in db.Klienci)
                //{
                //    ListaKlientow.Add(item);

                //}
                //KlienciTabelaVisibility = Visibility.Visible;
            }

            else
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
                ListaKlientow.Clear();
                TablicaDanych = null;
                //KlienciTabelaVisibility = Visibility.Hidden;
            }

        }
        private void WyswietlPrzelewy()
        {
            TablicaDanych = new PrzelewyTabela(_navigator);
            TablicaDanych.DataContext = this;

            if (ButtonPrzelewyWyswietlContent == "Wyświetl")
            {
                ButtonPrzelewyWyswietlContent = "Schowaj";
                ListaPrzelewow.Clear();
                ListaPrzelewow = new ListyZasobow().PobierzPrzelewy();


                //PrzelewyTabelaVisibility = Visibility.Visible;
                
            }

            else
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
                ListaPrzelewow.Clear();
                TablicaDanych = null;
                //PrzelewyTabelaVisibility = Visibility.Hidden;
            }
        }

        private void WyswietlLokaty()
        {
            TablicaDanych = new LokatyTabela(_navigator);
            TablicaDanych.DataContext = this;
            if (ButtonLokatyWyswietlContent == "Wyświetl")
            {
                ButtonLokatyWyswietlContent = "Schowaj";

                ListaLokat.Clear();
                ListaLokat = new ListyZasobow().PobierzLokaty();
               
                //LokatyTabelaVisibility = Visibility.Visible;
            }

            else
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
                ListaLokat.Clear();
                TablicaDanych = null;
                //LokatyTabelaVisibility = Visibility.Hidden;
            }
        }

        private void WyswietlKredyty()
        {
            TablicaDanych = new KredytyTabela(_navigator);
            TablicaDanych.DataContext = this;
            if (ButtonKredytyWyswietlContent == "Wyświetl")
            {
                ButtonKredytyWyswietlContent = "Schowaj";

                ListaKredytow.Clear();
                ListaKredytow = new ListyZasobow().PobierzKredyty();
             
                //KredytyTabelaVisibility = Visibility.Visible;
            }

            else
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
                ListaKredytow.Clear();
                TablicaDanych = null;
                //KredytyTabelaVisibility = Visibility.Hidden;
            }
        }



        private void Wyjdz()
        {
            Application.Current.MainWindow.Close();
        }
     

    }
}
