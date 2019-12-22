using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            Pizza = new HashSet<Pizza>();
            ProduktWZamowieniu = new HashSet<ProduktWZamowieniu>();
        }

        public int IdProdukt { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<ProduktWZamowieniu> ProduktWZamowieniu { get; set; }
    }
}
