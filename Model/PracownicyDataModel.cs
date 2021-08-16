using System;

namespace Bank2.Model
{
    public class PracownicyDataModel
    {
        public bool IsSelected { get; set; }
        public int Id_Pracownika { get; set; }
        public string Imię_pracownika { get; set; }
        public string Nazwisko_pracownika { get; set; }
        public DateTime Data_zatrudnienia { get; set; }
        public string Password { get; set; }
        public string PESEL { get; set; }
        public int? Telefon { get; set; }
    }
}
