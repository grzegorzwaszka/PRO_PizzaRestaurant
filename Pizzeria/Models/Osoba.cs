using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            Admin = new HashSet<Admin>();
            Dostawca = new HashSet<Dostawca>();
            Klient = new HashSet<Klient>();
        }

        public int IdOsoba { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Dostawca> Dostawca { get; set; }
        public virtual ICollection<Klient> Klient { get; set; }
    }
}
