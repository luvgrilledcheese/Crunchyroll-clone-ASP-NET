namespace tp1e18.Models.DataModels {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Acteur
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActeurId { get; set; }

        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [NotMapped]
        [Required]
        public string CoverPath { get => $"/Content/Images/Acteur/{this.ActeurId}.jpg"; }

        [MaxLength(50), Required]
        public string Personnage { get; set; }

        [InverseProperty("Acteurs")]
        public virtual ICollection<Serie> Series { get; set; } = new HashSet<Serie>();
    }
}