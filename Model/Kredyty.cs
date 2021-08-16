










namespace Bank2.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Kredyty")]

    public partial class Kredyty
    {

        [Key]

        [Column("Id Kredytu")]

        public int Id_Kredytu { get; set; }


        public int? Klient { get; set; }


        [Column("Rodzaj kredytu")]

        public int? Rodzaj_kredytu { get; set; }


        [Column("Kwota kredytu", TypeName = "money")]

        public decimal Kwota_kredytu { get; set; }


        [Column("Kredytu udzielił")]

        public int? Kredytu_udzielił { get; set; }


        [Column("Data założenia", TypeName = "date")]

        public DateTime? Data_założenia { get; set; }


        public bool aktywny { get; set; }


        public virtual Klienci Klienci { get; set; }


        public virtual Pracownicy Pracownicy { get; set; }


        public virtual Rodzaje_kredytów Rodzaje_kredytów { get; set; }

    }
}
