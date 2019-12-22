using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ProduktWZamowieniu = new HashSet<ProduktWZamowieniu>();
        }

        public int IdZamowienie { get; set; }
        public int DostawcaIdDostawca { get; set; }
        public int KlientIdKlienta { get; set; }
        public int AdresIdAdres { get; set; }
        public DateTime CzasDostawy { get; set; }

        public virtual Adres AdresIdAdresNavigation { get; set; }
        public virtual Dostawca DostawcaIdDostawcaNavigation { get; set; }
        public virtual Klient KlientIdKlientaNavigation { get; set; }
        public virtual ICollection<ProduktWZamowieniu> ProduktWZamowieniu { get; set; }
    }
}
