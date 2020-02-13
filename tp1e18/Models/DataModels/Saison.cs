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
        public int NoSaison { get; set; }

        [NotMapped]
        public string Cover { get => $"/Content/Images/SaisonId/{this.SaisonId}.jpg"; }

        [InverseProperty("Saison")]
        public virtual ICollection<Episode> Episodes { get; set; }

        [ForeignKey("Serie")]
        public int SerieId { get; set; }

        [InverseProperty("Saisons")]
        public Serie Serie { get; set; }
    }
}