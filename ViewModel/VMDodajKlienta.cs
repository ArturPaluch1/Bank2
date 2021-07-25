
using Bank2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajKlienta : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Imie { get; set; }
        public string  Nazwisko { get; set; }
        public string Password { get; set; }
        public int Telefon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }

        private Window _window;

        public ICommand Dodaj { get; set; }
        public ICommand Anuluj { get; set; }


       

        public VMDodajKlienta(Window window)
        {
            _window = window;
            Dodaj = new RelayCommand(DodajKlienta);
            Anuluj = new RelayCommand(ZamknijOkno);




           

     
         //   this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        

        
    }

        private void ZamknijOkno()
        {

            _window.Close();
        }

        private void DodajKlienta()
        {
            Baza db = new Baza();
            Klienci temp = new Klienci();
            temp.Imię = this.Imie;
            temp.Nazwisko = this.Nazwisko;
            temp.Password = this.Password;
            temp.Data_założenia = DateTime.Now;
            temp.Miasto = this.Miasto;
            temp.Ulica = this.Ulica;
            db.Klienci.Add(temp);
            db.SaveChanges();
         MessageBoxResult result=   MessageBox.Show("Dodany","", MessageBoxButton.OK);
            if(result==MessageBoxResult.OK)
            {
                _window.Close();
            }

        }

       
    }

   
}
