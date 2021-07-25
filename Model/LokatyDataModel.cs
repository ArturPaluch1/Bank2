using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Model
{
    class LokatyDataModel
    {
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
