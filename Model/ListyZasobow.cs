using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Model
{
      class ListyZasobow
    {
        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; }
        public ObservableCollection<KredytyDataModel> ListaKredytow { get; set; }
        private ObservableCollection<LokatyDataModel> ListaLokat { get; set; }
        private ObservableCollection<PrzelewyDataModel> ListaPrzelewow { get; set; }
        private ObservableCollection<RodzajeLokatDataModel> ListaRodzajowLokat { get; set; }
        private ObservableCollection<RodzajeKredytowDataModel> ListaRodzajowKredytow { get; set; }
        private ObservableCollection<PracownicyDataModel> ListaPracownikow { get; set; }

        private readonly Baza db;
        public ListyZasobow()
        {
            ListaKlientow = new ObservableCollection<KlienciDataModel>();
            ListaKredytow = new ObservableCollection<KredytyDataModel>();
            ListaLokat = new ObservableCollection<LokatyDataModel>();
            ListaPrzelewow = new ObservableCollection<PrzelewyDataModel>();
            ListaRodzajowLokat = new ObservableCollection<RodzajeLokatDataModel>();
            ListaRodzajowKredytow = new ObservableCollection<RodzajeKredytowDataModel>();
            ListaPracownikow = new  ObservableCollection<PracownicyDataModel>();
             db = new Baza();
        }


           public ObservableCollection<KlienciDataModel> PobierzKlienci()
        {
           
            foreach (var item in db.Klienci)
            {
                KlienciDataModel temp = new KlienciDataModel();
                temp.Id_klienta = item.Id_klienta;
                temp.Imię = item.Imię;
                temp.Nazwisko = item.Nazwisko;
                temp.Telefon = temp.Telefon;
                    temp.Miasto = item.Miasto;
                    temp.Ulica = item.Ulica;
                    temp.Środki = item.Środki;
                    temp.Data_założenia = item.Data_założenia;
                    temp.Numer_rachunku = item.Numer_rachunku;
                temp.Password = item.Password;

                ListaKlientow.Add(temp);
                
                
            }
            return ListaKlientow;
        }
        public ObservableCollection<KredytyDataModel> PobierzKredyty()
        {
            
            foreach (var item in db.Kredyty)
            {
                KredytyDataModel temp = new KredytyDataModel();
                temp.Id_Kredytu = item.Id_Kredytu;
                temp.Kwota_kredytu = item.Kwota_kredytu;
                temp.Data_założenia = item.Data_założenia;

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
            return ListaKredytow;
        }
            public ObservableCollection<LokatyDataModel> PobierzLokaty()
        {
            
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
            return ListaLokat;
        }
            public ObservableCollection<PrzelewyDataModel> PobierzPrzelewy()
        {


            
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
            return ListaPrzelewow;
        }
            public ObservableCollection<RodzajeLokatDataModel> PobierzRodzajeLokat()
        {
            
            foreach (var item in db.Rodzaje_lokat)
            {
                RodzajeLokatDataModel temp = new RodzajeLokatDataModel();
                temp.Id_rodzaju_Lokaty = item.Id_rodzaju_lokaty;
                temp.Nazwa = item.Nazwa;
                temp.Okres_w_mies = item.Okres_w_mies__;
                temp.Oprocentowanie = item.Oprocentowanie;
                temp.Prowizja = item.Prowizja;
                foreach (var item2 in db.Pracownicy)
                {
                    if (item2.Id_Pracownika == item.Lokatę_utworzył)
                    {
                        temp.UtworzylImie = item2.Imię_pracownika;
                        temp.UtworzylNazwisko = item2.Nazwisko_pracownika;
                    }
                }
                ListaRodzajowLokat.Add(temp);
              

            }
            return ListaRodzajowLokat;
        }
            public ObservableCollection<RodzajeKredytowDataModel> PobierzRodzajeKredytow()
        {
           
            foreach (var item in db.Rodzaje_kredytów)
            {
                RodzajeKredytowDataModel temp = new RodzajeKredytowDataModel();
                temp.Id_rodzaju_Kredytu = item.Id_rodzaju_kredytu;
                temp.Nazwa = item.Nazwa;
                temp.Okres_kredytowania_w_mies = item.Okres_kredytowania_w_mies__;
                temp.Oprocentowanie = item.Oprocentowanie;
                temp.Prowizja = item.Prowizja;
                foreach (var item2 in db.Pracownicy)
                {
                    if (item2.Id_Pracownika == item.Kredyt_utworzył)
                    {
                        temp.UtworzylImie = item2.Imię_pracownika;
                        temp.UtworzylNazwisko = item2.Nazwisko_pracownika;
                    }
                }
                ListaRodzajowKredytow.Add(temp);
               

            }
            return ListaRodzajowKredytow;
        }

        public ObservableCollection<PracownicyDataModel> PobierzPracownikow()
        {
           
            foreach (var item in db.Pracownicy)
            {
                PracownicyDataModel temp = new PracownicyDataModel();
                temp.Id_Pracownika = item.Id_Pracownika;
                temp.Imię_pracownika = item.Imię_pracownika;
                temp.Nazwisko_pracownika = item.Nazwisko_pracownika;
                temp.Data_zatrudnienia = temp.Data_zatrudnienia;
                temp.PESEL = item.PESEL;
                temp.Telefon = item.Telefon;
                temp.Password = item.Password;
               

                ListaPracownikow.Add(temp);

            }
            return ListaPracownikow;
        }

    }
    


}
