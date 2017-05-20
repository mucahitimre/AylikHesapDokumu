using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AyHesapDokumu.Models
{
    public class SiteContext : DbContext
    {
        public virtual DbSet<Aylar> Aylar { get; set; }
        public virtual DbSet<GelirGider> GelirGider { get; set; }

        public SiteContext():base("conn")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}