using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tp1e18.Models.ViewModels.Acteur
{
    [CustomValidation(typeof(EditActeur), "ValiderEditActeur")]
    public class EditActeur
    {
        public static ValidationResult ValiderEditActeur(EditActeur a)
        {
            if (a.Cover != null && a.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être un fichier jpg.", new[] { "" });
            }
            return ValidationResult.Success;
        }

        public int EditActeurId { get; set; }

        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [Display(Name = "Photo de l'acteur")]
        public HttpPostedFileBase Cover { get; set; }

        [MaxLength(50), Required]
        public string Personnage { get; set; }
    }
}