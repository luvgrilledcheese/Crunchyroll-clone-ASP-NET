using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace tp1e18.Models.DataModels
{
    public class MediaDb : DbContext
    {
        public MediaDb() : base(nameOrConnectionString: "CSEcoleDb")
        {
            this.Configuration.LazyLoadingEnabled = true;
            // Database.SetInitializer(new MediaInitializer());
        }
        public Dbset<Serie> Serie { get; set; }
    }
}