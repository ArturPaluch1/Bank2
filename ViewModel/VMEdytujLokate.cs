using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMEdytujLokate : ViewModelBase
    {
        private Window _window;
        private INavigator _navigator;
        private LokatyDataModel _LokataDoZmiany;
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
        public ObservableCollection<RodzajeLokatDataModel> ListaRodzajowLokat { get; set; } = new ObservableCollection<RodzajeLokatDataModel>();

        public ICommand Edytuj { get; set; }
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



        public VMEdytujLokate(Window window, INavigator navigator, LokatyDataModel LokataDoZmiany)
        {
            _window = window;
            _navigator = navigator;
            _LokataDoZmiany = LokataDoZmiany;
            ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
            ListaRodzajowLokat = new ListyZasobow().PobierzAktywneRodzajeLokat();
            TablicaDanych = new KlienciTabela(_navigator);
            TablicaDanych2 = new RodzajeLokatTabela(_navigator);

            Edytuj = new RelayCommand(EdytujLokate);
            Anuluj = new RelayCommand(WyjdzZokna);
        }

        private void WyjdzZokna()
        {
            _window.Close();
        }

        private void EdytujLokate()
        {
            KlienciDataModel temp1 = new KlienciDataModel();
            RodzajeLokatDataModel temp2;
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
                temp2 = new RodzajeLokatDataModel();
                int licznik2 = 0;


                //sprawdza zaznaczenie
                foreach (var item in ListaRodzajowLokat)
                {
                    if (item.IsSelected == true)
                    {
                        temp2 = item;
                        licznik2++;

                    }
                }
                if (licznik2 != 1)
                {

                    bladKlienta = "Musisz zaznaczyć dokładnie 1 rodzaj lokaty.\n";
                    MessageBox.Show(bladKlienta);
                }
                else
                {
                    if (_kwota == 0)
                    {
                        MessageBox.Show("Błędna kwota");
                    }
                    else
                    {
                        Lokaty doZmiany = null;
                        Baza db = new Baza();
                        //  _KredytDoZmiany;
                        foreach (var item in db.Lokaty)
                        {
                            if (_LokataDoZmiany.Id_Lokaty == item.Id_Lokaty)
                                doZmiany = item;
                        }

                        if (doZmiany != null)
                        {
                            doZmiany.Klient = temp1.Id_klienta;
                            doZmiany.Lokaty_udzielił = _navigator.zalogowanyPracownik.Id_Pracownika;
                            doZmiany.Wysokość_lokaty = _kwota;
                            doZmiany.Id_Rodzaju_lokaty = temp2.Id_rodzaju_Lokaty;
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



                }
            }
        }
    }
}
