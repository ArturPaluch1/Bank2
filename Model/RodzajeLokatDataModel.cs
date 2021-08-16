namespace Bank2.Model
{
    class RodzajeLokatDataModel
    {
        public bool IsSelected { get; set; }
        public int Id_rodzaju_Lokaty { get; set; }
        public string Nazwa { get; set; }
        public double Oprocentowanie { get; set; }
        public int Okres_w_mies { get; set; }
        public double Prowizja { get; set; }

        public string UtworzylImie { get; set; }
        public string UtworzylNazwisko { get; set; }
    }
}
