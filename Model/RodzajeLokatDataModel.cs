using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Model
{
    class RodzajeLokatDataModel
    {
        public int Id_rodzaju_Lokaty { get; set; }
        public string Nazwa { get; set; }
        public double Oprocentowanie { get; set; }
        public string Okres_w_mies { get; set; }
        public double Prowizja { get; set; }

        public string UtworzylImie { get; set; }
        public string UtworzylNazwisko { get; set; }
    }
}
