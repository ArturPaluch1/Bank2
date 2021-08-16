using System;

namespace Bank2.Model
{
    public class KredytyDataModel
    {
        public bool IsSelected { get; set; }
        public int Id_Kredytu { get; set; }
        public string KlientImie { get; set; }
        public string KlientNazwisko { get; set; }
        public string Rodzaj_kredytu { get; set; }
        public decimal Kwota_kredytu { get; set; }
        public string ImiePracownika { get; set; }
        public string NazwiskoPracownika { get; set; }
        public DateTime? Data_założenia { get; set; }
        public double Oprocentowanie { get; set; }

    }
}
