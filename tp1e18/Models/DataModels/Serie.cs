using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Serie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerieId { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50), Required]
        [Display(Name ="Nom", Description ="Nom de la Série")]
        public string Nom { get; set; }

        [MaxLength(250), Required]
        [Display(Name = "Description", Description = "Description de la Série")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [NotMapped]
        [Display(Name = "Image", Description = "Image de la Série")]
        public string CoverPath { get => $"/Content/Images/Serie/{this.SerieId}.jpg"; }

        [Required]
        [Display(Name = "Nombre d'épisode", Description = "Nombre total d'épisode de la série")]
        public int NbrEpisodes { get; set; }

        [Required]
        [Display(Name = "Année", Description = "Année de parution de la Série")]
        public int Annee { get; set; }

      // [ForeignKey("Studio")]
        public int StudioId { get; set; }

        [InverseProperty("Series")]
        public virtual Studio Studio { get; set; }

        [InverseProperty("Serie")]
        public virtual ICollection<Saison> Saisons { get; set; } = new HashSet<Saison>();

        [InverseProperty("Series")]
        public virtual ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

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