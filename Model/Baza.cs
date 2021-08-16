using System.Data.Entity;











namespace Bank2.Model
{
    public partial class Baza : DbContext
    {
        public Baza()
            : base("name=Baza")
        {
        }


        public virtual DbSet<Klienci> Klienci { get; set; }

        public virtual DbSet<Kredyty> Kredyty { get; set; }

        public virtual DbSet<Lokaty> Lokaty { get; set; }

        public virtual DbSet<Pracownicy> Pracownicy { get; set; }

        public virtual DbSet<Przelewy> Przelewy { get; set; }

        public virtual DbSet<Rodzaje_kredytów> Rodzaje_kredytów { get; set; }

        public virtual DbSet<Rodzaje_lokat> Rodzaje_lokat { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Klienci>()
                .Property(e => e.Imię)
                .IsFixedLength();


            modelBuilder.Entity<Klienci>()
                .Property(e => e.Nazwisko)
                .IsFixedLength();


            modelBuilder.Entity<Klienci>()
                .Property(e => e.Password)
                .IsFixedLength();


            modelBuilder.Entity<Klienci>()
                .Property(e => e.Miasto)
                .IsFixedLength();


            modelBuilder.Entity<Klienci>()
                .Property(e => e.Ulica)
                .IsFixedLength();


            modelBuilder.Entity<Klienci>()
                .Property(e => e.Środki)
                .HasPrecision(18, 0);


            modelBuilder.Entity<Klienci>()
                .HasMany(e => e.Kredyty)
                .WithOptional(e => e.Klienci)
                .HasForeignKey(e => e.Klient);


            modelBuilder.Entity<Klienci>()
                .HasMany(e => e.Lokaty)
                .WithOptional(e => e.Klienci)
                .HasForeignKey(e => e.Klient);


            modelBuilder.Entity<Klienci>()
                .HasMany(e => e.Przelewy)
                .WithOptional(e => e.Klienci)
                .HasForeignKey(e => e.Nadawca);


            modelBuilder.Entity<Kredyty>()
                .Property(e => e.Kwota_kredytu)
                .HasPrecision(19, 4);


            modelBuilder.Entity<Lokaty>()
                .Property(e => e.Wysokość_lokaty)
                .HasPrecision(19, 4);


            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Imię_pracownika)
                .IsFixedLength();


            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Nazwisko_pracownika)
                .IsFixedLength();


            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.PESEL)
                .IsFixedLength();


            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Wynagrodzenie)
                .HasPrecision(19, 4);


            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Password)
                .IsFixedLength();


            modelBuilder.Entity<Pracownicy>()
                .HasMany(e => e.Kredyty)
                .WithOptional(e => e.Pracownicy)
                .HasForeignKey(e => e.Kredytu_udzielił);


            modelBuilder.Entity<Pracownicy>()
                .HasMany(e => e.Lokaty)
                .WithOptional(e => e.Pracownicy)
                .HasForeignKey(e => e.Lokaty_udzielił);


            modelBuilder.Entity<Pracownicy>()
                .HasMany(e => e.Rodzaje_kredytów)
                .WithOptional(e => e.Pracownicy)
                .HasForeignKey(e => e.Kredyt_utworzył);


            modelBuilder.Entity<Pracownicy>()
                .HasMany(e => e.Rodzaje_lokat)
                .WithOptional(e => e.Pracownicy)
                .HasForeignKey(e => e.Lokatę_utworzył);


            modelBuilder.Entity<Przelewy>()
                .Property(e => e.Kwota)
                .HasPrecision(19, 4);


            modelBuilder.Entity<Przelewy>()
                .Property(e => e.Nazwa_odbiorcy)
                .IsFixedLength();


            modelBuilder.Entity<Przelewy>()
                .Property(e => e.Tytuł_przelewu)
                .IsFixedLength();


            modelBuilder.Entity<Rodzaje_kredytów>()
                .Property(e => e.Nazwa)
                .IsFixedLength();


            modelBuilder.Entity<Rodzaje_kredytów>()
                .HasMany(e => e.Kredyty)
                .WithOptional(e => e.Rodzaje_kredytów)
                .HasForeignKey(e => e.Rodzaj_kredytu);


            modelBuilder.Entity<Rodzaje_lokat>()
                .Property(e => e.Nazwa)
                .IsFixedLength();

        }
    }
}
