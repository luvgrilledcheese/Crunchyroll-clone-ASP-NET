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

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        public string Desc { get; set; }

        [Required]
        public int NbrEpisodes { get; set; }

        [ForeignKey("Studio")]
        public int StudioId { get; set; }

        [InverseProperty("Series")]
        public Studio Studio { get; set; }

        [InverseProperty("Serie")]
        public virtual ICollection<Saison> Saisons { get; set; }

        [InverseProperty("Series")]
        public virtual ICollection<Genre> Genres { get; set; }

        [InverseProperty("Series")]
        public virtual ICollection<Acteur> Acteurs { get; set; }

        [InverseProperty("Utilisateurs")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }

        [ForeignKey("GuideParentals")]
        public int GuideParentalId { get; set; }

        [ForeignKey("Series")]
        public GuideParental GuideParentals { get; set; }
    }
}