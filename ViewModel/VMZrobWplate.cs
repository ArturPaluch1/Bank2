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
    class VMZrobWplate : ViewModelBase
    {
        private Window _window;
        private INavigator _navigator;
        private decimal _kwota;
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
        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();

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
        public ICommand Wplac { get; set; }
        public ICommand Anuluj { get; set; }
        public VMZrobWplate(Window window, INavigator navigator)
        {
            _window = window;
            _navigator = navigator;
            ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywniKlienci();
            _TablicaDanych = new KlienciTabela(_navigator);
            Wplac = new RelayCommand(ZrobWplate);
            Anuluj = new RelayCommand(WyjdzZokna);
            Kwota = 0;
        }

        private void WyjdzZokna()
        {
            _window.Close();
        }

        private void ZrobWplate()
        {
            int licznik = 0;
            KlienciDataModel zaznaczonyKlient = null;
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    zaznaczonyKlient = item;
                    licznik++;

                }
            }
            if (licznik != 1)
            {
                MessageBox.Show("Musisz zaznaczyć dokładnie jednego klienta.\n");
            }

            else
            {
                try
                {
                    Baza db = new Baza(_navigator.rodzajBazy.ToString());

                    Przelewy nowyPrzelew = new Przelewy();
                    nowyPrzelew.Data = DateTime.Now;
                    nowyPrzelew.Kwota = Kwota;



                    nowyPrzelew.Numer_rachunku_odbiorcy = zaznaczonyKlient.Numer_rachunku;
                    nowyPrzelew.Tytuł_przelewu = "Wpłata";
                    foreach (var item in db.Klienci)
                    {
                        if (item.Id_klienta == zaznaczonyKlient.Id_klienta)
                        {
                            item.Środki += Kwota;
                            nowyPrzelew.Nazwa_odbiorcy = item.Imię.TrimEnd(' ') + " " + item.Nazwisko.TrimEnd(' ');
                            nowyPrzelew.Nadawca = item.Id_klienta;
                        }

                    }
                    db.Przelewy.Add(nowyPrzelew);


                    db.SaveChanges();

                    MessageBoxResult result = MessageBox.Show("Wpłata wykonana", "", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        _window.Close();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Podczas zapisu do bazy nastąpił błąd");
                }
            }
        }
    }
}
