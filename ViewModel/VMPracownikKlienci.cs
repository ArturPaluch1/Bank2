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

namespace Bank2.ViewModel
{
    class VMPracownikKlienci : ViewModelBase, INotifyPropertyChanged
    {
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
        public ObservableCollection<Klienci> ListaKlientow { get; set; } = new ObservableCollection<Klienci>();
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


        private Visibility _KlienciNaglowek = Visibility.Hidden;
        public Visibility KlienciNaglowek
        {
            get { return _KlienciNaglowek; }
            set
            {
                _KlienciNaglowek = value;
                OnPropertyChanged("KlienciNaglowek");
            }

        }

        private Visibility _KredytyNaglowek = Visibility.Hidden;
        public Visibility KredytyNaglowek
        {
            get { return _KredytyNaglowek; }
            set
            {
                _KredytyNaglowek = value;
                OnPropertyChanged("KredytyNaglowek");
            }

        }
        private Visibility _LokatyNaglowek = Visibility.Hidden;
        public Visibility LokatyNaglowek
        {
            get { return _LokatyNaglowek; }
            set
            {
                _LokatyNaglowek = value;
                OnPropertyChanged("LokatyNaglowek");
            }

        }
        private Visibility _PrzelewyNaglowek = Visibility.Hidden;
        public Visibility PrzelewyNaglowek
        {
            get { return _PrzelewyNaglowek; }
            set
            {
                _PrzelewyNaglowek = value;
                OnPropertyChanged("PrzelewyNaglowek");
            }

        }









        public VMPracownikKlienci(INavigator navigator)
        {
            _navigator = navigator;

            wyloguj = new UpdateCurrentViewModelCommand<VMLogowanie>(_navigator, () => new VMLogowanie(_navigator));
            wyjdz = new RelayCommand(Wyjdz);
            klienciWyswietl = new RelayCommand(WyswietlKlientow);
            klienciDodaj = new RelayCommand(WyswietlOknoDodajKlienta);
            //klienciEdytuj = new KlientEdytujCommand();
            //klienciUsun = new KlientUsunCommand();
            //klienciUsunieci = new KlientPokarzUsunietychCommand();

            KredytWyswietl = new RelayCommand(WyswietlKredyty);
            //KredytDodaj = new KredytDodajCommand();
            //KredytEdytuj = new KredytEdytujCommand();
            //KredytUsun = new KredytUsunCommand();
            //KredytUsuniete = new KredytUsunieteCommand();

            LokataWyswietl = new RelayCommand(WyswietlLokaty);
            //LokataDodaj = new LokataDodajCommand();
            //LokataEdytuj = new LokataEdytujCommand();
            //LokataiUsun = new LokataiUsunCommand();
            //LokataUsuniete = new LokataUsunieteCommand();

            PrzelewWyswietl = new RelayCommand(WyswietlPrzelewy);
            //PrzelewDodaj = new PrzelewDodajCommand();
            //PrzelewWplata = new PrzelewWplataCommand();
            //PrzelewHistoria = new PrzelewHistoriaCommand();



        }

        private void WyswietlOknoDodajKlienta()
        {
            DodajKlientaWindow okno = new DodajKlientaWindow();
         //   okno.DataContext = new VMDodajKlienta();
            okno.Show();
        }

        private void WyswietlKlientow()
        {
            if (ButtonKlienciWyswietlContent == "Wyświetl")
            {
                ButtonKlienciWyswietlContent = "Schowaj";

                Baza db = new Baza();
                //ListaKlientow.Clear();
                ListaKlientow.Clear();

                foreach (var item in db.Klienci)
                {
                    ListaKlientow.Add(item);

                }
                KlienciNaglowek = Visibility.Visible;
            }

            else
            {
                ButtonKlienciWyswietlContent = "Wyświetl";
                ListaKlientow.Clear();

                KlienciNaglowek = Visibility.Hidden;
            }

        }
        private void WyswietlPrzelewy()
        {
            if (ButtonPrzelewyWyswietlContent == "Wyświetl")
            {
                ButtonPrzelewyWyswietlContent = "Schowaj";

                Baza db = new Baza();
                //ListaKlientow.Clear();
                ListaPrzelewow.Clear();

                foreach (var item in db.Przelewy)
                {
                    PrzelewyDataModel temp = new PrzelewyDataModel();
                    temp.Id_Przelewu = item.Id_Przelewu;
                    temp.Data = item.Data;
                    temp.Kwota = item.Kwota;
                    foreach (var item2 in db.Klienci)
                    {
                        if (item2.Id_klienta == item.Nadawca)
                        {
                            temp.NadawcaImię = item2.Imię;
                            temp.NadawcaNazwisko = item2.Nazwisko;
                        }
                        }
                    temp.Nazwa_odbiorcy = item.Nazwa_odbiorcy;
                    temp.Numer_rachunku_odbiorcy = item.Numer_rachunku_odbiorcy;
                    temp.Tytuł_przelewu = item.Tytuł_przelewu;
                    ListaPrzelewow.Add(temp);
                }
                PrzelewyNaglowek = Visibility.Visible;
                
            }

            else
            {
                ButtonPrzelewyWyswietlContent = "Wyświetl";
                ListaPrzelewow.Clear();

                PrzelewyNaglowek = Visibility.Hidden;
            }
        }

        private void WyswietlLokaty()
        {
            if (ButtonLokatyWyswietlContent == "Wyświetl")
            {
                ButtonLokatyWyswietlContent = "Schowaj";

                Baza db = new Baza();
                //ListaKlientow.Clear();
                ListaLokat.Clear();

                foreach (var item in db.Lokaty)
                {
                   
                    
                    LokatyDataModel temp = new LokatyDataModel();
                    temp.Id_Lokaty = item.Id_Lokaty;
                    temp.Data_założenia = item.Data_założenia;

                    temp.Kwota_lokaty = item.Wysokość_lokaty;

                    foreach (var item2 in db.Klienci)
                    {
                        if (item2.Id_klienta == item.Klient)
                        {
                            temp.KlientImie = item2.Imię;
                            temp.KlientNazwisko = item2.Nazwisko;
                        }
                    }
                    foreach (var item2 in db.Pracownicy)
                    {
                        if (item2.Id_Pracownika == item.Lokaty_udzielił)
                        {
                            temp.NazwiskoPracownika = item2.Nazwisko_pracownika;
                            temp.ImiePracownika = item2.Imię_pracownika;

                        }
                    }
                    foreach (var item2 in db.Rodzaje_lokat)
                    {
                        if (item2.Id_rodzaju_lokaty == item.Id_Rodzaju_lokaty)
                        {
                            temp.Rodzaj_lokaty = item2.Nazwa;
                            temp.Oprocentowanie = item2.Oprocentowanie;
                        }
                    }
                    ListaLokat.Add(temp);
                }
                LokatyNaglowek = Visibility.Visible;
            }

            else
            {
                ButtonLokatyWyswietlContent = "Wyświetl";
                ListaLokat.Clear();

                LokatyNaglowek = Visibility.Hidden;
            }
        }

        private void WyswietlKredyty()
        {
            if (ButtonKredytyWyswietlContent == "Wyświetl")
            {
                ButtonKredytyWyswietlContent = "Schowaj";

                Baza db = new Baza();
                //ListaKlientow.Clear();
                ListaKredytow.Clear();

                foreach (var item in db.Kredyty)
                {
                    //ListaKredytow.Add(item);
                    KredytyDataModel temp = new KredytyDataModel();
                    temp.Id_Kredytu = item.Id_Kredytu;
                    temp.Kwota_kredytu = item.Kwota_kredytu;
                    temp.Data_założenia = item.Data_założenia;
                   
                        foreach (var item2 in db.Klienci)
                        { if (item2.Id_klienta == item.Klient)
                            {
                                temp.KlientImie = item2.Imię;
                            temp.KlientNazwisko = item2.Nazwisko;
                            } 
                        }
                    foreach (var item2 in db.Pracownicy)
                    {
                        if (item2.Id_Pracownika == item.Kredytu_udzielił)
                        {
                            temp.NazwiskoPracownika = item2.Nazwisko_pracownika;
                            temp.ImiePracownika = item2.Imię_pracownika;

                        }
                    }
                    foreach (var item2 in db.Rodzaje_kredytów)
                    {
                        if (item2.Id_rodzaju_kredytu == item.Rodzaj_kredytu)
                        {
                            temp.Rodzaj_kredytu = item2.Nazwa;
                            temp.Oprocentowanie = item2.Oprocentowanie;
                        }
                    }



                    ListaKredytow.Add(temp);
                }
                KredytyNaglowek = Visibility.Visible;
            }

            else
            {
                ButtonKredytyWyswietlContent = "Wyświetl";
                ListaKredytow.Clear();

                KredytyNaglowek = Visibility.Hidden;
            }
        }


        //private void WyswietlKredyty()
        //{
        //    if (KredytWyswietl == "Wyświetl")
        //    {
        //        KredytWyswietl = "Schowaj";

        //        Baza db = new Baza();
        //        ListaKlientow.Clear();

        //        foreach (var item in db.Kredyty)
        //        {
        //          //  ListaKlientow.Add(item);

        //          //  ListaObiektow.Add(item);
        //        }


        //        StackPanelVisibility = Visibility.Visible;
        //    }

        //    else
        //    {
        //        KredytWyswietl = "Wyświetl";
        //        ListaKlientow.Clear();

        //        StackPanelVisibility = Visibility.Hidden;
        //    }
        //}

        private void Wyjdz()
        {
            Application.Current.MainWindow.Close();
        }
     

    }
}
