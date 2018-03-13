using System.Collections.Generic;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The ay wiew model
    /// </summary>
    public class AyWiewModel
    {
        /// <summary>
        /// Gets or sets the onem derecesi.
        /// </summary>
        /// <value>
        /// The onem derecesi.
        /// </value>
        public AyOnemDerecesi OnemDerecesi { get; set; }

        /// <summary>
        /// Gets or sets the aylar list.
        /// </summary>
        /// <value>
        /// The aylar list.
        /// </value>
        public List<Aylar> AylarList { get; set; }

        /// <summary>
        /// Gets or sets the aylar.
        /// </summary>
        /// <value>
        /// The aylar.
        /// </value>
        public Aylar Aylar { get; set; }
    }
}