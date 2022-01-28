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
    class VMEdytujKlienta
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


        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();

        public ICommand Edytuj { get; set; }
        public ICommand Anuluj { get; set; }


        public VMEdytujKlienta(Window window, INavigator navigator, KlienciDataModel Klient)
        {
            this.Imie = Klient.Imię;
            this.Nazwisko = Klient.Nazwisko;
            this.Miasto = Klient.Miasto;
            this.Telefon = Klient.Telefon;
            this.Ulica = Klient.Ulica;

            _Klient = Klient;
            _window = window;
            _navigator = navigator;
            ListaKlientow = new ListyZasobow(_navigator.rodzajBazy.ToString()).PobierzAktywniKlienci();
          

            TablicaDanych = new KlienciTabela(_navigator);


            Edytuj = new RelayCommand(EdytujKlienta);
            Anuluj = new RelayCommand(WyjdzZokna);


        }

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


            if (CzyPoprawnyFormularz() == true)
            {

            }

            KlienciDataModel temp1 = new KlienciDataModel();
            int licznik = 0;



            Baza db = new Baza(_navigator.rodzajBazy.ToString());
            Klienci temp = new Klienci();

            foreach (var item in db.Klienci)
            {
                if (item.Id_klienta == _Klient.Id_klienta)
                {
                    item.Imię = this.Imie;
                    item.Nazwisko = this.Nazwisko;
                    if (this.Password != null)
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
            MessageBoxResult result = MessageBox.Show("Zedytowany", "", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {


                _window.Close();
            }






        }
    }
}
