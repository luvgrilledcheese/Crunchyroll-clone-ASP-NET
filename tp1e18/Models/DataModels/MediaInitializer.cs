using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace tp1e18.Models.DataModels
{
    public class MediaInitializer : DropCreateDatabaseAlways<Media>
    {
        protected override void Seed(Media context)
        {
            base.Seed(context);

        }
    }
}