using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMZrobPrzelew:ViewModelBase
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
        
        private decimal _kwota;
        private string _Odbiorca;
        private long  _RachunekOdbiorcy;
        private string _Tytylem;

        public string Odbiorca { get { return _Odbiorca; } 
            set
            {
                _Odbiorca = value;
                OnPropertyChanged("Odbiorca");
                ValidateOdbiorca(Odbiorca);
            }
        }
      
        public long  RachunekOdbiorcy { get { return _RachunekOdbiorcy; }
            set
            {
                _RachunekOdbiorcy = value;
                OnPropertyChanged("RachunekOdbiorcy");
                ValidateRachunekOdbiorcy(RachunekOdbiorcy);
            }
        }
        public string Tytylem
        {
            get { return _Tytylem; }
            set
            {
                _Tytylem = value;
                OnPropertyChanged("Tytylem");

            }
        }



      

        public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
       
        public ICommand Przelej { get; set; }
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



        public VMZrobPrzelew(Window window, INavigator navigator)
        {
            _window = window;
            _navigator = navigator;
            ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
            _TablicaDanych = new KlienciTabela(_navigator);
          
            Przelej = new RelayCommand(ZrobPrzelew);
            Anuluj = new RelayCommand(WyjdzZokna);


            Odbiorca = "";
            RachunekOdbiorcy = 0;
            Kwota = 0;
                
                
        }

        private void ZrobPrzelew()
        {
            string bledy = "";
            if(Kwota==null || Kwota==0)
            {
                bledy = "- nie wpisałeś kwoty.\n";
            }
            if(Odbiorca==null)
            {
                bledy = bledy + "- nie wpisałeś odbiorcy.\n";
            }
            if(RachunekOdbiorcy==null||RachunekOdbiorcy==0)
            {
                bledy = bledy + "- nie wpisałeś rachunku odbiorcy.\n";
            }
            if(Tytylem==""||Tytylem==null)
            {
                bledy = bledy + "- nie wpisałeś tytułu.\n";
            }
            int licznik = 0;
            KlienciDataModel zaznaczonyKlient = null ;
            foreach (var item in ListaKlientow)
            {
                if (item.IsSelected == true)
                {
                    zaznaczonyKlient = item;
                    licznik++;

                }
            }
            if (licznik == 1)
            {
               
            }
            else
            {

                bledy =bledy+ "- Musisz zaznaczyć dokładnie jednego klienta.\n";
            }
            if (bledy!="")
            {

                MessageBox.Show("W formularzu\n"+bledy);
            }

            else
            {
                if (zaznaczonyKlient.Środki > Kwota)
                {



                    try
                    {
                        Baza db = new Baza();
                        Przelewy nowyPrzelew = new Przelewy();
                        nowyPrzelew.Data = DateTime.Now;
                        nowyPrzelew.Kwota = this.Kwota;
                        nowyPrzelew.Nadawca = zaznaczonyKlient.Id_klienta;
                        nowyPrzelew.Nazwa_odbiorcy = this.Odbiorca;
                        nowyPrzelew.Numer_rachunku_odbiorcy = this.RachunekOdbiorcy;
                        nowyPrzelew.Tytuł_przelewu = this.Tytylem;
                        db.Przelewy.Add(nowyPrzelew);
                        db.SaveChanges();

                        MessageBoxResult result = MessageBox.Show("Przelew wykonany", "", MessageBoxButton.OK);
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
                else
                {
                    MessageBox.Show("Za mało środków na koncie");
                }
            }
            

        }

        private void WyjdzZokna()
        {
            _window.Close();
        }
    }
}
