using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlienta { get; set; }
        public int OsobaIdOsoba { get; set; }
        [Required(ErrorMessage ="Email jest wymagany")]
        public string Email { get; set; }

        public virtual Osoba OsobaIdOsobaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
