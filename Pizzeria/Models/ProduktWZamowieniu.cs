using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class ProduktWZamowieniu
    {
        public int ProduktIdProdukt { get; set; }
        public int ZamowienieIdZamowienie { get; set; }

        public virtual Produkt ProduktIdProduktNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
