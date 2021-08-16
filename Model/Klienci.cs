










namespace Bank2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Klienci")]

    public partial class Klienci
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klienci()
        {

            Kredyty = new HashSet<Kredyty>();

            Lokaty = new HashSet<Lokaty>();

            Przelewy = new HashSet<Przelewy>();

        }


        [Key]

        [Column("Id klienta")]

        public int Id_klienta { get; set; }


        [Required]

        [StringLength(50)]

        public string Imię { get; set; }


        [Required]

        [StringLength(50)]

        public string Nazwisko { get; set; }


        [Required]

        [StringLength(50)]

        public string Password { get; set; }


        [Column("Numer rachunku")]

        public int Numer_rachunku { get; set; }


        [Column("Data założenia", TypeName = "date")]

        public DateTime Data_założenia { get; set; }


        public int Telefon { get; set; }


        [Required]

        [StringLength(50)]

        public string Miasto { get; set; }


        [Required]

        [StringLength(50)]

        public string Ulica { get; set; }


        public decimal Środki { get; set; }


        public bool? aktywny { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Kredyty> Kredyty { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Lokaty> Lokaty { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Przelewy> Przelewy { get; set; }

    }
}
