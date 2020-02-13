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

            var studio = new Studio
            {
                NomStudio = "NTV"
            };
            context.Studio.Add(studio);

            //Serie 1

            var serie1 = new Serie
            {
                Nom = "My Hero Academia",
                Desc = "A description",
                NbrEpisodes = 64,
                Annee = 2016
            };
            context.Serie.Add(serie1);

            var genre1 = new Genre
            {
                Nom = "Action"
            };
            context.Genre.Add(genre1);

            var genre2 = new Genre
            {
                Nom = "Adventure"
            };
            context.Genre.Add(genre2);

            // Saison 1

            var saison1 = new Saison
            {
                NoSaison=1
            };
            context.Saison.Add(saison1);

            var episode1 = new Episode
            {
                
            };
            context.Saison.Add(saison1);

            var episode2 = new Episode
            {
                
            };
            context.Saison.Add(saison1);

            // Saison 2

            var saison2 = new Saison
             {
                NoSaison =2
             };
            context.Saison.Add(saison2);



        }
    }
}