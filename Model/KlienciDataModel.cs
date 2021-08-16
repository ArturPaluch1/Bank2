using System;
using System.ComponentModel;

namespace Bank2.Model
{
    public class KlienciDataModel : INotifyPropertyChanged
    {
        private bool _IsSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected { get; set; }
        public int Id_klienta { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public int Telefon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string Password { get; set; }
        public decimal Środki { get; set; }
        public DateTime Data_założenia { get; set; }
        public int Numer_rachunku { get; set; }
    }
}
