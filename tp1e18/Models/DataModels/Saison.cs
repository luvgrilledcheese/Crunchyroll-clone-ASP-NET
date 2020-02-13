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

        //[InverseProperty("Saison")]
        //public virtual ICollection<Episode> Episodes { get; set; }

        //[ForeignKey("Serie")]
        //public int SerieId { get; set; }

        //[InverseProperty("Series")]
        //public int Serie { get; set; }
    }
}