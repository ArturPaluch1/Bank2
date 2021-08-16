using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajKredyt : ViewModelBase
    {

        private Window _window;
        private INavigator _navigator;
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
        private decimal _kwota;









        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
        public ObservableCollection<RodzajeKredytowDataModel> ListaRodzajowKredytow { get; set; } = new ObservableCollection<RodzajeKredytowDataModel>();

        public ICommand Dodaj { get; set; }
        public ICommand Anuluj { get; set; }

        public decimal Kwota
        {
            get { return _kwota; }
            set
            {
                _kwota = value;
                OnPropertyChanged("Kwota");
                ValidateKwota(Kwota);
            }
        }











        public VMDodajKredyt(Window window, INavigator navigator)
        {
            _window = window;
            _navigator = navigator;
            ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
            ListaRodzajowKredytow = new ListyZasobow().PobierzAktywneRodzajeKredytow();
            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych2 = new RodzajeKredytowTabela(_navigator);
            Kwota = 0;
            Dodaj = new RelayCommand(DodajKredyt);
            Anuluj = new RelayCommand(WyjdzZokna);


        }

        private void WyjdzZokna()
        {
            _window.Close();
        }

        private void DodajKredyt()
        {
            Baza db = new Baza();
            Kredyty nowyKredyt = new Kredyty();

            string bladKlienta = "";
            string bladRodzajuKredytu = "";
            string bladKwoty = "";
            int licznik = 0;
            KlienciDataModel temp1 = new KlienciDataModel();

            foreach (KlienciDataModel item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    temp1 = item;
                    licznik++;

                }

            }
            if (licznik == 1)
            {
                nowyKredyt.Klient = temp1.Id_klienta;
                licznik = 0;
            }
            else
            {

                bladKlienta = "Musisz zaznaczyć dokładnie jednego klienta.\n";
            }

            //////////
            ///
            RodzajeKredytowDataModel temp2 = new RodzajeKredytowDataModel();

            foreach (RodzajeKredytowDataModel item in ListaRodzajowKredytow)
            {
                if (item.IsSelected == true)
                {
                    temp2 = item;
                    licznik++;

                }

            }
            if (licznik == 1)
            {
                nowyKredyt.Rodzaj_kredytu = temp2.Id_rodzaju_Kredytu;
                licznik = 0;
            }
            else
            {

                bladRodzajuKredytu = "Musisz zaznaczyć dokładnie jeden rodzaj kredytu.\n";
            }

            nowyKredyt.aktywny = true;
            nowyKredyt.Data_założenia = DateTime.Now;
            nowyKredyt.Kredytu_udzielił = _navigator.zalogowanyPracownik.Id_Pracownika;


            nowyKredyt.Kwota_kredytu = this.Kwota;
            if (this.Kwota == 0 || this.Kwota == null)
            { bladKwoty = "Kwota kredytu nie może być zerowa"; }

            string tempString = bladKlienta + bladRodzajuKredytu + bladKwoty;
            if (tempString == "")
            {
                db.Kredyty.Add(nowyKredyt);
                db.SaveChanges();
                MessageBoxResult result = MessageBox.Show("Kredyt dodany", "", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    _window.Close();
                }
            }
            else
                MessageBox.Show(tempString);


        }
    }
}
