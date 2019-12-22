using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class SkladnikNaPizzy
    {
        public int SkladnikIdSkladnik { get; set; }
        public int PizzaIdPizza { get; set; }
        public int Ilosc { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
