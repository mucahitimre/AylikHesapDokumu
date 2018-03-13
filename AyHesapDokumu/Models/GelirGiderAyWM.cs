using System.Collections.Generic;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The gelir gider ay wiew model
    /// </summary>
    public class GelirGiderAyWiewModel
    {
        /// <summary>
        /// Gets or sets the aylar list.
        /// </summary>
        /// <value>
        /// The aylar list.
        /// </value>
        public List<Aylar> AylarList { get; set; }

        /// <summary>
        /// Gets or sets the gelir gider.
        /// </summary>
        /// <value>
        /// The gelir gider.
        /// </value>
        public GelirGider GelirGider { get; set; }  
    }
}