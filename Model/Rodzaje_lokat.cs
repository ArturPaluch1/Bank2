










namespace Bank2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Rodzaje lokat")]

    public partial class Rodzaje_lokat
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rodzaje_lokat()
        {

            Lokaty = new HashSet<Lokaty>();

        }


        [Key]

        [Column("Id rodzaju lokaty")]

        public int Id_rodzaju_lokaty { get; set; }


        [Required]

        [StringLength(50)]

        public string Nazwa { get; set; }


        public float Oprocentowanie { get; set; }


        [Column("Okres(w mies.)")]

        public int Okres_w_mies__ { get; set; }


        public float Prowizja { get; set; }


        [Column("Lokatę utworzył")]

        public int? Lokatę_utworzył { get; set; }


        public bool? aktywny { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Lokaty> Lokaty { get; set; }


        public virtual Pracownicy Pracownicy { get; set; }

    }
}
