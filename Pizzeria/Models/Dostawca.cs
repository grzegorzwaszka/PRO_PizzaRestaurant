using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdDostawca { get; set; }
        public string Pojazd { get; set; }
        public int OsobaIdOsoba { get; set; }

        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
