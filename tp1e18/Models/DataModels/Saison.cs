using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1e18.Models.DataModels
{
    public class Saison
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaisonId { get; set; }

        [Required]
        [Display(Name = "Numéro de la saison", Description = "Numéro de la saison dans la série")]
        public int NoSaison { get; set; }

        [NotMapped]
        [Display(Name = "Image", Description = "Image de la saison")]
        public string CoverPath { get => $"/Content/Images/Saison/{this.SaisonId}.jpg"; }

        [InverseProperty("Saison")]
        public virtual ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();

        [ForeignKey("Serie")]
        public int SerieId { get; set; }

        [InverseProperty("Saisons")]
        public virtual Serie Serie { get; set; }
    }
}