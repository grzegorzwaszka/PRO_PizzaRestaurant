using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PromocjaNaPizze = new HashSet<PromocjaNaPizze>();
            SkladnikNaPizzy = new HashSet<SkladnikNaPizzy>();
        }

        public int IdPizza { get; set; }
        public decimal Wielkosc { get; set; }
        public string Nazwa { get; set; }
        public int ProduktIdProdukt { get; set; }

        public virtual Produkt ProduktIdProduktNavigation { get; set; }
        public virtual ICollection<PromocjaNaPizze> PromocjaNaPizze { get; set; }
        public virtual ICollection<SkladnikNaPizzy> SkladnikNaPizzy { get; set; }
    }
}
