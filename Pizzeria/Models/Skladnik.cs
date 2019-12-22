using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladnikNaPizzy = new HashSet<SkladnikNaPizzy>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public string Typ { get; set; }

        public virtual ICollection<SkladnikNaPizzy> SkladnikNaPizzy { get; set; }
    }
}
