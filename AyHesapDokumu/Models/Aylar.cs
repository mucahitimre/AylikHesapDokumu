using System.ComponentModel.DataAnnotations;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The aylar
    /// </summary>
    public class Aylar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aylar"/> class.
        /// </summary>
        public Aylar()
        {
            OnemDerecesi = AyOnemDerecesi.Dusuk;
        }

        /// <summary>
        /// Gets or sets the aylar identifier.
        /// </summary>
        /// <value>
        /// The aylar identifier.
        /// </value>
        public int AylarId { get; set; }

        /// <summary>
        /// Gets or sets the ay adi.
        /// </summary>
        /// <value>
        /// The ay adi.
        /// </value>
        [Required]
        public string AyAdi { get; set; }

        /// <summary>
        /// Gets or sets the onem derecesi.
        /// </summary>
        /// <value>
        /// The onem derecesi.
        /// </value>
        public AyOnemDerecesi OnemDerecesi { get; set; }

        /// <summary>
        /// Gets or sets the toplam gider.
        /// </summary>
        /// <value>
        /// The toplam gider.
        /// </value>
        public int ToplamGider { get; set; }

        /// <summary>
        /// Gets or sets the toplam gelir.
        /// </summary>
        /// <value>
        /// The toplam gelir.
        /// </value>
        public int ToplamGelir { get; set; }
    }
}