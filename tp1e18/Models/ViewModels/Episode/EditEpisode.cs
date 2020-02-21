using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.ViewModels.Episode
{
    [CustomValidation(typeof(EditEpisode), "ValiderEditEpisode")]
    public class EditEpisode
    {
        public static ValidationResult ValiderEditEpisode(EditEpisode e)
        {
            if (e.Cover != null && e.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être un fichier jpg.", new[] { "" });
            }
            return ValidationResult.Success;
        }

        public int EditEpisodeId { get; set; }

        [MaxLength(50), Required]
        public string Titre { get; set; }

        [Required]
        [Display(Name = "Numéro de l'episode", Description = "Numéro de l'episode dans la saison")]
        public int NoEpisode { get; set; }

        [MaxLength(200), Required]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Required]
        public int Duree { get; set; }

        [Display(Name = "Image de l'episode")]
        public HttpPostedFileBase Cover { get; set; }

        [ForeignKey("Saison")]
        public int SaisonId { get; set; }

        [InverseProperty("Episodes")]
        public virtual DataModels.Saison Saison { get; set; }
    }
}