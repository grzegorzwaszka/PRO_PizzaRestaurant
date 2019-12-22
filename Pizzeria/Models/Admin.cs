using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public int OsobaIdOsoba { get; set; }
        public int PoziomUprawnien { get; set; }

        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
    }
}
