using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AyHesapDokumu.Models
{
    public class Aylar
    {
        public Aylar()
        {
            OnemDerecesi = AyOnemDerecesi.Düşük;
        }
        public int AylarId { get; set; }
        [Required]
        public string AyAdi { get; set; }
        public AyOnemDerecesi OnemDerecesi { get; set; }
        public int ToplamGider { get; set; }
        public int ToplamGelir { get; set; }

    }
}