using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2.Model
{
    public class PrzelewyDataModel
    {
        public bool IsSelected { get; set; }
        public int Id_Przelewu { get; set; }
        public decimal Kwota { get; set; }
        public string Nazwa_odbiorcy { get; set; }
        public int Numer_rachunku_odbiorcy { get; set; }
        public string Tytuł_przelewu { get; set; }
        public string NadawcaImię { get; set; }
        public string NadawcaNazwisko { get; set; }
        public DateTime? Data { get; set; }
      
    }
}
