using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s16372Context : DbContext
    {
        public s16372Context()
        {
        }

        public s16372Context(DbContextOptions<s16372Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<ProduktWZamowieniu> ProduktWZamowieniu { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<PromocjaNaPizze> PromocjaNaPizze { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<SkladnikNaPizzy> SkladnikNaPizzy { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16372;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Admin_pk");

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("Id_admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_Id_osoba");

                entity.Property(e => e.PoziomUprawnien).HasColumnName("Poziom_uprawnien");

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_Osoba");
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.IdAdres)
                    .HasName("Adres_pk");

                entity.Property(e => e.IdAdres)
                    .HasColumnName("Id_adres")
                    .ValueGeneratedNever();

                entity.Property(e => e.KodPocztowy)
                    .IsRequired()
                    .HasColumnName("Kod_pocztowy")
                    .HasMaxLength(6);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NrMieszkania).HasColumnName("Nr_mieszkania");

                entity.Property(e => e.NrUlicy).HasColumnName("Nr_ulicy");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno);

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawca)
                    .HasName("Dostawca_pk");

                entity.Property(e => e.IdDostawca)
                    .HasColumnName("Id_dostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_Id_osoba");

                entity.Property(e => e.Pojazd)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.Dostawca)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dostawca_Osoba");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMP_DEPT");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlienta)
                    .HasColumnName("Id_klienta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OsobaIdOsoba).HasColumnName("Osoba_Id_osoba");

                entity.HasOne(d => d.OsobaIdOsobaNavigation)
                    .WithMany(p => p.Klient)
                    .HasForeignKey(d => d.OsobaIdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Klient_Osoba");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba)
                    .HasName("Osoba_pk");

                entity.Property(e => e.IdOsoba)
                    .HasColumnName("Id_osoba")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("Data_Urodzenia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("Id_pizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProduktIdProdukt).HasColumnName("Produkt_Id_produkt");

                entity.Property(e => e.Wielkosc).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.ProduktIdProduktNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.ProduktIdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Produkt");
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.IdProdukt)
                    .HasName("Produkt_pk");

                entity.Property(e => e.IdProdukt)
                    .HasColumnName("Id_produkt")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa).HasMaxLength(50);
            });

            modelBuilder.Entity<ProduktWZamowieniu>(entity =>
            {
                entity.HasKey(e => new { e.ProduktIdProdukt, e.ZamowienieIdZamowienie })
                    .HasName("Produkt_w_zamowieniu_pk");

                entity.ToTable("Produkt_w_zamowieniu");

                entity.Property(e => e.ProduktIdProdukt).HasColumnName("Produkt_Id_produkt");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_id_zamowienie");

                entity.HasOne(d => d.ProduktIdProduktNavigation)
                    .WithMany(p => p.ProduktWZamowieniu)
                    .HasForeignKey(d => d.ProduktIdProdukt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produkt_w_zamowieniu_Produkt");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.ProduktWZamowieniu)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produkt_w_zamowieniu_Zamowienie");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("Id_promocja")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataDo)
                    .HasColumnName("Data_do")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataOd)
                    .HasColumnName("Data_od")
                    .HasColumnType("datetime");

                entity.Property(e => e.Kod).HasMaxLength(10);
            });

            modelBuilder.Entity<PromocjaNaPizze>(entity =>
            {
                entity.HasKey(e => new { e.PromocjaIdPromocja, e.PizzaIdPizza })
                    .HasName("Promocja_na_pizze_pk");

                entity.ToTable("Promocja_na_pizze");

                entity.Property(e => e.PromocjaIdPromocja).HasColumnName("Promocja_Id_promocja");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_pizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PromocjaNaPizze)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_na_pizze_Pizza");

                entity.HasOne(d => d.PromocjaIdPromocjaNavigation)
                    .WithMany(p => p.PromocjaNaPizze)
                    .HasForeignKey(d => d.PromocjaIdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promocja_na_pizze_Promocja");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("Id_skladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SkladnikNaPizzy>(entity =>
            {
                entity.HasKey(e => new { e.SkladnikIdSkladnik, e.PizzaIdPizza })
                    .HasName("Skladnik_na_pizzy_pk");

                entity.ToTable("Skladnik_na_pizzy");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_Id_skladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_pizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.SkladnikNaPizzy)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladnik_na_pizzy_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.SkladnikNaPizzy)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladnik_na_pizzy_Skladnik");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("id_zamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresIdAdres).HasColumnName("Adres_Id_adres");

                entity.Property(e => e.CzasDostawy)
                    .HasColumnName("Czas_dostawy")
                    .HasColumnType("datetime");

                entity.Property(e => e.DostawcaIdDostawca).HasColumnName("Dostawca_Id_dostawca");

                entity.Property(e => e.KlientIdKlienta).HasColumnName("Klient_Id_klienta");

                entity.HasOne(d => d.AdresIdAdresNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.AdresIdAdres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Adres");

                entity.HasOne(d => d.DostawcaIdDostawcaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DostawcaIdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dostawca");

                entity.HasOne(d => d.KlientIdKlientaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientIdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");
            });
        }
    }
}
