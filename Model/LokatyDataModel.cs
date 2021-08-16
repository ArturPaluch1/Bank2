using System;

namespace Bank2.Model
{
    public class LokatyDataModel
    {
        public bool IsSelected { get; set; }
        public int Id_Lokaty { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string Rodzaj_lokaty { get; set; }
        public decimal Kwota_lokaty { get; set; }
        public string ImiePracownika { get; set; }
        public string NazwiskoPracownika { get; set; }
        public DateTime? Data_założenia { get; set; }
        public double Oprocentowanie { get; set; }
    }
}
