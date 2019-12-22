using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            PromocjaNaPizze = new HashSet<PromocjaNaPizze>();
        }

        public int IdPromocja { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public string Kod { get; set; }

        public virtual ICollection<PromocjaNaPizze> PromocjaNaPizze { get; set; }
    }
}
