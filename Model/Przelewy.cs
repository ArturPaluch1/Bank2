










namespace Bank2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Przelewy")]

    public partial class Przelewy
    {

        [Key]

        [Column("Id Przelewu")]

        public int Id_Przelewu { get; set; }


        [Column(TypeName = "money")]

        public decimal Kwota { get; set; }


        [Column("Nazwa odbiorcy")]

        [Required]

        [StringLength(50)]

        public string Nazwa_odbiorcy { get; set; }


        [Column("Numer rachunku odbiorcy")]

        public long Numer_rachunku_odbiorcy { get; set; }


        [Column("Tytuł przelewu")]

        [Required]

        [StringLength(50)]

        public string Tytuł_przelewu { get; set; }


        [Column(TypeName = "date")]

        public DateTime Data { get; set; }


        public bool zaznaczony { get; set; }


        public int? Nadawca { get; set; }


        public virtual Klienci Klienci { get; set; }

    }
}
