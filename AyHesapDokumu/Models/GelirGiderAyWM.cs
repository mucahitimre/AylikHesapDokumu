using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyHesapDokumu.Models
{
    public class GelirGiderAyWM
    {
        public List<Aylar> AylarList { get; set; }
        public GelirGider GelirGider { get; set; }  
    }
}