using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PromocjaNaPizze
    {
        public int PromocjaIdPromocja { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Promocja PromocjaIdPromocjaNavigation { get; set; }
    }
}
