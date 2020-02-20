using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.ViewModels.Serie
{
    [CustomValidation(typeof(CreateSerie), "Valider")]
    public class CreateSerie
    {
        public static ValidationResult Valider(CreateSerie cs)
        {
            if (cs.Cover == null)
            {
                return new ValidationResult("L'image est obligatoire", new[] { "Cover" });
            }
            if (cs.Cover != null && cs.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être jpeg", new[] { "Cover" });
            }
            if (cs.Cover != null && cs.Cover.ContentLength == 0)
            {
                return new ValidationResult("Le fichier image doit contenir une image", new[] { "Cover" });
            }
            return ValidationResult.Success;
        }


        [Index(IsUnique = true)]
        [MaxLength(50), Required]
        [Display(Name = "Nom", Description = "Nom de la Série")]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Description", Description = "Description de la Série")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Required]
        [Display(Name = "Nombre d'épisode", Description = "Nombre total d'épisode de la série")]
        public int NbrEpisodes { get; set; }

        [Required]
        [Display(Name = "Année", Description = "Année de parution de la Série")]
        public int Annee { get; set; }

        [Required]
        public HttpPostedFileBase Cover { get; set; }
    }
}