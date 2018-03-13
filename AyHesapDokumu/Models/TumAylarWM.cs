using System.Collections.Generic;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The tum aylar wiew model
    /// </summary>
    public class TumAylarWiewModel
    {
        /// <summary>
        /// Gets or sets the gelir gider list.
        /// </summary>
        /// <value>
        /// The gelir gider list.
        /// </value>
        public List<GelirGider> GelirGiderList { get; set; }

        /// <summary>
        /// Gets or sets the aylar list.
        /// </summary>
        /// <value>
        /// The aylar list.
        /// </value>
        public List<Aylar> AylarList { get; set; }
    }
}