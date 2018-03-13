using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AyHesapDokumu.Models
{
    /// <summary>
    /// The site context
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public sealed class SiteContext : DbContext
    {
        /// <summary>
        /// Gets or sets the aylar.
        /// </summary>
        /// <value>
        /// The aylar.
        /// </value>
        public DbSet<Aylar> Aylar { get; set; }

        /// <summary>
        /// Gets or sets the gelir gider.
        /// </summary>
        /// <value>
        /// The gelir gider.
        /// </value>
        public DbSet<GelirGider> GelirGider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteContext"/> class.
        /// </summary>
        public SiteContext()
            : base("conn")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}