﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank2.Model;
using Bank2.Navigators;
using System.Windows;
using System.Collections.ObjectModel;
using Bank2.Components;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;

namespace Bank2.ViewModel
{
    class VMEdytujKredyt : INotifyPropertyChanged
    {
        private Window _window;
        private INavigator _navigator;
        private KredytyDataModel _KredytDoZmiany;
        private UserControl _TablicaDanych;
        public UserControl TablicaDanych
        {
            get { return _TablicaDanych; }
            set
            {
                _TablicaDanych = value;
                OnPropertyChanged("TablicaDanych");
            }
        }
        private UserControl _TablicaDanych2;
        public UserControl TablicaDanych2
        {
            get { return _TablicaDanych2; }
            set
            {
                _TablicaDanych2 = value;
                OnPropertyChanged("TablicaDanych2");
            }
        }
        private int _kwota;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
        public ObservableCollection<RodzajeKredytowDataModel> ListaRodzajowKredytow { get; set; } = new ObservableCollection<RodzajeKredytowDataModel>();

        public ICommand Edytuj { get; set; }
        public ICommand Anuluj { get; set; }

        public int Kwota
        {
            get { return _kwota; }
            set
            {
                _kwota = value;
                OnPropertyChanged("Kwota");
            }
        }

        private void OnPropertyChanged(string v)
        {
            //throw new NotImplementedException();
        }

        public VMEdytujKredyt(Window window, INavigator navigator, KredytyDataModel KredytDoZmiany)
        {
            _window = window;
            _navigator = navigator;
            _KredytDoZmiany = KredytDoZmiany;
            ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
            ListaRodzajowKredytow = new ListyZasobow().PobierzAktywneRodzajeKredytow();
            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych2 = new RodzajeKredytowTabela(_navigator);

            Edytuj = new RelayCommand(EdytujKredyt);
            Anuluj = new RelayCommand(WyjdzZokna);
        }

        private void WyjdzZokna()
        {
            _window.Close();
        }

        private void EdytujKredyt()
        {
            KlienciDataModel temp1 = new KlienciDataModel();
            RodzajeKredytowDataModel temp2;

            int licznik = 0;
            string bladKlienta = "";

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
                bladKlienta = "Musisz zaznaczyć dokładnie 1 klienta.\n";

                MessageBox.Show(bladKlienta);

            }
            else
            {


                temp2 = new RodzajeKredytowDataModel();
                int licznik2 = 0;


                //sprawdza zaznaczenie
                foreach (var item in ListaRodzajowKredytow)
                {
                    if (item.IsSelected == true)
                    {
                        temp2 = item;
                        licznik2++;

                    }
                }
                if (licznik2 != 1)
                {

                    bladKlienta = "Musisz zaznaczyć dokładnie 1 rodzaj kredytu.\n";
                    MessageBox.Show(bladKlienta);
                }
                else
                {
                    if(_kwota==0)
                    {
                        MessageBox.Show("Błędna kwota");
                    }
                    else
                    {
                        Kredyty doZmiany = null;
                        Baza db = new Baza();
                        //  _KredytDoZmiany;
                        foreach (var item in db.Kredyty)
                        {
                            if (_KredytDoZmiany.Id_Kredytu == item.Id_Kredytu)
                                doZmiany = item;
                        }

                        if (doZmiany != null)
                        {
                            doZmiany.Klient = temp1.Id_klienta;
                            doZmiany.Kredytu_udzielił = _navigator.zalogowanyPracownik.Id_Pracownika;
                            doZmiany.Kwota_kredytu = _kwota;
                            doZmiany.Rodzaj_kredytu = temp2.Id_rodzaju_Kredytu;
                            db.SaveChanges();

                            MessageBoxResult result = MessageBox.Show("Zedytowany", "", MessageBoxButton.OK);
                            if (result == MessageBoxResult.OK)
                            {


                                _window.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Błąd zapisu");
                        }
                    }
                   
                    
                    
                    //    string wynik = db.Database.SqlQuery(innerJoinQuery);

                    //doZmiany =(a)=>()


                }
            }
        }
    }
}
