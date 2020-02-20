﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tp1e18.Models.DataModels;

namespace tp1e18.Models.ViewModels.Serie
{
    public class CreateSerie
    {
        public static ValidationResult ValiderCreateSaison(CreateSerie s)
        {
            if (s.Cover != null && s.Cover.ContentType != "image/jpeg")
            {
                return new ValidationResult("L'image doit être un fichier jpg.", new[] { "" });
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

        [Display(Name = "Image de la saison")]
        public HttpPostedFileBase Cover { get; set; }

        [Required]
        [Display(Name = "Nombre d'épisode", Description = "Nombre total d'épisode de la série")]
        public int NbrEpisodes { get; set; }

        [Required]
        [Display(Name = "Année", Description = "Année de parution de la Série")]
        public int Annee { get; set; }

        [ForeignKey("Studio")]
        public int StudioId { get; set; }

        [InverseProperty("Series")]
        public virtual Studio Studio { get; set; }
        

        [InverseProperty("Series")]
        public virtual ICollection<Acteur> Acteurs { get; set; } = new HashSet<Acteur>();

        [InverseProperty("Series")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new HashSet<Utilisateur>();

        [ForeignKey("GuideParental")]
        public int GuideParentalId { get; set; }

        [ForeignKey("Series")]
        [Display(Name = "Guide Parental")]
        public virtual GuideParental GuideParental { get; set; }
    }
}