using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Adres
    {
        public Adres()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdAdres { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public int NrUlicy { get; set; }
        public int? NrMieszkania { get; set; }
        public string KodPocztowy { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
