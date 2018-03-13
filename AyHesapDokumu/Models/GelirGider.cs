using System.ComponentModel.DataAnnotations;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The gelir gider
    /// </summary>
    public class GelirGider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GelirGider"/> class.
        /// </summary>
        public GelirGider()
        {
            OnemDerecesi = AyOnemDerecesi.Dusuk;
        }

        /// <summary>
        /// Gets or sets the gelirgider identifier.
        /// </summary>
        /// <value>
        /// The gelirgider identifier.
        /// </value>
        public int GelirgiderId { get; set; }

        /// <summary>
        /// Gets or sets the aciklama.
        /// </summary>
        /// <value>
        /// The aciklama.
        /// </value>
        [Required]
        public string Aciklama { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GelirGider"/> is gelirmi.
        /// </summary>
        /// <value>
        ///   <c>true</c> if gelirmi; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool Gelirmi { get; set; }

        /// <summary>
        /// Gets or sets the tutar.
        /// </summary>
        /// <value>
        /// The tutar.
        /// </value>
        [Required]
        public string Tutar { get; set; }

        /// <summary>
        /// Gets or sets the onem derecesi.
        /// </summary>
        /// <value>
        /// The onem derecesi.
        /// </value>
        public AyOnemDerecesi OnemDerecesi { get; set; }

        /// <summary>
        /// Gets or sets the aylar identifier.
        /// </summary>
        /// <value>
        /// The aylar identifier.
        /// </value>
        public int AylarId { get; set; }

        /// <summary>
        /// Gets or sets the aylar.
        /// </summary>
        /// <value>
        /// The aylar.
        /// </value>
        public Aylar Aylar { get; set; }
    }
}