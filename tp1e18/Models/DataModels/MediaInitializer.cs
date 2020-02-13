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

            // Utilisateurs
            var utilisateur1 = new Utilisateur
            {
                NomUtilisateur = "User1",
                MotDePasse = "User1",
                Courriel =  "User1!@gmail.com",
            };
            context.Utilisateur.Add(utilisateur1);

            var utilisateur2 = new Utilisateur
            {
                NomUtilisateur = "User2",
                MotDePasse = "User2",
                Courriel = "User2!@gmail.com",
            };
            context.Utilisateur.Add(utilisateur2);

            var utilisateur3 = new Utilisateur
            {
                NomUtilisateur = "User3",
                MotDePasse = "User3",
                Courriel = "User3!@gmail.com",
            };
            context.Utilisateur.Add(utilisateur3);

            //------------------------------------------            SERIE 1             --------------------------------------------------

            //Serie 1 My Hero Academia
            var serieMyHeroAcademia = new Serie
            {
                Nom = "My Hero Academia",
                Desc = "A description",
                NbrEpisodes = 64,
                Annee = 2016
            };
            context.Serie.Add(serieMyHeroAcademia);

            //Serie 1 : Genre 1

            var genre1 = new Genre
            {
                Nom = "Action"
            };
            context.Genre.Add(genre1);

             //Serie 1 : Genre 2

            var genre2 = new Genre
            {
                Nom = "Adventure"
            };
            context.Genre.Add(genre2);

            // Saison 1 de My Hero Academia

            var saison1 = new Saison
            {
                NoSaison=1
            };
            context.Saison.Add(saison1);

            var episode0101 = new Episode
            {
                Titre = "Izuky Midoyriya: Origin",
                Desc = "An episode description",
                NoEpisode = 1,
                Duree = 24
            };
            context.Episode.Add(episode0101);

            var episode0102 = new Episode
            {
                Titre = "What It Takes To Be a Hero",
                Desc = "An episode description",
                NoEpisode = 2,
                Duree = 24
            };
            context.Episode.Add(episode0102);

            // Saison 2 de My Hero Academia

            var saison02 = new Saison
             {
                NoSaison = 2
             };
            context.Saison.Add(saison02);

            var episode0201 = new Episode
            {
                Titre = "That's the Idea, Ochaco",
                Desc = "An episode description",
                NoEpisode = 1,
                Duree = 24
            };
            context.Episode.Add(episode0201);

            var episode0202 = new Episode
            {
                Titre = "Roaring Sports Festival",
                Desc = "An episode description",
                NoEpisode = 2,
                Duree = 24
            };
            context.Episode.Add(episode0202);

            //----------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------            SERIE 2             --------------------------------------------------

            //Serie 2 Haikyuu
            var serieHaikyuu = new Serie
            {
                Nom = "Haikyuu!! Second Season",
                Desc = "Serie 2",
                NbrEpisodes = 64,
                Annee = 2014
            };
            context.Serie.Add(serieHaikyuu);

            //Serie 2 : Genre 1

            var genre3 = new Genre
            {
                Nom = "Drama"
            };
            //Serie 2 : Genre 2

            var genre4 = new Genre
            {
                Nom = "Shounen"
            };

            //Saison 1 Haikyuu

            // Episode 1
            var Haikyuu0101 = new Episode
            {
                Titre = "The end & the Beginning",
                Desc = "Episode 0101 description",
                NoEpisode = 1,
                Duree = 24
            };
            context.Episode.Add(Haikyuu0101);

            // Episode 2
            var Haikyuu0102 = new Episode
            {
                Titre = "Karasuno High School Volleyball Club",
                Desc = "Episode 0102 description",
                NoEpisode = 2,
                Duree = 24
            };
            context.Episode.Add(Haikyuu0102);

            // Saison 2 Haikyuu

            var Haikyuu02 = new Saison
            {
                NoSaison = 2
            };
            context.Saison.Add(saison02);

            // Saison 2 Episode 1
            var Haikyuu0201 = new Episode
            {
                Titre = "Let's Go To Tokyo!!",
                Desc = "Episode 0201 description",
                NoEpisode = 1,
                Duree = 24
            };
            context.Episode.Add(episode0201);

            // Saison 2 Episode 2
            var Haikyuu0202 = new Episode
            {
                Titre = "Direct Sunlight",
                Desc = "Episode 0202 description",
                NoEpisode = 2,
                Duree = 24
            };
            context.Episode.Add(episode0202);

            //----------------------------------------------------------------------------------------------------------------------------






        }
    }
}