using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Model
{
    class RodzajeKredytowDataModel
    {
        public int Id_rodzaju_Kredytu { get; set; }
        public string Nazwa { get; set; }
        public double Oprocentowanie { get; set; }
        public string Okres_kredytowania_w_mies { get; set; }
        public double Prowizja { get; set; }
        
        public string UtworzylImie { get; set; }
        public string UtworzylNazwisko { get; set; }
      
        
    }
}
