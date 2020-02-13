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

        [MaxLength(50), Required]
        public string Personnage { get; set; }

        [ForeignKey("Serie")]
        public int SerieId { get; set; }

        [InverseProperty("Series")]
        public Serie Serie { get; set; }
    }
}