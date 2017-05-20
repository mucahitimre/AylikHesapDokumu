using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AyHesapDokumu.Models
{
    public class GelirGider
    {
        public GelirGider()
        {
            AddDateTime = DateTime.Now;
            OnemDerecesi = AyOnemDerecesi.Düşük;
        }
        public int GelirgiderId { get; set; }
        [Required]
        public string Aciklama { get; set; }
        [Required]
        public bool Gelirmi { get; set; }
        [Required]
        public string Tutar { get; set; }
        public DateTime AddDateTime { get; set; }
        public AyOnemDerecesi OnemDerecesi { get; set; }

        public int AylarId { get; set; }
        public Aylar Aylar { get; set; }
    }
}