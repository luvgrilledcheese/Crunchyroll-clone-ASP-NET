using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tp1e18.Models.DataModels;

namespace tp1e18.Models.ViewModels.Saison
{
    [CustomValidation(typeof(EditSaison), "ValiderCreateSaison")]
    public class EditSaison
    {
        public static ValidationResult ValiderCreateSaison(EditSaison s)
        {
            if (s.Cover != null && s.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être un fichier jpg.", new[] { "" });
            }
            return ValidationResult.Success;
        }

        [Required]
        [Display(Name = "Numéro de la saison", Description = "Numéro de la saison dans la série")]
        public int NoSaison { get; set; }

        [Display(Name = "Image de la saison")]
        public HttpPostedFileBase Cover { get; set; }

        [ForeignKey("Serie")]
        public int SerieId { get; set; }

        [InverseProperty("Saisons")]
        public virtual Serie Serie { get; set; }
    }
}
