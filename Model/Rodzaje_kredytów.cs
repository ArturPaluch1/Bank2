










namespace Bank2.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Rodzaje kredytów")]

    public partial class Rodzaje_kredytów
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rodzaje_kredytów()
        {

            Kredyty = new HashSet<Kredyty>();

        }


        [Key]

        [Column("Id rodzaju kredytu")]

        public int Id_rodzaju_kredytu { get; set; }


        [Required]

        [StringLength(50)]

        public string Nazwa { get; set; }


        public float Oprocentowanie { get; set; }


        [Column("Okres kredytowania(w mies.)")]

        public int Okres_kredytowania_w_mies__ { get; set; }


        public float Prowizja { get; set; }


        [Column("Kredyt utworzył")]

        public int? Kredyt_utworzył { get; set; }


        public bool? aktywny { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Kredyty> Kredyty { get; set; }


        public virtual Pracownicy Pracownicy { get; set; }

    }
}
