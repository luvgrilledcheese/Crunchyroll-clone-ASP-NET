using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace tp1e18.Models.DataModels
{
    public partial class Media : DbContext
    {
        public Media()
            : base("name=Media")
        {
            Database.SetInitializer(new MediaInitializer());
        }

        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<Saison> Saison { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}