using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyHesapDokumu.Models
{
    public class AyWM
    {
        public AyOnemDerecesi OnemDerecesi { get; set; }
        public List<Aylar> AylarList { get; set; }
        public Aylar Aylar { get; set; }
    }
}