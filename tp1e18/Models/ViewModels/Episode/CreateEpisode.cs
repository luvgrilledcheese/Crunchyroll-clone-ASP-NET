using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tp1e18.Models.DataModels;
namespace tp1e18.Models.ViewModels.Episode
{
    [CustomValidation(typeof(CreateEpisode), "ValiderCreateEpisode")]
    public class CreateEpisode
    {
        public static ValidationResult ValiderCreateEpisode(CreateEpisode e)
        {
            if (e.Cover != null && e.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être un fichier jpg.", new[] { "" });
            }
            return ValidationResult.Success;
        }

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

        //[ForeignKey("Saison")]
        //public int SaisonId { get; set; }

        //[InverseProperty("Episodes")]
        //public virtual Saison Saison { get; set; }
    }
}